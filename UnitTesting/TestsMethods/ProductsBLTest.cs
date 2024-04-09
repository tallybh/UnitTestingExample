using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.contracts;
using UnitTestingExample.BL;
using UnitTestingExample.Model;

namespace UnitTesting.TestsMethods
{
    public class ProductsBLTest
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
        public void Test1()
        {
            //act
            productsRepositoryMock.Setup(a => a.GetAllProducts()).Returns(Task.FromResult(products));
            var bl = new ProductsBL(productsRepositoryMock.Object);
            var productsList = bl.GetAllProducts().Result;
            Assert.IsTrue(productsList.Count == 4);
        }
    }
}
