using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Interface.Entities;

namespace UnderTheBrand.Domain.Interface.Repositories
{
    public interface IPersonRepository
    {
        PagedResponse<IPerson> GetList();
    }
}