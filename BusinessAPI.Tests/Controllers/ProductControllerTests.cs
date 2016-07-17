using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BusinessServices;
using BusinessEntities;

namespace BusinessAPI.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            //Arrange
            var controller = new ProductController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            string expectedResult = "OK";

            //Act
            var realResult = controller.Get()?.StatusCode.ToString();

            //Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod()]
        public void GetByFilterTest()
        {
            //Arrange
            var controller = new ProductController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            decimal priceStart = 10;
            decimal priceEnd = 1000;
            string expectedResult = "OK";

            //Act
            var realResult = controller.GetByFilter(priceStart, priceEnd, new ProductEntity())?.StatusCode.ToString();

            //Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod()]
        public void PostTest()
        {
            //Arrange
            var controller = new ProductController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            string expectedResult = "OK";

            //Act
            var realResult = controller.Post(new ProductEntity()
            {
                Id = 4,
                Name = "YSA",
                Color = "Grey",
                Size = "19",
                Price = 5000
            })?.StatusCode.ToString();

            //Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod()]
        public void PutTest()
        {
            //Arrange
            var controller = new ProductController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            string expectedResult = "OK";

            //Act
            var realResult = controller.Put(new ProductEntity()
            {
                Id = 3
            })?.StatusCode.ToString();

            //Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            var controller = new ProductController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            string expectedResult = "OK";

            //Act
            var realResult = controller.Delete(new ProductEntity()
            {
                Id = 3
            })?.StatusCode.ToString();

            //Assert
            Assert.AreEqual(expectedResult, realResult);
        }
    }
}