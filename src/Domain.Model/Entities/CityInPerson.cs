﻿using System;
using UnderTheBrand.Domain.Model.Values;

namespace UnderTheBrand.Domain.Model.Entities
{
    public class CityInPerson : Base.Entity
    {
        protected CityInPerson() { }

        public CityInPerson(City city, Person person)
        {
            this.City = city ?? throw new ArgumentNullException(nameof(city));
            this.Person = person ?? throw new ArgumentNullException(nameof(person));
        }

        public City City { get; }

        public Person Person { get; }
    }
}