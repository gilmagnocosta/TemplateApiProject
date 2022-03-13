using Microsoft.AspNetCore.Authorization;

namespace TemplateApiProject.API.Policies
{
    /// <summary>
    /// Delete user requirement
    /// </summary>
    public class DeleteUserRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Required Permission
        /// </summary>
        public string RequiredPermission { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="requiredPermission"></param>
        public DeleteUserRequirement(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }
    }
}
