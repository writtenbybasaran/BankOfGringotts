using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}
