using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TemplateApiProject.Application.PipelineBehaviors;
using System.Reflection;
using FluentValidation;

namespace TemplateApiProject.Application.Injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
