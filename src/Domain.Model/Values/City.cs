﻿using System.Collections.Generic;

namespace UnderTheBrand.Domain.Model.Values
{
    public sealed class City : Base.ValueObject
    {
        public string Name { get; }
        public bool IsEnabled { get; }

        public City(string name, bool isEnabled)
        {
            this.Name = name;
            this.IsEnabled = isEnabled;
        }

        public static Result<City> Create(string name, bool value)
        {
            return Result.Ok(new City(name, value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}