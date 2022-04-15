using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Contracts.Requests.Authorization
{
    public class AuthorizationRequest
    {
        public string ClientName { get; set; }
        public string ClientUser { get; set; }
        public string ClientPassword { get; set; }
    }
}
