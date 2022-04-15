using BankOfGringotts.Contracts.Requests.AccountTransaction;
using BankOfGringotts.Contracts.Responses.AccountTransaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankOfGringotts.Common.Helpers.RepoHelper;
using System.Linq;
using BankOfGringotts.Common.Exceptions;
using BankOfGringotts.Contracts.Responses.Account;
using BankOfGringotts.Model;

namespace BankOfGringotts.Bussiness.Services.Implementations
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public AccountTransactionService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AccountTransactionResponse> GetAccountTransaction(GetAccountTransactionRequest request)
        {
            var accountTransaction = (await _repository.AccountTransaction.FindByCondition(x => x.Id.Equals(request.TransactionId))).FirstOrDefault();

            if (accountTransaction == null)
                throw new NotFoundException();

            var response = _mapper.Map<AccountTransactionResponse>(accountTransaction);

            return response;
        }

        public async Task<AccountTransactionCollectionResponse> GetAccountTransactionList(GetAccountTransactionCollectionRequest request)
        {
            var accountTransactionList = (await _repository.AccountTransaction.FindByCondition(x => x.AccountId.Equals(request.AccountNo))).ToList();

            if (accountTransactionList == null)
                throw new NotFoundException();

            var response = _mapper.Map<List<AccountTransactionAbstractResponse>>(accountTransactionList);

            return new AccountTransactionCollectionResponse(){TransactionList = response};
        }

        public async Task<AccountTransactionResponse> PostAccountTransaction(PostAccountTransactionRequest request)
        {
            var account = (await _repository.Account.FindByCondition(x => x.Id.Equals(request.AccountNo), "AccountTransactions")).FirstOrDefault();

            if (account == null)
                throw new NotFoundException("Account Not Found");

            var newAccountTransaction = new AccountTransactions(){TransactionValue = request.TransactionValue};
            account.AccountTransactions.Add(newAccountTransaction);
            account.Balance = account.Balance +request.TransactionValue;

            await _repository.Account.Update(account);
            _repository.Complete();

            var response = _mapper.Map<AccountTransactionResponse>(newAccountTransaction);

            return response;
        }
    }
}
