using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TemplateApiProject.API.Extensions.CustomExceptionMiddleware;

namespace TemplateApiProject.API.Extensions
{
    /// <summary>
    /// Global extensions middleware extensions
    /// </summary>
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
		/// <summary>
		/// Add global exceptions handler
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddGlobalExceptionHandlerMiddleware(this IServiceCollection services)
		{
			return services.AddTransient<ExceptionMiddleware>();
		}

		/// <summary>
		/// Use global exceptions
		/// </summary>
		/// <param name="app"></param>
		public static void UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
