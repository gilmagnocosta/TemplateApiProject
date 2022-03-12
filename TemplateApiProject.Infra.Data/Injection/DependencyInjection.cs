using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateApiProject.Domain.Interface;
using TemplateApiProject.Domain.Interface.Repository;
using TemplateApiProject.Application.Data.Context;
using TemplateApiProject.Application.Data.Repository;

namespace TemplateApiProject.Application.Data.Injection
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TemplateApiProjectDataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            //services.AddScoped<IArchiveRepository, ArchiveRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IPatientRepository, PatientRepository>();
            //services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            //services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            //services.AddScoped<IUserTokenRepository, UserTokenRepository>();

        }
    }
}
