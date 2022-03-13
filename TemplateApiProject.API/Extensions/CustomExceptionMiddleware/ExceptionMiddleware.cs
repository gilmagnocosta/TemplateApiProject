using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TemplateApiProject.API.Extensions.CustomExceptionMiddleware
{
    /// <summary>
    /// Exception Midleware
    /// </summary>
    public class ExceptionMiddleware : IMiddleware
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        public ExceptionMiddleware()
        {
            
        }

        /// <summary>
        /// Invokes the exception
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error($"Error occurred: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                Message = "An error occurred while processing your request",
                Detailed = exception
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}
