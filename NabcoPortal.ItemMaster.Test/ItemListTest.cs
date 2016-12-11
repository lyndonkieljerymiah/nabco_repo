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
    public class ItemListTest
    {

        private ItemContextDb _contextDb;
        private ReferenceContextDb _referenceContextDb;
        private IItemData _itemData;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextDb = new ItemContextDb();
            _referenceContextDb = new ReferenceContextDb();
            _itemData = new ItemData(_contextDb, _referenceContextDb);
        }



        [TestMethod]
        public async Task Can_Show_Page_1()
        {
            var expItem = Item.Create("Queens Bed with pillows", "M101", "F1001", 1, " mattress and pillow", "PC");
            var items = await _itemData.GetItems(1, 1);
            Assert.AreEqual(1,items.Count());
        }

        [TestMethod]
        public void Can_Show_Total_Count()
        {
            var totalCount = _itemData.GetTotalRecordCount();
            Assert.AreNotEqual(0,totalCount);
        }
        
    }
}
