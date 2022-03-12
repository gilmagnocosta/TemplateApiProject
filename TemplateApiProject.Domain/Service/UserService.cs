using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Interface.Repository;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Domain.Notifications;
using TemplateApiProject.Domain.Service.Base;
using System.Threading.Tasks;
using TemplateApiProject.Infra.Utils.Security;
using System;
using TemplateApiProject.Domain.Interface;

namespace TemplateApiProject.Domain.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IRepository<User> _userRepository;
        NotificationContext _notificationContext;

        public UserService(
            IUnitOfWork unitOfWork,
            NotificationContext notificationContext,
            IRepository<User> userRepository) : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public Task<User> Authenticate(string email, string password)
        {
            return _userRepository.FindByAsync(
                x => x.Username.Equals(email)
                && x.Password.Equals(PasswordGenerator.Generate(password))
                && x.IsActive == true);
        }

        public async Task AddNewAsync(User user)
        {
            if (await CheckIfUserExists(user.Username))
            {
                _notificationContext.AddNotification("user", "Este endereço de email já está cadastrado");
                return;
            }

            user.Password = PasswordGenerator.Generate(user.Password);

            await _userRepository.InsertAsync(user);

            await _unitOfWork.Complete();
        }
        private async Task<bool> CheckIfUserExists(string username)
        {
            return await _userRepository.FindByAsync(x => x.Username.Equals(username)) != null;
        }
    }
}