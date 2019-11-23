using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Tests.Base
{
    [TestClass]
    public class EntityObjectTests
    {
        [TestMethod]
        public void EntityObject_create_empty_constructor()
        {
            // arrange

            // act

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(MemberAccessException), "")]
        public void Entity_create_custom_constructor()
        {
            // arrange
            ConstructorInfo constructor = typeof(EntityObject).GetConstructor(BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.Instance,
                null, types: new[] { typeof(string) }, null);

            // act
            constructor?.Invoke(new object[] {Guid.Empty});


            // assert
        }
    }
}
