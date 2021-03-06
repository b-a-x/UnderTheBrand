﻿using System.Collections.Generic;

namespace UnderTheBrand.Domain.Model.Values
{
    public class Age : Base.ValueObject
    {
        protected Age() { }

        private Age(int value)
        {
            this.Value = value;
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