using System.Collections.Generic;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Core.Interfaces;
using UnderTheBrand.Domain.Model.Entities;

namespace UnderTheBrand.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IReadOnlyCollection<Person>> GetListSortPersonalName();

        IReadOnlyCollection<Person> GetListSortId();
    }
}
