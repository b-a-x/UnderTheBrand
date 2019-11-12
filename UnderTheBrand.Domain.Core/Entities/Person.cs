using System;
using PommaLabs.Thrower;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Values;

namespace UnderTheBrand.Domain.Core.Entities
{
    public class Person : EntityObject
    {
        protected Person() { }

        public Person(PersonalName personalName, Age age): base(Guid.NewGuid())
        {
            Raise.ArgumentNullException.IfIsNull(personalName, nameof(personalName));
            Raise.ArgumentNullException.IfIsNull(age, nameof(age));

            Age = age;
            PersonalName = personalName;
        }

        public PersonalName PersonalName { get; set; }

        public Age Age { get; set; }
    }
}
