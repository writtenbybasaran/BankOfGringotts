using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Responses.AccountTransaction
{
    public class AccountTransactionCollectionResponse
    {
        public List<AccountTransactionAbstractResponse> TransactionList { get; set; }
    }

    public class AccountTransactionAbstractResponse
    {
        public Guid TransactionId { get; set; }
        public decimal TransactionValue { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
