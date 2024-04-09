using UnitTesting.contracts;
using UnitTestingExample.Model;
using UnitTestingExample.Models;

namespace UnitTestingExample.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddNewProduct(Product p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<bool> Delete(int id)
        {
            var productToDelete = _context.Products.ToList().Where(p => p.Id == id).FirstOrDefault();
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(_context.Products.ToList());
        }

        public Task<Product> GetProductById(int id)
        {
            return Task.FromResult(_context.Products.ToList().Where(p => p.Id == id).FirstOrDefault());
        }

        public Task Update(Product s)
        {
            _context.Products.Update(s);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }

    }
