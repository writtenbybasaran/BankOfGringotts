using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Requests.AccountTransaction
{
    public class GetAccountTransactionCollectionRequest
    {
        public Guid AccountNo { get; set; }
    }
}
