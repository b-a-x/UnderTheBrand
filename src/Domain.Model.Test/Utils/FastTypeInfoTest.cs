using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.Model.Test.Base;
using UnderTheBrand.Domain.Model.Utils;

namespace UnderTheBrand.Domain.Model.Test.Utils
{
    [TestClass]
    public class FastTypeInfoTest
    {
        [TestMethod]
        public void Properties_MoreZero_IsTrue()
        {
            // arrange
            var props = FastTypeInfo<HasIdTest>.PublicProperties;
            // act

            // assert
            Assert.IsTrue(props.Length > 0);
        }

        [TestMethod]
        public void Properties_One_IsTrue()
        {
            // arrange
            var props = FastTypeInfo<HasIdTest>.PublicProperties;
            // act

            // assert
            Assert.IsTrue(props.Length.Equals(1));
        }
    }
}