using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NabcoPortal.Models;

namespace NabcoPortal.ViewModel
{
    public class ItemTableViewModel
    {
        public ItemTableViewModel()
        {   
            this.ItemViewModels = new List<ItemViewModel>();
        }
        
        public IEnumerable<ItemViewModel> ItemViewModels { get; set; }

        public Pagination Pagination
        {
            get
            {
                return new Pagination(CurrentPage, PageSize, TotalCount);
            }
        }

        public int CurrentPage { get; set; }
        public int TotalCount { private get; set; }
        public int PageSize { private get; set; }





        
    }
}