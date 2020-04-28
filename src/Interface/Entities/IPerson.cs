using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Interface.Entities
{
    public interface IPerson : IEntity
    {
        PersonalName PersonalName { get; }
        Age Age { get; }
    }
}