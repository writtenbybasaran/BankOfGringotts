using BankOfGringotts.Context.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Common.Helpers.RepoHelper
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        IAccountTransactionRepository AccountTransaction { get; }
        ICustomerRepository Customer { get; }
        void Complete();
    }
}
