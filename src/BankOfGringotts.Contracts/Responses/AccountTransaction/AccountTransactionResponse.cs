using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Responses.AccountTransaction
{
    public class AccountTransactionResponse
    {
        public Guid AccountNo { get; set; }
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionValue { get; set; }
    }
}
