using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.contracts;
using UnitTestingExample.BL;
using UnitTestingExample.Controllers;
using UnitTestingExample.Model;

namespace UnitTesting.TestsMethods
{
    public class ProductssControllerTest
    {
        private Mock<IProductsRepository> productsRepositoryMock;
        private List<Product> products;

        [SetUp]
        public void Setup()
        {
            productsRepositoryMock = new Mock<IProductsRepository>();
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Bread", Price = 30, Description = "1" });
            products.Add(new Product { Id = 2, Name = "Milk", Price = 10, Description = "2" });
            products.Add(new Product { Id = 3, Name = "Cream", Price = 20, Description = "3" });
            products.Add(new Product { Id = 4, Name = "Tomato", Price = 40, Description = "4" });
        }

        [Test]
        public void TestById()
        {
            //act
            productsRepositoryMock.Setup(a => a.GetProductById(3)).Returns(Task.FromResult(products.Where(p=>p.Id==3).FirstOrDefault()));
            var controller = new ProductsController(null,productsRepositoryMock.Object);
            var result = controller.Get(3).Result;
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsTrue(((Product)(okResult.Value)).Id == 3);
        }

        [Test]
        public void TestGetAll()
        {
            //act
            productsRepositoryMock.Setup(a => a.GetAllProducts()).Returns(Task.FromResult(products));
            var controller = new ProductsController(null, productsRepositoryMock.Object);
            var result = controller.Get().Result;
            var okResult = result as OkObjectResult;
            var productList = okResult.Value as List<Product>;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsTrue(productList.Count == 4);
        }
    }
}
