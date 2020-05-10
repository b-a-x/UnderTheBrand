using UnderTheBrand.Domain.Model.Entities;

namespace UnderTheBrand.Domain.Model.Interfaces
{
    public interface IPersonRepository
    {
        Person[] GetAll();
    }
}