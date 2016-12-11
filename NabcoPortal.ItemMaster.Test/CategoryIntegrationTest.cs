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
    public class CategoryIntegrationTest
    {
        private ItemContextDb _contextDb;
        private ICategoryData _categoryData;


        [TestInitialize]
        public void TestInitialize()
        {
            _contextDb = new ItemContextDb();
            _categoryData = new CategoryData(_contextDb);
        }

        [TestMethod]
        public async Task Can_Add_Category()
        {
            var oldData = await _categoryData.GetCategories();
            var category = Category.Create("Lightning", "Lightning");
            
            await _categoryData.AddCategory(category);
            
            var newData = await _categoryData.GetCategories();
            
            Assert.AreEqual((oldData.Count() + 1), newData.Count());
        }


        [TestMethod]
        public void Can_Update_Category()
        {

        }


        [TestMethod]
        public async Task Can_Get_Category()
        {
            var compareCategory = Category.Create("Bed Room", "Bed Room");
            var category = await _categoryData.GetCategory(1);
            Assert.AreEqual(compareCategory.Name,category.Name);
        }


        [TestMethod]
        public async Task Can_Get_Categories()
        {
            var categories = await _categoryData.GetCategories();
            
            Assert.AreNotEqual(0,categories.Count());
        }


    }
}
