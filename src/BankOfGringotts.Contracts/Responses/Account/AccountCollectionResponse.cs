using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Contracts.Responses.Account
{
    public class AccountCollectionResponse
    {
        public List<AccountAbstract> AccountAbstracts { get; set; }
    }

    public class AccountAbstract
    {
        public Guid AccountNo { get; set; }
        public decimal Balance { get; set; }
    }
}
