using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Base
{
    public class ValueObject : IValueObject
    {
        protected const string Validate = " is not valid";

        protected ValueObject() { }
    }
}
