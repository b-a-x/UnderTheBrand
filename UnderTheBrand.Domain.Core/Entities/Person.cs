using System;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Values;

namespace UnderTheBrand.Domain.Core.Entities
{
    public class Person : EntityObject
    {
        protected Person() { }

        public Person(PersonalName personalName, Age age): base(Guid.NewGuid())
        {
            PersonalName = personalName ?? throw new ArgumentNullException(nameof(personalName));
            Age = age ?? throw new ArgumentNullException(nameof(age));
        }

        public PersonalName PersonalName { get; set; }

        public Age Age { get; set; }
    }
}
