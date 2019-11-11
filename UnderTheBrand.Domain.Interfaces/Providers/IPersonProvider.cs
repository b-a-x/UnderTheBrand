using System.Collections.Generic;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Core.Entities;

namespace UnderTheBrand.Domain.Interfaces.Providers
{
    public interface IPersonProvider : IEntityObjectProvider<Person>
    {
        Task<IReadOnlyCollection<Person>> GetList();
    }
}
