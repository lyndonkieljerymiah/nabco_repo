using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NabcoPortal.Models
{
    public class Pagination
    {


        
        

        public int PageCount { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }

        public bool HasPreviousPage { get; private set; }
        public bool HasNextPage { get; private set; }
        public bool IsFirstPage { get; private set; }
        public bool IsLastPage { get; private set; }

        public int ItemStart { get; private set; }
        public int ItemEnd { get; private set; }


        public int PageIndex { get; private set; }
        public int First { get; private set; }
        public int Previous { get; private set; }
        public int Next { get; private set; }
        public int Last { get; private set; }

        public Pagination(int pageNumber,int pageSize,int sourceCount)
        {
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1");
            if (pageNumber < 1) pageNumber = 1;


            //Paging info
            this.PageSize = pageSize;
            this.PageIndex = pageNumber - 1;
            this.TotalCount = sourceCount;
            this.PageCount = this.TotalCount > 0 ? (int)Math.Ceiling(this.TotalCount / (double)pageSize) : 0;

            //Navigation Info
            this.HasPreviousPage = PageIndex > 0;
            this.HasNextPage = PageIndex < PageCount - 1;
            this.IsFirstPage = PageIndex <= 0;
            this.IsLastPage = PageIndex >= PageCount - 1;

            this.ItemStart = this.PageIndex * this.PageSize + 1;
            this.ItemEnd = Math.Min(this.PageIndex * this.PageSize + this.PageSize, this.TotalCount);

            this.Previous = pageNumber - 1;
            this.Next = pageNumber + 1;
            this.First = 1;
            this.Last = PageCount;

            if (!this.HasPreviousPage)
                this.Previous = First;

            if (!this.HasNextPage)
                this.Next = this.Last;


        }

      
    }
}