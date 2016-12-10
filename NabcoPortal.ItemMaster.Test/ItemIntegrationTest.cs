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
        private ReferenceContextDb _referenceContextDb;
        private IItemData _itemData;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextDb = new ItemContextDb();
            _referenceContextDb = new ReferenceContextDb();
            _itemData = new ItemData(_contextDb,_referenceContextDb);
        }


        [TestMethod]
        public async Task Can_Add_Item()
        {
            var oldData = await _itemData.GetItems();
            var item = Item.Create("Kings Bed", "M200", "F1001", " mattress and pillow", "PC");
            await _itemData.AddItem(item);
            var newData = await _itemData.GetItems();
            Assert.AreEqual((oldData.Count()+1),newData.Count());
        }

        [TestMethod]
        public async Task Can_Update_Item()
        {
            var id = 5;
            var oldModelNo = "M100";
            var itemToEdit = await _itemData.GetItem(id);
            itemToEdit.ModelNo = "M101";
            await _itemData.UpdateItem(itemToEdit);
            var updatedEdit = await _itemData.GetItem(id);

            Assert.AreNotEqual(oldModelNo,updatedEdit.ModelNo);
            
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
            var newItem = Item.Create("Queens Bed", "M100", "F1001", " mattress and pillow", "PC");
            var item = await _itemData.GetItem(2); //get the first item
            Assert.AreEqual(newItem.ModelNo,item.ModelNo);
        }


    }
}
