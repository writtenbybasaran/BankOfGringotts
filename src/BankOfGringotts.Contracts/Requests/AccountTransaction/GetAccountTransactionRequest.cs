using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.AccountTransaction
{
    public class GetAccountTransactionRequest
    {
        public Guid TransactionId { get; set; }
    }
}
