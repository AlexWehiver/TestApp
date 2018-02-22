using TestApp.Controllers;
using NUnit.Framework;
using System.Web.Mvc;
using Moq;
using TestApp.Repository;
using TestApp.Models;

namespace TestApp.Tests.Controllers
{
    [TestFixture]
    public class PostControllerTest
    {
        Mock<IProductRepository> mockProductRepository;
        ProductController productController;
        Product post;

        [SetUp]
        public void Setup()
        {
            mockProductRepository = new Mock<IProductRepository>();
            productController = new ProductController();
        }

        [Test]
        public void Test_Create_ReturnsCreateView_WhenCalled()
        {
            //Arrange
            var product = new Product();
            mockProductRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(product);

            //Act
            var actual = productController.Create() as ViewResult;

            //Assert
            Assert.AreEqual("Create", actual.ViewName);
        }

        [Test]
        public void Test_Edit_ReturnsHttpNotFoundView_WhenANullProductIdIsPassed()
        {
            //Arrange
            int? x = null;

            //Act
            var actual = productController.Edit(x) as HttpNotFoundResult;

            //Assert
            Assert.IsInstanceOf(typeof(HttpNotFoundResult), actual);
        }

        [Test]
        public void Test_Delete_ReturnsHttpNotFoundView_WhenANullproductIdIsPassed()
        {
            //Arrange
            int? x = null;

            //Act
            var actual = productController.Delete(x) as HttpNotFoundResult;

            //Assert
            Assert.IsInstanceOf(typeof(HttpNotFoundResult), actual);
        }
    }
}
