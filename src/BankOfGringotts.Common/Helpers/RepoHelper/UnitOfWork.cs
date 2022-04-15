using BankOfGringotts.Context.Context;
using BankOfGringotts.Context.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Common.Helpers.RepoHelper
{
    public class UnitOfWork : IUnitOfWork
    {
        private GringottsContext _repoContext;
        public IAccountTransactionRepository AccountTransaction { get; }
        public IAccountRepository Account { get; }
        public ICustomerRepository Customer { get; }

        public UnitOfWork(GringottsContext repoContext,
            IAccountTransactionRepository accountTransactionRepository,
            IAccountRepository accountRepository,
            ICustomerRepository customerRepository)
        {
            _repoContext = repoContext;
            AccountTransaction = accountTransactionRepository;
            Account = accountRepository;
            Customer = customerRepository;
        }

        public void Complete()
        {
            _repoContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repoContext.Dispose();
            }
        }
    }
}
