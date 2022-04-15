using BankOfGringotts.Bussiness.Services;
using BankOfGringotts.Contracts.Requests.Account;
using BankOfGringotts.Contracts.Responses.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BankOfGringotts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
       

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] PostAccountRequest request)
        {
            var response = await _accountService.PostAccount(request);

            return StatusCode((int)HttpStatusCode.Created, response);
        }


        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] GetAccountRequest request)
        {
            var response = await _accountService.GetAccount(request);

            return StatusCode((int)HttpStatusCode.OK, response);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetList([FromQuery] GetAccountCollectionRequest request)
        {
            var response = await _accountService.GetAccountList(request);

            return StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete([FromBody] DeleteAccountRequest request)
        {
           
            if(await _accountService.DeleteAccount(request))
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
          
        }
    }
}
