using BankOfGringotts.Contracts.Requests.Account;
using BankOfGringotts.Contracts.Responses.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Bussiness.Services
{
    public interface IAccountService
    {
        Task<AccountResponse> PostAccount(PostAccountRequest request);
        Task<AccountResponse> GetAccount(GetAccountRequest request);
        Task<AccountCollectionResponse> GetAccountList(GetAccountCollectionRequest request);
        Task<bool> DeleteAccount(DeleteAccountRequest request);
    }
}
