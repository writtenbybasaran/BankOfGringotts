using BankOfGringotts.Contracts.Requests.Customer;
using BankOfGringotts.Contracts.Responses.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankOfGringotts.Common.Helpers.RepoHelper;
using System.Linq;
using System.Runtime.CompilerServices;
using BankOfGringotts.Common.Exceptions;
using BankOfGringotts.Model;

namespace BankOfGringotts.Bussiness.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repository;
        public CustomerService(IMapper mapper, IUnitOfWork repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<CustomerResponse> GetCustomer(GetCustomerRequest request)
        {
            var customer = (await _repository.Customer.FindByCondition(x => x.IdentityNumber.Equals(request.IdentityNumber))).FirstOrDefault();

            if (customer == null)
                throw new NotFoundException();

            var response = _mapper.Map<CustomerResponse>(customer);

            return response;
        }

        public async Task<bool> PatchCustomer(PostCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerResponse> PostCustomer(PostCustomerRequest request)
        {
            var customer = _mapper.Map<Customers>(request);

            await _repository.Customer.Create(customer);

            _repository.Complete();

            var response = _mapper.Map<CustomerResponse>(customer);

            return response;
        }
    }
}
