using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NabcoPortal.ItemMaster.Domain.IData;

namespace NabcoPortal.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemData _itemData;

        public ItemController(IItemData itemData)
        {
            _itemData = itemData;
        }
        
        
        // GET: Item
        public async Task<ActionResult> Index()
        {
            var items = await _itemData.GetItems();
            return View(items);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}