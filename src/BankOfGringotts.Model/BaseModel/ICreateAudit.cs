using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Model.BaseModel
{
    public interface ICreateAudit
    {
        DateTime CreatedDate { get{return DateTime.Now;} set{ } }
    }
}
