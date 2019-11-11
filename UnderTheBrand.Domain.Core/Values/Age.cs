using System;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Values
{
    public class Age : ValueObject
    {
        private const string ErrorValidate = nameof(Age) + Validate;

        protected Age() { }

        public Age(int value)
        {
            if (!IsValid(value)) throw new ArgumentException(ErrorValidate);
            Value = value;
        }

        public int Value { get; }

        public static bool IsValid(int value)
        {
            return 10 <= value && value <= 120;
        }

        public override bool Equals(object obj)
        {
            return obj is Age other && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
