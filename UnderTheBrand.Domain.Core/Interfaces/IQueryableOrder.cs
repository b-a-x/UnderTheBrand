using System.Linq;

namespace UnderTheBrand.Domain.Core.Interfaces
{
    public interface IQueryableOrder<T>
    {
        IOrderedQueryable<T> Order(IQueryable<T> queryable);
    }
}
