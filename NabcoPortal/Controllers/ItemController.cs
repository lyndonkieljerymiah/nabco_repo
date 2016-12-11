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
    
    [RoutePrefix("Item")]
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IItemData _itemData;
        private readonly ICategoryData _categoryData;
        private const int DEFAULT_SIZE = 2;

        public ItemController(IItemData itemData,ICategoryData categoryData)
        {
            _itemData = itemData;
            _categoryData = categoryData;
        }
       
        // GET: Show Item List
        [Route("List/{page?}")]
        public async Task<ActionResult> Index(int page=1)
        {
            var items = await _itemData.GetItems(page,DEFAULT_SIZE);
            ItemTableViewModel vm = new ItemTableViewModel
            {
                ItemViewModels = ItemViewModel.CreateRange(items),
                CurrentPage = page,
                PageSize = DEFAULT_SIZE,
                TotalCount = _itemData.GetTotalRecordCount()
            };
            
            return View(vm);
        }

        //GET: Show Blank Form Item
        public async Task<PartialViewResult> Create()
        {   
            var item = ItemViewModel.CreateEmpty((await _categoryData.GetCategories()));
            item.ActionUrl = Request.Url.Scheme + @"://" + Request.Url.Authority + "/api/item"; //add url
            
            return PartialView(item);
        }

        public async Task<PartialViewResult> Edit(int id)
        {   
            var item = await _itemData.GetItem(id);
            var mvItems = ItemViewModel.CreateWithItem(item, (await _categoryData.GetCategories()));
            mvItems.ActionUrl = Request.Url.Scheme + @"://" + Request.Url.Authority + "/api/item";

            return PartialView("Create", mvItems);
        }

        //GET: Show selected item
        public async Task<PartialViewResult> Detail(int id)
        {
            var item = await _itemData.GetItem(id);
            var mvItem = Mapper.Map<ItemViewModel>(item);
            return PartialView(mvItem);
        }
        #region Private Method
        #endregion
    }
}