using BankOfGringotts.Context.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Context.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly GringottsContext _repositoryContext;
        public RepositoryBase(GringottsContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public Task<IQueryable<T>> FindAll() => Task.FromResult(_repositoryContext.Set<T>().AsNoTracking());
        public Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, string includePath = null)
        {

            IQueryable<T> query = _repositoryContext.Set<T>();

            if (!string.IsNullOrWhiteSpace(includePath))
            {
                query = query.Include(includePath);
            }

            return Task.FromResult(query.Where(expression).AsNoTracking());
        }

        public async Task Create(T entity) => await _repositoryContext.Set<T>().AddAsync(entity);
        public Task Update(T entity) => Task.FromResult(_repositoryContext.Set<T>().Update(entity));
        public Task Delete(T entity) => Task.FromResult(_repositoryContext.Set<T>().Remove(entity));
    }
}
