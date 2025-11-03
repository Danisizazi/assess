using Microsoft.AspNetCore.Mvc;
using ProductCollection.Model;
using ProductCollection.Services;

namespace ProductCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductService _productService;
        private readonly ILogger _logger;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            _productService = new ProductService();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetById(id);

                if (product is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                validateProperties(product);
                _productService.CreateProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                validateProperties(product);
                _productService.UpdateProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        private void validateProperties(Product product)
        {
            if (product == null)
            {
                throw new Exception("Product cannot be null");
            }
            else if (string.IsNullOrEmpty(product.Name))
            {
                throw new Exception("Product Name is required");
            }
            else if (string.IsNullOrEmpty(product.Description))
            {
                throw new Exception("Product Description is required");
            }
            else if (product.Price <= 0)
            {
                throw new Exception("Product price should be greater than zero");
            }
        }

    }
}
