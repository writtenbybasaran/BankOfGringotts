using BankOfGringotts.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankOfGringotts.Model
{
    public class Accounts : IEntity<Guid>, ISoftDelete, IUpdateAudit, ICreateAudit
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActivityDate { get; set; }

        #region Attributes     
        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<AccountTransactions> AccountTransactions { get; set; }
        #endregion
    }
}
