using Microsoft.AspNetCore.Mvc;
using SimpleApiExcercise.Repositories.DAL.Models;
using SimpleApiExcercise.Services;

namespace SimpleApiExcercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        //[HttpGet(Name = "GetAllCustomers")]
        [HttpGet("getCustomers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            _logger.LogInformation("Service call executing :: GetAllCustomers");
            return await _customerService.GetAllCustomers();
        }
    }
}