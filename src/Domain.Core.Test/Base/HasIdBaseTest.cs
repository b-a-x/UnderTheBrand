using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Core.Extensions;
using UnderTheBrand.Domain.Core.Interfaces;

namespace UnderTheBrand.Domain.Core.Test.Base
{
    [TestClass]
    public class HasIdBaseTest
    {
        private readonly Guid _id;
        private readonly HasIdTest _hasId;

        public HasIdBaseTest()
        {
            _id = Guid.NewGuid();
            _hasId = new HasIdTest();
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
            var newHasId = new HasIdTest { Id = _id };
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
            var newHasId = new HasIdTest { Id = Guid.NewGuid() };
            // act

            // assert
            Assert.IsFalse(_hasId.Equals(newHasId));
            Assert.IsTrue(_hasId != newHasId);
        }
    }
}