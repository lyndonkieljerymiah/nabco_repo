using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Owin.Security.Provider;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ViewModel
{


    public class ItemViewModel
    {

        private List<SelectListItem> _categories;


        public static IEnumerable<ItemViewModel> CreateRange(IEnumerable<Item> items)
        {
            var mvs = AutoMapper.Mapper.Map<IEnumerable<ItemViewModel>>(items);
            return mvs;
        }

        public static ItemViewModel CreateWithItem(Item item,IEnumerable<Category> categories)
        {
            var mvItem = AutoMapper.Mapper.Map<ItemViewModel>(item);

            mvItem.AddCategories("0", "--Select Categories--", true);
            foreach (var category in categories)
            {
                mvItem.AddCategories(category.Id.ToString(), category.Name);
            }
            
            return mvItem;
        }

        public static ItemViewModel CreateEmpty(IEnumerable<Category> categories)
        {
            var mvItem = new ItemViewModel();
            
            mvItem.AddCategories("0", "--Select Categories--", true);
            foreach (var category in categories)
            {
                mvItem.AddCategories(category.Id.ToString(), category.Name);
            }
            
            return mvItem;
        }

        public ItemViewModel()
        {
            ItemStatusInfo = new ItemStatusInfo(0,0,0,0,0,0,0);
            this.Id = 0;
            _categories = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Required]
        public string ModelNo { get; set; }

        [Required]
        public string FinishingCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Composition { get; set; }

        public string Description { get { return Composition + " " + ModelNo + " " + FinishingCode; } }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string UOM { get; set; }

        public bool IsActive { get; private set; }

        public string ActionUrl { get; set; }

        public ItemStatusInfo ItemStatusInfo { get; set; }

        public IEnumerable<SelectListItem> Categories
        {
            get { return _categories; }
        }


        public void AddCategories(string key,string value,bool isSelected = false)
        {
            this._categories.Add(new SelectListItem { Value = key,Text = value, Selected = isSelected});
        }


    }

    public class ItemStatusInfo
    {

        public ItemStatusInfo(int orderQty,int readyForShippingQty,
            int woodWorkingQty,int curvingQty,int assemblyQty,
            int finishingQty,int shippedQty)
        {
            this.OrderQty = orderQty;
            this.ReadyForShippingQty = readyForShippingQty;
            this.WoodWorkingQty = woodWorkingQty;
            this.CurvingQty = curvingQty;
            this.AssemblyQty = assemblyQty;
            this.FinishingQty = finishingQty;
            this.ShippedQty = shippedQty;
        }

        public int OrderQty { get; private set; }

        public int ReadyForShippingQty { get; private set; }

        public int WoodWorkingQty { get; private set; }

        public int CurvingQty { get; private set; }

        public int AssemblyQty { get; private set; }

        public int FinishingQty { get; private set; }

        public int ShippedQty { get; private set; }

    }


    class CategoryViewModel
    {
        

    }
}