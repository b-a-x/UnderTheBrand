using System.Collections.Generic;
using UnderTheBrand.Domain.Model.Entities;

namespace UnderTheBrand.Domain.Model.Interfaces
{
    public interface IPersonRepository
    {
        IReadOnlyCollection<Person> GetList();
    }
}