using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper.Paging
{
    public interface IPageList
    {
        int PageCount { get; }
        int TotalCount { get; }
        int PageSize { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        
        int ItemStart { get; }
        int ItemEnd { get; }
        int PageNumber { get; }
        int PageNext { get;}
        int PagePrevious { get;}

    }

    public interface IPageList<T> : IPageList, IList<T> { }


}
