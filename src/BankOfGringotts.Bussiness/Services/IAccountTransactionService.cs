using BankOfGringotts.Contracts.Requests.AccountTransaction;
using BankOfGringotts.Contracts.Responses.AccountTransaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Bussiness.Services
{
    public interface IAccountTransactionService
    {
        Task<AccountTransactionResponse> PostAccountTransaction(PostAccountTransactionRequest request);
        Task<AccountTransactionResponse> GetAccountTransaction(GetAccountTransactionRequest request);
        Task<AccountTransactionCollectionResponse> GetAccountTransactionList(GetAccountTransactionCollectionRequest request);
    }
}
