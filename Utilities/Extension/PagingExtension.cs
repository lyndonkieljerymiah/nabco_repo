using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper.Paging;

namespace Utilities.Extension
{
    public static class PagingExtension
    {
        public static IPageList<T> ToPageList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            return new PageList<T>(source,pageNumber,pageSize);
        }

        public static IPageList<T> ToPageList<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            return new PageList<T>(source, pageNumber, pageSize);
        }



    }
}
