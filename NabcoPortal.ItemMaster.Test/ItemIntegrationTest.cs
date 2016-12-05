using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NabcoPortal.ItemMaster.Data;
using NabcoPortal.ItemMaster.Data.Data;
using NabcoPortal.ItemMaster.Domain.IData;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ItemMaster.Test
{
    [TestClass]
    public class ItemIntegrationTest
    {
        private ItemContextDb _contextDb;
        private IItemData _itemData;


        [TestInitialize]
        public void TestInitialize()
        {
            _contextDb = new ItemContextDb();
            _itemData = new ItemData(_contextDb);
        }

        [TestMethod]
        public async Task Can_Add_Item()
        {
            var item = Item.Create("100", "Item 1", "Item description 1");
            await _itemData.AddItem(item);
            var items = await _itemData.GetItems();

            Assert.AreEqual(1,items.Count());
        }
    }
}
