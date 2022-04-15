using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Responses.Customer
{
    public class CustomerResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CustomerNo { get; set; }
        public string CustomerKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}
