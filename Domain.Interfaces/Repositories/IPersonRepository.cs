using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Interfaces.Entity;

namespace UnderTheBrand.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        PagedResponse<IPerson> GetList();
    }
}
