using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Model.BaseModel;

namespace BankOfGringotts.Model
{
    public class Audit : IEntity<Guid> , ICreateAudit
    {

        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string TableName { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string AffectedColumns { get; set; }
        public string PrimaryKey { get; set; }
 
    }
}
