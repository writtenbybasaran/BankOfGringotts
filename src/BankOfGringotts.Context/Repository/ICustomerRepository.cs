using BankOfGringotts.Context.Repository.Base;
using BankOfGringotts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Context.Repository
{
    public interface ICustomerRepository :IRepositoryBase<Customers>
    {
    }
}
