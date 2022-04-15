using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.Customer
{
    public class PostCustomerRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string CustomerKey { get; set; }
    }
}
