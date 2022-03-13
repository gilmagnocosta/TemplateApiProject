using TemplateApiProject.API.Filters;
using TemplateApiProject.API.Policies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TemplateApiProject.Domain.Model;

namespace TemplateApiProject.API.Extensions
{
    /// <summary>
    /// MVC Extensions
    /// </summary>
    public static class MvcExtensions
    {
        /// <summary>
        /// Adds custom mvc extensions
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomMvc(this IServiceCollection services)
        {
            AddJwtAuthorization(services);
            AddFilters(services);
        }

        private static void AddJwtAuthorization(IServiceCollection services)
        {
            var jwtSettings = services.BuildServiceProvider().GetRequiredService<JwtSettings>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = jwtSettings.SigningCredentials.Key
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteUserPolicy", policy =>
                    policy.Requirements.Add(new DeleteUserRequirement("CanDeleteUser")));
            });

            services.AddSingleton<IAuthorizationHandler, DeleteUserRequirementHandler>();
        }

        private static void AddFilters(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
                config.Filters.Add<NotificationFilter>();
            })
                .AddNewtonsoftJson(options => { options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; });
        }
    }
}
