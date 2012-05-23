using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Gojo.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int currentPage, int defaultPage, int pageSize)
        {
            return query
                .Skip((currentPage - defaultPage) * pageSize)
                .Take(pageSize);
        }

    }
}
