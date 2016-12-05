using System;
using System.Collections.Generic;
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

            var oldData = await _itemData.GetItems();

            var item = Item.Create("100", "Item 1", "Item description 1");
            await _itemData.AddItem(item);
            var newData = await _itemData.GetItems();

            Assert.AreEqual((oldData.Count()+1),newData.Count());
        }

        [TestMethod]
        public async Task Can_Get_All_Items()
        {
            var data = await _itemData.GetItems();
            Assert.AreNotEqual(0,data.Count());
        }

        [TestMethod]
        public async Task Can_Get_Item_By_Id()
        {
            var newItem = Item.Create("100", "Item 1", "Item description 1");
            var item = await _itemData.GetItem(1); //get the first item
            Assert.AreEqual(newItem.Code,item.Code);

        }


    }
}
