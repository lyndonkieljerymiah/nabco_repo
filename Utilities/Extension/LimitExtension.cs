using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Extension
{
    public static class LimitExtension
    {

        public static IQueryable<T> Limit<T>(this IQueryable<T> queryable, int pageNumber, int pageSize,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1");
            if (pageNumber < 1) pageNumber = 1;

            queryable = orderBy(queryable);
            return queryable
                .Skip((pageNumber - 1)*pageSize)
                .Take(pageSize);
        }
    }
}
