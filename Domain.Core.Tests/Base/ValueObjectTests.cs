using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Core.Tests.Base
{
    [TestClass]
    public class ValueObjectTests
    {
        private readonly string _value;
        private readonly ValueObject _valueObject;
        public ValueObjectTests()
        {
            _value = Guid.NewGuid().ToString();
            _valueObject = new ValueObjectTest(_value);
        }

        [TestMethod]
        public void HasId_TwoObject_AreEqual()
        {
            // arrange
            var newValueObject = new ValueObjectTest(_value);
            // act

            // assert
            Assert.IsTrue(_valueObject.Equals(newValueObject));
            Assert.IsTrue(_valueObject == newValueObject);
        }

        [TestMethod]
        public void HasId_TwoObject_NotEqual()
        {
            // arrange
            var newValueObject = new ValueObjectTest("NotEqual");
            // act

            // assert
            Assert.IsFalse(_valueObject.Equals(newValueObject));
            Assert.IsTrue(_valueObject != newValueObject);
        }

        private class ValueObjectTest : ValueObject
        {
            protected ValueObjectTest() { }

            internal ValueObjectTest(string value)
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
