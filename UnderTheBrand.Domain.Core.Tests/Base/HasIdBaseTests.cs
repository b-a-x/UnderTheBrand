using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Core.Interfaces.Base;

namespace UnderTheBrand.Domain.Core.Tests.Base
{
    [TestClass]
    public class HasIdBaseTests
    {
        private readonly string _id;
        private readonly HasIdBaseTest _hasId;

        public HasIdBaseTests()
        {
            _id = Guid.NewGuid().ToString();
            _hasId = new HasIdBaseTest();
        }

        [TestMethod]
        public void HasId_IsNew_True()
        {
            // arrange
            // act

            // assert
            Assert.IsTrue(_hasId.IsNew());
        }

        [TestMethod]
        public void HasId_IsNew_False()
        {
            // arrange
            _hasId.Id = _id;
            // act

            // assert
            Assert.IsFalse(_hasId.IsNew());
        }

        [TestMethod]
        public void HasId_ObjectAndTypeId_AreEqual()
        {
            // arrange
            _hasId.Id = _id;
            // act

            // assert
            Assert.IsTrue(((IHasId)_hasId).Id.Equals(_id));
        }

        [TestMethod]
        public void HasId_TwoObject_AreEqual()
        {
            // arrange
            _hasId.Id = _id;
            var newHasId = new HasIdBaseTest { Id = _id };
            // act

            // assert
            Assert.IsTrue(_hasId.Equals(newHasId));
            Assert.IsTrue(_hasId == newHasId);
        }

        [TestMethod]
        public void HasId_TwoObject_NotEqual()
        {
            // arrange
            _hasId.Id = _id;
            var newHasId = new HasIdBaseTest { Id = Guid.NewGuid().ToString() };
            // act

            // assert
            Assert.IsFalse(_hasId.Equals(newHasId));
            Assert.IsTrue(_hasId != newHasId);
        }
        
        private class HasIdBaseTest : HasIdBase<string>
        {
            internal HasIdBaseTest() { }
        }
    }
}
