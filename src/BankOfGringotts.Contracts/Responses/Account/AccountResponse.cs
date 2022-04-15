using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Responses.Account
{
    public class AccountResponse
    {
        public Guid AccountNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastActivityDate { get; set; }

    }
}
