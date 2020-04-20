using System.Linq;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Infrastructure.Core.Base;

namespace UnderTheBrand.Infrastructure.Core.Extensions
{
    public static class SorterExtensions
    {
        public static IOrderedQueryable<T> Order<T>(this Sorter<T> sorter, IQueryable<T> queryable)
            => sorter.PropertyName != null
                ? queryable.OrderBy(sorter.PropertyName)
                : (IOrderedQueryable<T>)((dynamic)queryable).OrderBy(sorter.Expression);
    }
}
