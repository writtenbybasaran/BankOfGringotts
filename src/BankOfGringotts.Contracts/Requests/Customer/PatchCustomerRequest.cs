using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.Customer
{
    public class PatchCustomerRequest
    {
        public string IdentityNumber { get; set; }
        public Guid CustomerNo { get; set; }
        public string CustomerKey { get; set; }    
    }
}
