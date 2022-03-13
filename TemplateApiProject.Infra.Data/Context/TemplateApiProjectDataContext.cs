using Microsoft.EntityFrameworkCore;
using TemplateApiProject.Domain.Entity.Base;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Application.Data.Interface;
using TemplateApiProject.Application.Data.Mapping;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TemplateApiProject.Application.Data.Context
{
    public class TemplateApiProjectDataContext : DbContext, IDataContext
    {
        ICurrentUserService _currentUserService;

        public TemplateApiProjectDataContext(DbContextOptions options) : base(options) { }
        public TemplateApiProjectDataContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options) 
        {
            _currentUserService = currentUserService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserMap)));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
        }
         
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.IsActive = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = _currentUserService.UserId;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
