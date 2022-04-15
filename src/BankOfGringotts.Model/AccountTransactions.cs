using BankOfGringotts.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankOfGringotts.Model
{
    public class AccountTransactions : IEntity<Guid>, ICreateAudit
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        #region Attributes
        public Guid AccountId { get; set; }
        public decimal TransactionValue { get; set; }
        public virtual Accounts Account { get; set; }
        #endregion
    }
}
