using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TemplateApiProject.Application.Utils.Http;

namespace TemplateApiProject.Application.Utils.Injection
{
    public static class DependencyInjection
    {
        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void UseHttpContextAccessor(this IApplicationBuilder app)
        {
            AppHttpHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }

    }
}
