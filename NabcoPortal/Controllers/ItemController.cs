using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NabcoPortal.ItemMaster.Domain.IData;
using NabcoPortal.ItemMaster.Domain.Model;
using NabcoPortal.ViewModel;

namespace NabcoPortal.Controllers
{

    /// <summary>
    ///
    /// Goal: Opening Master File, Listing all items 
    /// </summary>
    /// 
    /// 
    ///
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IItemData _itemData;

        public ItemController(IItemData itemData)
        {
            _itemData = itemData;
        }
       
        // GET: Show Item List
        public async Task<ActionResult> Index()
        {
            var items = await _itemData.GetItems();
            var mvItems = Mapper.Map<IEnumerable<ItemViewModel>>(items);
            return View(mvItems);
        }

        public PartialViewResult Create()
        {
            return PartialView(new ItemViewModel());
        }

        public async Task<PartialViewResult> Edit(int id)
        {
            var item = await _itemData.GetItem(id);
            var mvItems = Mapper.Map<ItemViewModel>(item);
            return PartialView("Create", mvItems);
        }

        //GET: Show selected item
        public async Task<PartialViewResult> GetItem(int id)
        {
            var item = await _itemData.GetItem(id);
            var mvItem = Mapper.Map<ItemViewModel>(item);
            return PartialView(mvItem);
        }



    }
}