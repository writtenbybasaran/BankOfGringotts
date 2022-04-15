using BankOfGringotts.Contracts.Requests.AccountTransaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using BankOfGringotts.Bussiness.Services;
using BankOfGringotts.Contracts.Responses.AccountTransaction;
using Microsoft.AspNetCore.Authorization;

namespace BankOfGringotts.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransactionController : ControllerBase
    {
        private readonly IAccountTransactionService _accountTransactionService;
        public AccountTransactionController(IAccountTransactionService accountTransactionService)
        {
            _accountTransactionService = accountTransactionService;
        }


        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] PostAccountTransactionRequest request)
        {
          
            var response = await _accountTransactionService.PostAccountTransaction(request); 

            return StatusCode((int)HttpStatusCode.Created, response);
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] GetAccountTransactionRequest request)
        {
            var response =await _accountTransactionService.GetAccountTransaction(request);

            return StatusCode((int)HttpStatusCode.OK, response);
        }
       

    }
}
