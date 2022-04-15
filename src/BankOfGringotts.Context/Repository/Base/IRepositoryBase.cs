using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Context.Repository.Base
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> FindAll();
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, string includePath = null);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
