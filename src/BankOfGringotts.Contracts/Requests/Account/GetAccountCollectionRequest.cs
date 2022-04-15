using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.Account
{
    public class GetAccountCollectionRequest
    {
        public Guid CustomerNo { get; set; }
        
    }
}
