using Microsoft.AspNetCore.Mvc;
using CustomerApp.Model;
using CustomerApp.Services;

namespace CustomerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerService _customerService;
        private readonly ILogger _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
            _customerService = new CustomerService();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
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
                var customer = _customerService.GetById(id);

                if (customer is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                validateProperties(customer);
                _customerService.CreateCustomer(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Customer customer)
        {
            try
            {
                validateProperties(customer);
                _customerService.UpdateCustomer(customer);
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
                _customerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        private void validateProperties(Customer customer)
        {
            if (customer == null)
            {
                throw new Exception("Customer cannot be null");
            }
            else if (string.IsNullOrEmpty(customer.Name))
            {
                throw new Exception("Name is required");
            }
            else if (string.IsNullOrEmpty(customer.Email))
            {
                throw new Exception("email is required");
            }
            else if (string.IsNullOrEmpty(customer.PhoneNumber))
            {
                throw new Exception("Phone number is required should be greater than zero");
            }
        }

    }
}
