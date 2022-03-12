using Microsoft.Extensions.DependencyInjection;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Domain.Model;
using TemplateApiProject.Domain.Notifications;
using TemplateApiProject.Domain.Service;

namespace TemplateApiProject.Domain.Injection
{
    public static class DependencyInjection
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<JwtSettings>();
        }

        public static void AddNotification(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
