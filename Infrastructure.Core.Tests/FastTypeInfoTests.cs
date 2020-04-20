using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Infrastructure.Core.Utils;

namespace Infrastructure.Core.Tests
{
    [TestClass]
    public class FastTypeInfoTests
    {
        [TestMethod]
        public void Properties_MoreZero_IsTrue()
        {
            // arrange
            var props = FastTypeInfo<HasIdBaseTest>.PublicProperties;
            // act

            // assert
            Assert.IsTrue(props.Length > 0);
        }

        [TestMethod]
        public void Properties_One_IsTrue()
        {
            // arrange
            var props = FastTypeInfo<HasIdBaseTest>.PublicProperties;
            // act

            // assert
            Assert.IsTrue(props.Length.Equals(1));
        }
    }
}
