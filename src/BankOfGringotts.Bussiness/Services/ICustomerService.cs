using BankOfGringotts.Contracts.Requests.Customer;
using BankOfGringotts.Contracts.Responses.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Bussiness.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponse> GetCustomer(GetCustomerRequest request);
        Task<CustomerResponse> PostCustomer(PostCustomerRequest request);
        Task<bool> PatchCustomer(PostCustomerRequest request);
    }
}
