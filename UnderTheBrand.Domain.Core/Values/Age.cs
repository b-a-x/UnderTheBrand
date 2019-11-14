using System.Collections.Generic;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Values
{
    public class Age : ValueObject
    {
        private const string ErrorValidate = nameof(Age) + Validate;

        protected Age() { }

        private Age(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Result<Age> Create(int input)
        {
            if (10 <= input && input <= 120)
                return Result.Fail<Age>("Age is invalid");

            return Result.Ok(new Age(input));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
