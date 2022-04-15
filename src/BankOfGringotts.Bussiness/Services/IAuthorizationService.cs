using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Contracts.Requests.Authorization;
using BankOfGringotts.Contracts.Responses.Authorization;

namespace BankOfGringotts.Bussiness.Services
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResponse> GetAccessToken(AuthorizationRequest authorizationRequest);
    }
}
