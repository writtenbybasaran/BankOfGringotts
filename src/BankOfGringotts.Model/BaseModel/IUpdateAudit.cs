using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Model.BaseModel
{
    public interface IUpdateAudit
    {
        DateTime LastActivityDate { get{return DateTime.Now;} set{ } }
    }
}
