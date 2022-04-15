using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.Account
{
    public class DeleteAccountRequest
    {
        public Guid? CustomerNo { get; set; }
        public string IdentityNumber { get; set; }
        public Guid AccountNo { get; set; }

    }
}
