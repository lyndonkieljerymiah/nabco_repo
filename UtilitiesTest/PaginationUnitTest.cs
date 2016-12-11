using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.Extension;
using Utilities.Helper.Paging;

namespace UtilitiesTest
{

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [TestClass]
    public class PaginationUnitTest
    {
        private ICollection<Item> _items;
        private const int DEFAULT_PAGE_SIZE = 4;

        [TestInitialize]
        public void TestInitialize()
        {
            _items = new List<Item>
            {
                new Item {Id = 1, Name = "Bed"},
                new Item {Id = 2, Name = "Pillow"},
                new Item {Id = 3, Name = "Chair"},
                new Item {Id = 4, Name = "Wardrobe"},
                new Item {Id = 5, Name = "King Bed"},
                new Item {Id = 6, Name = "Blue Pillow"},
                new Item {Id = 7, Name = "White Chair"},
                new Item {Id = 8, Name = "Small Wardrobe"},
                new Item {Id = 1, Name = "Bed"},
                new Item {Id = 2, Name = "Pillow"},
                new Item {Id = 3, Name = "Chair"},
                new Item {Id = 4, Name = "Wardrobe"},
                new Item {Id = 5, Name = "King Bed"},
                new Item {Id = 6, Name = "Blue Pillow"},
                new Item {Id = 7, Name = "White Chair"},
                new Item {Id = 8, Name = "Small Wardrobe"}
            };
        }
        
        [TestMethod]
        public void Can_MoveFirst()
        {
            var page = 1;
            var items = _items.ToPageList(page, DEFAULT_PAGE_SIZE);
            Assert.AreEqual(true,items.IsFirstPage);
        }


        [TestMethod]
        public void Can_MovePrev()
        {
            var page = 2;
            page--;
            var items = _items.ToPageList(page, DEFAULT_PAGE_SIZE);
            Assert.AreEqual(true, items.IsFirstPage);
        }

        [TestMethod]
        public void Can_MoveNext()
        {
            var page = 1;
            page++;
            var items = _items.ToPageList(page, DEFAULT_PAGE_SIZE);
            Assert.AreEqual(false, items.IsFirstPage);
        }


        [TestMethod]
        public void Can_MoveLast()
        {
            var max = 4;
            var items = _items.ToPageList(max, DEFAULT_PAGE_SIZE);
            Assert.AreEqual(true, items.IsLastPage);
        }

        [TestMethod]
        public void Page_Display_NextPage()
        {
            var number = _items.ToPageList(5, DEFAULT_PAGE_SIZE).PageNext;
            Assert.AreEqual(5,number);
        }

        [TestMethod]
        public void Page_Display_PreviousPage()
        {
            var number = _items.ToPageList(1, DEFAULT_PAGE_SIZE).PagePrevious;
            Assert.AreEqual(1, number);
        }

    }
}
