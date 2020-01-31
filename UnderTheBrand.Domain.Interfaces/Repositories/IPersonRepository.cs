using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Core.Interfaces;
using UnderTheBrand.Domain.Entity.Entities;

namespace UnderTheBrand.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IEntityRepository<Person>
    {
        Task<IReadOnlyCollection<Person>> GetListSortPersonalName();

        IReadOnlyCollection<Person> GetListSortId();
    }
}
