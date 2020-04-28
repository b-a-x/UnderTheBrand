using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Interface.Entities;

namespace UnderTheBrand.Domain.Model.Base
{
    public class Entity : HasIdBase<string>, IEntity
    {
    }
}