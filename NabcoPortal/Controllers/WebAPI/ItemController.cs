using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using NabcoPortal.ItemMaster.Data.Data;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.Controllers.WebAPI
{   
    public class ItemController : ApiController
    {
        private ItemData _itemData;
        public ItemController(ItemData itemData)
        {
            _itemData = itemData;
        }

        //create item
        public IHttpActionResult Get()
        {
            var item = new Item();
            return Ok(item);
        }

        //edit item
        public async Task<Item> Get(int id)
        {
            var item = await _itemData.GetItem(id);
            return item;
        }
    }
}
