using TemplateApiProject.Domain.Entity.Pagination;
using TemplateApiProject.Domain.Interface;
using TemplateApiProject.Domain.Interface.Repository;
using TemplateApiProject.Domain.Interface.Service.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemplateApiProject.Domain.Notifications;

namespace TemplateApiProject.Domain.Service.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public ServiceBase(
            IUnitOfWork unitOfWork, 
            IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<PagedResult<TEntity>> GetPagedAsync(int size, int page, Expression<Func<TEntity, bool>> expression = null)
        {
            page = (page <= 0 ? 1 : page);
            IQueryable<TEntity> entireList;
            
            if (expression != null)
            {
                entireList = await _repository.FilterByAsync(expression);
            }
            else
            {
                entireList = await _repository.GetAllAsync();
            }
                        
            var pagedList = entireList.Skip(size * (page - 1)).Take(size).ToList();

            return new PagedResult<TEntity>(pagedList, entireList.Count(), page, size);
        }

        /// <summary>
        /// Adds an entity and commit transaction
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(TEntity entity)
        {
            await _repository.InsertAsync(entity);
            await _unitOfWork.Complete();
        }

        /// <summary>
        /// Updates an entity and commit transaction
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            await _unitOfWork.Complete();
        }

        /// <summary>
        /// Deletes an entity and commit transaction
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
            await _unitOfWork.Complete();
        }

        public Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.FindByAsync(expression);
        }

        public Task<IQueryable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.FilterByAsync(expression);
        }
    }
}
