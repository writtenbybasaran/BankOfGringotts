using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGringotts.Model.BaseModel
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}
