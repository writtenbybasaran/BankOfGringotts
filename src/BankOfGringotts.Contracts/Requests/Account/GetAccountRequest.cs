using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.Account
{
    public class GetAccountRequest
    {
        public Guid AccountNo { get; set; }
    }
}
