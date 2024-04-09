using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExample.Model;

namespace UnitTesting.contracts
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddNewProduct(Product p);
        Task<bool> Delete(int id);
        Task Update(Product p);
    }

}
