using TemplateApiProject.Domain.Interface;
using TemplateApiProject.Application.Data.Context;
using System.Collections.Generic;
using System;
using TemplateApiProject.Domain.Interface.Repository;
using System.Linq;
using TemplateApiProject.Application.Data.Repository;
using System.Threading.Tasks;

namespace TemplateApiProject.Application.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TemplateApiProjectDataContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(TemplateApiProjectDataContext context)
        {
            _context = context;
        }

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new Repository<T>(_context);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
