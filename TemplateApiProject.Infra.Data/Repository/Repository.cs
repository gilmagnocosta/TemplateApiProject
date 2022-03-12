using Microsoft.EntityFrameworkCore;
using TemplateApiProject.Domain.Interface.Repository;
using TemplateApiProject.Application.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TemplateApiProject.Application.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TemplateApiProjectDataContext _context;
        private readonly DbSet<TEntity> _entity;

        public Repository(TemplateApiProjectDataContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }


        #region Implementation of IRepository<T>

        public async Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entity.SingleOrDefaultAsync(expression);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_entity.AsQueryable());
        }

        public async Task<IQueryable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(_entity.Where(expression));
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Update(entity));
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.FromResult(_entity.Remove(entity));
        }

        #endregion    
    }
}
