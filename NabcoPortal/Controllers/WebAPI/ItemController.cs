﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.Owin;
using NabcoPortal.ItemMaster.Data.Data;
using NabcoPortal.ItemMaster.Domain.Model;
using NabcoPortal.ViewModel;

namespace NabcoPortal.Controllers.WebAPI
{   
    /// <summary>
    /// Goal: Responsible for create and update operation of the item master file
    /// </summary>
    public class ItemController : ApiController
    {
        private ItemData _itemData;
        
        public ItemController(ItemData itemData)
        {
            _itemData = itemData;
        }
        [HttpPost]
        public async Task<IHttpActionResult> Update(ItemViewModel vm)
        {

            Item item = null;
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            //save item
            if (vm.Id != 0)
            {
                //update
                item = Item.ToUpdate(vm.Id, vm.Name, vm.ModelNo, vm.FinishingCode, vm.Composition, vm.UOM);
                await _itemData.UpdateItem(item);
            }
            else
            {
                //insert new item
                item = Item.Create(vm.Name, vm.ModelNo, vm.FinishingCode, vm.Composition, vm.UOM);
                await _itemData.AddItem(item);
            }

            return Ok();
        }




    }
}
