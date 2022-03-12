using TemplateApiProject.Domain.Entity.Pagination;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TemplateApiProject.Domain.Interface.Service.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<PagedResult<TEntity>> GetPagedAsync(int size, int page, Expression<Func<TEntity, bool>> expression = null);
        Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> expression);
        Task<IQueryable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression);
    }
}
