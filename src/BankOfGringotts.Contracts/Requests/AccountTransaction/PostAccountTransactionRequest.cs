using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.AccountTransaction
{
    public class PostAccountTransactionRequest
    {
        public Guid AccountNo { get; set; }
        public decimal TransactionValue { get; set; }

    }
}
