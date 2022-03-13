using Microsoft.AspNetCore.Http;

namespace TemplateApiProject.Application.Utils.Http
{
    public class AppHttpHelper
    {
        private static IHttpContextAccessor _accessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext Current => _accessor.HttpContext;
        public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}/api/";
    }
}
