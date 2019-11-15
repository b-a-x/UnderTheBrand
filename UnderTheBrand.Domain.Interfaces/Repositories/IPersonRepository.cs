using System.Collections.Generic;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Core.Entities;

namespace UnderTheBrand.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IEntityRepository<Person>
    {
        Task<IReadOnlyCollection<Person>> GetList();
    }
}
