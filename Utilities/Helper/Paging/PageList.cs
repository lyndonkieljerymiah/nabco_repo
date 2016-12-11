using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper.Paging
{
    public class PageList<T> : List<T>, IPageList<T> 
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
        public int PageNumber { get; private set; }

        public int PageNext { get; private set; }
        public int PageIndex { get; private set; }
        public int PagePrevious { get; private set; }


        public PageList(IEnumerable<T> source,int pageNumber,int pageSize)
            : this(source.AsQueryable(),pageNumber,pageSize)
        {
            
        }

        public PageList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if(pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1");
            if (source == null)
                source = new List<T>().AsQueryable();
            if (pageNumber < 1) pageNumber = 1;

            
            //Paging info
            this.PageSize = pageSize;
            this.PageIndex = pageNumber - 1;
            this.TotalCount = source.Count();
            this.PageCount = this.TotalCount > 0 ? (int)Math.Ceiling(this.TotalCount/(double) pageSize) : 0;

            


            //Navigation Info
            this.HasPreviousPage = PageIndex > 0;
            this.HasNextPage = PageIndex < PageCount - 1;
            this.IsFirstPage = PageIndex <= 0;
            this.IsLastPage = PageIndex >= PageCount - 1;

            this.ItemStart = this.PageIndex * this.PageSize + 1;
            this.ItemEnd = Math.Min(this.PageIndex * this.PageSize + this.PageSize, this.TotalCount);

            this.PagePrevious = pageNumber - 1;
            this.PageNext = pageNumber + 1;

            if (!this.HasPreviousPage)
                this.PagePrevious = 1;

            if (!this.HasNextPage)
                this.PageNext = this.PageCount;


            //If Source is Empty
            if (TotalCount <= 0)
                return;

            int totalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            if (PageIndex >= totalPages)
                AddRange(source.Skip((totalPages - 1) * PageSize).Take(PageSize));
            else
                AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }


    }
}
