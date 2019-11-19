using System.Collections.Generic;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Business.Entities;

namespace UnderTheBrand.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IEntityRepository<Person>
    {
        Task<IReadOnlyCollection<Person>> GetList();
    }
}
