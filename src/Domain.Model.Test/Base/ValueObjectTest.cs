using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Model.Base;

namespace UnderTheBrand.Domain.Model.Test.Base
{
    [TestClass]
    public class ValueObjectTest
    {
        private readonly string value;
        private readonly ValueObject valueObject;
        public ValueObjectTest()
        {
            value = Guid.NewGuid().ToString();
            valueObject = new ObjectTest(value);
        }

        [TestMethod]
        public void HasId_TwoObject_AreEqual()
        {
            // arrange
            var newValueObject = new ObjectTest(value);
            // act

            // assert
            Assert.IsTrue(valueObject.Equals(newValueObject));
            Assert.IsTrue(valueObject == newValueObject);
        }

        [TestMethod]
        public void HasId_TwoObject_NotEqual()
        {
            // arrange
            var newValueObject = new ObjectTest("NotEqual");
            // act

            // assert
            Assert.IsFalse(valueObject.Equals(newValueObject));
            Assert.IsTrue(valueObject != newValueObject);
        }

        private class ObjectTest : ValueObject
        {
            protected ObjectTest() { }

            internal ObjectTest(string value)
            {
                Value = value;
            }

            private string Value { get; }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Value;
            }
        }
    }
}