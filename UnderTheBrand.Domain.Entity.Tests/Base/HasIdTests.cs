using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Core.Interfaces.Base;
using UnderTheBrand.Domain.Entity.Base;

namespace UnderTheBrand.Domain.Entity.Tests.Base
{
    [TestClass]
    public class HasIdTests
    {
        private readonly string _id;
        private readonly HasId _hasId;

        public HasIdTests()
        {
            _id = Guid.NewGuid().ToString();
            _hasId = new HasId();
        }

        [TestMethod]
        public void HasId_IsNew_True()
        {
            // arrange
            var hasId = new HasId();
            // act

            // assert
            Assert.IsTrue(hasId.IsNew());
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
            Assert.IsTrue(((IHasId)_hasId).Id?.Equals(_id) == true);
        }

        [TestMethod]
        public void HasId_TwoObject_AreEqual()
        {
            // arrange
            _hasId.Id = _id;
            var newHasId = new HasId { Id = _id };
            
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
            var newHasId = new HasId { Id = Guid.NewGuid().ToString() };

            // act

            // assert
            Assert.IsFalse(_hasId.Equals(newHasId));
            Assert.IsTrue(_hasId != newHasId);
        }
    }
}
