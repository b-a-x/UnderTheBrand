using System;
using System.Collections.Generic;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Values
{
    public class Age : ValueObject, IValueObjectValidation<int>
    {
        private const string ErrorValidate = nameof(Age) + Validate;

        protected Age() { }

        public Age(int value)
        {
            if (!IsValid(value)) throw new ArgumentException(ErrorValidate);
            Value = value;
        }

        public int Value { get; }

        public bool IsValid(int value)
        {
            return 10 <= value && value <= 120;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
