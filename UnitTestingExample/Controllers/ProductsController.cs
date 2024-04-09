using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTesting.contracts;
using UnitTestingExample.Model;
using UnitTestingExample.Models;

namespace UnitTestingExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository _repository;
        private AppDbContext _context;
        public ProductsController(AppDbContext context, IProductsRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public async Task<IActionResult> Get()
        {
            var products = await _repository.GetAllProducts();
            return Ok(products);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _repository.GetProductById(id);
            return product == null ? NotFound() : Ok(product);
        }
    }
}
