using Microsoft.AspNetCore.Http;
using TemplateApiProject.Domain.Interface.Service;
using System;
using System.Security.Claims;

namespace TemplateApiProject.Domain.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            string userId = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                UserId = Guid.Parse(userId);
                LoggedIn = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public Guid? UserId { get; }
        public bool LoggedIn { get; }
    }
}
