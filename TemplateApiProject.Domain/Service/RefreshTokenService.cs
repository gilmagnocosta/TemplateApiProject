using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Interface.Repository;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Domain.Service.Base;
using System.Threading.Tasks;
using TemplateApiProject.Domain.Interface;

namespace TemplateApiProject.Domain.Service
{
    public class RefreshTokenService : ServiceBase<RefreshToken>, IRefreshTokenService
    {
        IUnitOfWork _unitOfWork;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;

        public RefreshTokenService(IUnitOfWork unitOfWork, IRepository<RefreshToken> refreshTokenRepository) : base(unitOfWork, refreshTokenRepository)
        {
            _unitOfWork = unitOfWork;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> GetByToken(string token)
        {
            return await _refreshTokenRepository.FindByAsync(x => x.Token.Equals(token));
        }

        public async Task Save(RefreshToken refreshToken)
        {
            var currentToken = await _refreshTokenRepository.FindByAsync(x => x.Username.Equals(refreshToken.Username));

            if (currentToken != null)
            {
                await _refreshTokenRepository.DeleteAsync(currentToken);
            }

            await AddAsync(refreshToken);
        }
    }
}
