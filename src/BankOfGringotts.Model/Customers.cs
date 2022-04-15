using BankOfGringotts.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BankOfGringotts.Model
{
    public class Customers : IEntity<Guid>, ISoftDelete, IUpdateAudit, ICreateAudit
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime CreatedDate { get; set; }

        #region Attributes
        public string Name { get; set; }
        public string LastName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdentityNumber { get; set; }

        public DateTime BirthDate { get; set; }
        public string CustomerKey { get; set; }
        public virtual ICollection<Accounts> Accounts { get; set; }
        #endregion

        public Customers()
        {
            this.Accounts = new List<Accounts>();
        }
    }
}
