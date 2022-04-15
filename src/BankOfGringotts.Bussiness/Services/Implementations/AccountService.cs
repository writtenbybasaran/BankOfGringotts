using BankOfGringotts.Common.Helpers.RepoHelper;
using BankOfGringotts.Model;
using BankOfGringotts.Contracts.Requests.Account;
using BankOfGringotts.Contracts.Responses.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BankOfGringotts.Common.Exceptions;
using AutoMapper;

namespace BankOfGringotts.Bussiness.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<bool> DeleteAccount(DeleteAccountRequest request)
        {
            var account = (await _repository.Account.FindByCondition(x => x.Id.Equals(request.AccountNo))).FirstOrDefault();

            if (account == null)
                throw new NotFoundException();

            await _repository.Account.Delete(account);

            return false;
        }

        public async Task<AccountResponse> GetAccount(GetAccountRequest request)
        {

            var account = (await _repository.Account.FindByCondition(x => x.Id.Equals(request.AccountNo))).FirstOrDefault();

            if (account == null)
                throw new NotFoundException();

            var response = _mapper.Map<AccountResponse>(account);

            return response;
        }

        public async Task<AccountCollectionResponse> GetAccountList(GetAccountCollectionRequest request)
        {
            var customer = (await _repository.Customer.FindByCondition(x => x.Id.Equals(request.CustomerNo),"Accounts")).FirstOrDefault();

            if (customer.Accounts == null || customer.Accounts.Count==0)
                throw new NotFoundException();

            var accountsAbstracts = _mapper.Map<List<AccountAbstract>>(customer.Accounts);

            return new AccountCollectionResponse() { AccountAbstracts = accountsAbstracts };
        }

        public async Task<AccountResponse> PostAccount(PostAccountRequest request)
        {

            var customer = (await _repository.Customer.FindByCondition(x => x.Id.Equals(request.CustomerNo))).FirstOrDefault();

            if (customer == null)
                throw new NotFoundException();

            var newAccount = new Accounts();
            customer.Accounts.Add(newAccount);
            customer.LastActivityDate = DateTime.Now;

            await _repository.Customer.Update(customer);
            _repository.Complete();

            var response = _mapper.Map<AccountResponse>(newAccount);

            return response;

        }
    }
}
