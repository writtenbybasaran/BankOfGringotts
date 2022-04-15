using System.Net;
using System.Threading.Tasks;
using BankOfGringotts.Bussiness.Services;
using BankOfGringotts.Contracts.Requests.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankOfGringotts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
      
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
          
        }

        [HttpPost]
        public async Task<IActionResult> GetAccessToken([FromBody] AuthorizationRequest authorizationRequest)
        {

            var result = await _authorizationService.GetAccessToken(authorizationRequest);

            return StatusCode((int)HttpStatusCode.OK, result);
        }

    }
}
