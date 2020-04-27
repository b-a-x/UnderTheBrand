using System.Collections.Generic;

namespace UnderTheBrand.Domain.ValueObject.Values
{
    public class Age : Core.Base.ValueObject
    {
        protected Age() { }

        private Age(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Result<Age> Create(int value)
        {
            if (18 > value && value > 120)
                return Result.Fail<Age>("Age is invalid");

            return Result.Ok(new Age(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
