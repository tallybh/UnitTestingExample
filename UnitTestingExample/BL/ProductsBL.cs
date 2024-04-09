using Microsoft.EntityFrameworkCore;
using UnitTesting.contracts;
using UnitTestingExample.Model;

namespace UnitTestingExample.BL
{
    public class ProductsBL
    {
        private readonly IProductsRepository _repository;

        public ProductsBL(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }
    }
}
