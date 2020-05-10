using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Model.Extensions;
using UnderTheBrand.Domain.Model.Interfaces;

namespace UnderTheBrand.Domain.Model.Test.Base
{
    [TestClass]
    public class HasIdBaseTest
    {
        private readonly Guid id;
        private readonly HasIdTest hasId;

        public HasIdBaseTest()
        {
            id = Guid.NewGuid();
            hasId = new HasIdTest();
        }

        [TestMethod]
        public void HasId_IsNew_True()
        {
            // arrange
            // act

            // assert
            Assert.IsTrue(hasId.IsNew());
        }

        [TestMethod]
        public void HasId_IsNew_False()
        {
            // arrange
            hasId.Id = id;
            // act

            // assert
            Assert.IsFalse(hasId.IsNew());
        }

        [TestMethod]
        public void HasId_ObjectAndTypeId_AreEqual()
        {
            // arrange
            hasId.Id = id;
            // act

            // assert
            Assert.IsTrue(((IHasId)hasId).Id.Equals(id));
        }

        [TestMethod]
        public void HasId_TwoObject_AreEqual()
        {
            // arrange
            hasId.Id = id;
            var newHasId = new HasIdTest { Id = id };
            // act

            // assert
            Assert.IsTrue(hasId.Equals(newHasId));
            Assert.IsTrue(hasId == newHasId);
        }

        [TestMethod]
        public void HasId_TwoObject_NotEqual()
        {
            // arrange
            hasId.Id = id;
            var newHasId = new HasIdTest { Id = Guid.NewGuid() };
            // act

            // assert
            Assert.IsFalse(hasId.Equals(newHasId));
            Assert.IsTrue(hasId != newHasId);
        }
    }
}