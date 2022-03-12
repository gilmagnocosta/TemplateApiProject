using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Interface.Service.Base;
using System;
using System.Threading.Tasks;

namespace TemplateApiProject.Domain.Interface.Service
{
    public interface IUserService : IServiceBase<User>
    {
        Task AddNewAsync(User user);
        Task<User> Authenticate(string email, string password);
    }
}
