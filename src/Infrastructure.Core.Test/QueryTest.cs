using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Infrastructure.Core.Extensions;

namespace UnderTheBrand.Tests.Infrastructure.Core.Test
{
    [TestClass]
    public class QueryTest
    {
        private IQueryable<HasIdBaseTest> _hasIdBaseTests;

        [TestInitialize]
        public void Initialize()
        {
            _hasIdBaseTests = new EnumerableQuery<HasIdBaseTest>(CreateHasIdBaseTest());
        }

        private IEnumerable<HasIdBaseTest> CreateHasIdBaseTest()
        {
            return new List<HasIdBaseTest>
            {
                new HasIdBaseTest {Id = Guid.NewGuid()},
                new HasIdBaseTest {Id = Guid.NewGuid()},
                new HasIdBaseTest {Id = Guid.NewGuid()},
                new HasIdBaseTest {Id = Guid.NewGuid()},
                new HasIdBaseTest {Id = Guid.NewGuid()},
                new HasIdBaseTest {Id = Guid.NewGuid()},

            };
        }

        [TestMethod]
        public void PagedQuery_FilterAndSort()
        {
            // arrange
            var hasIdBaseTests = _hasIdBaseTests.FilterAndSort(new PagedQuery<HasIdBaseTest>());

            // act
            Guid guidFirst = hasIdBaseTests.First().Id;
            Guid guidLast = hasIdBaseTests.Last().Id;


            // assert
            Assert.IsTrue(guidLast.CompareTo(guidFirst) == -1);
        }
    }
}