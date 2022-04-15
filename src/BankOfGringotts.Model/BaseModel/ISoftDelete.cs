using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Model.BaseModel
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
