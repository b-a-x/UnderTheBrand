using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Model.Base;

namespace UnderTheBrand.Domain.Model.Test.Base
{
    [TestClass]
    public class ValueObjectTest
    {
        private readonly string _value;
        private readonly ValueObject _valueObject;
        public ValueObjectTest()
        {
            _value = Guid.NewGuid().ToString();
            _valueObject = new ObjectTest(_value);
        }

        [TestMethod]
        public void HasId_TwoObject_AreEqual()
        {
            // arrange
            var newValueObject = new ObjectTest(_value);
            // act

            // assert
            Assert.IsTrue(_valueObject.Equals(newValueObject));
            Assert.IsTrue(_valueObject == newValueObject);
        }

        [TestMethod]
        public void HasId_TwoObject_NotEqual()
        {
            // arrange
            var newValueObject = new ObjectTest("NotEqual");
            // act

            // assert
            Assert.IsFalse(_valueObject.Equals(newValueObject));
            Assert.IsTrue(_valueObject != newValueObject);
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