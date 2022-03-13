using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TemplateApiProject.API.Policies
{
    /// <summary>
    /// Delete user requirement handler
    /// </summary>
    public class DeleteUserRequirementHandler : AuthorizationHandler<DeleteUserRequirement>
    {
        private const string AdministratorRoleName = "Administrator";

        private AuthorizationHandlerContext _context;

        /// <summary>
        /// Handle requirement
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DeleteUserRequirement requirement)
        {
            _context = context;

            var isAdministrator = IsAdministrator();
            var canDeleteUser = HasRequirements(requirement);

            if (isAdministrator && canDeleteUser)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool IsAdministrator() =>
            GetClaim(ClaimTypes.Role, AdministratorRoleName);

        private bool HasRequirements(DeleteUserRequirement requirement) =>
            GetClaim("permissions", requirement.RequiredPermission);

        private bool GetClaim(string type, string value) => _context.User.HasClaim(type, value);

    }
}