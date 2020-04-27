using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Domain.Interfaces.Entity
{
    public interface IPerson : IEntity
    {
        PersonalName PersonalName { get; }
        Age Age { get; }
    }
}
