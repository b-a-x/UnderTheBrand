using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Presentation.Server.Controllers;

namespace UnderTheBrand.Presentation.Server.Tests.Controllers
{
    [TestClass]
    public class BaseControllerTests
    {
        [TestMethod]
        public void BaseController_Attribute_True()
        {
            // arrange
            bool isApiControllerAttribute = false;
            bool isRouteAttribute = false;
            bool isControllerAttribute = false;
            object[] attributes = typeof(BaseController).GetCustomAttributes(true);

            // act
            foreach (object item in attributes)
            {
                switch (item)
                {
                    case ApiControllerAttribute _:
                        isApiControllerAttribute = true;
                        break;
                    case RouteAttribute _:
                        isRouteAttribute = true;
                        break;
                    case ControllerAttribute _:
                        isControllerAttribute = true;
                        break;
                }
            }

            // assert
            Assert.AreEqual(attributes.Length, 3);
            Assert.IsTrue(isApiControllerAttribute);
            Assert.IsTrue(isRouteAttribute);
            Assert.IsTrue(isControllerAttribute);
        }
    }
}
