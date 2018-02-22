using System.Web.Mvc;
using NUnit.Framework;
using TestApp;
using TestApp.Controllers;

namespace TestApp.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void TestHomeController_Index_ReturnsIndexViewWhen_Called()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult indexViewResult = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(indexViewResult);
        }
    }
}

