using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Interface.Service.Base;
using System.Threading.Tasks;

namespace TemplateApiProject.Domain.Interface.Service
{
    public interface IRefreshTokenService : IServiceBase<RefreshToken>
    {
        Task<RefreshToken> GetByToken(string token);
        Task Save(RefreshToken refreshToken);
    }
}
