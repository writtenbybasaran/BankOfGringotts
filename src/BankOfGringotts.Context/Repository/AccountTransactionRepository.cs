using BankOfGringotts.Context.Context;
using BankOfGringotts.Context.Repository.Base;
using BankOfGringotts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Context.Repository
{
    public class AccountTransactionRepository : RepositoryBase<AccountTransactions>, IAccountTransactionRepository
    {
        public AccountTransactionRepository(GringottsContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
