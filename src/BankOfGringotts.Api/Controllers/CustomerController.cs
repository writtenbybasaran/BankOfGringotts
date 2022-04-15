using BankOfGringotts.Contracts.Requests.Account;
using BankOfGringotts.Contracts.Requests.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using BankOfGringotts.Bussiness.Services;

namespace BankOfGringotts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] PostCustomerRequest request)
        {

            var response = await _customerService.PostCustomer(request);

            return StatusCode((int)HttpStatusCode.Created, response);
        }


        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] GetCustomerRequest request)
        {
            var response = await _customerService.GetCustomer(request);

            return StatusCode((int)HttpStatusCode.OK, response);
        }

        
    }
}
