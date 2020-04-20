using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Interfaces.Entity;

namespace UnderTheBrand.Domain.Model.Base
{
    public class Entity : HasIdBase<string>, IEntity
    {
    }
}
