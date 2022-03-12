using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TemplateApiProject.Domain.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> expression);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression);
    }
}