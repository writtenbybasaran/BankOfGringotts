using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
        public NotFoundException() : base()
        {

        }
    }
}
