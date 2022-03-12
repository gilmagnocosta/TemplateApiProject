using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TemplateApiProject.Application.Exceptions;
using TemplateApiProject.Application.Requests;
using TemplateApiProject.Application.Responses;
using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Domain.Notifications;

namespace TemplateApiProject.Application.Handlers.Requests
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, Response>
    {
        NotificationContext _notificationContext;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthenticateHandler(
            NotificationContext notificationContext,
            IJwtService jwtService,
            IUserService userService,
            IRefreshTokenService refreshTokenService)
        {
            _notificationContext = notificationContext;
            _jwtService = jwtService;
            _userService = userService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<Response> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            User user = null;

            try
            {
                if (string.IsNullOrEmpty(request.GrantType))
                    request.GrantType = "password";

                if (request.GrantType.Equals("password"))
                {
                    user = await HandleUserAuthentication(request);
                }
                else if (request.GrantType.Equals("refresh_token"))
                {
                    user = await HandleRefreshToken(request);
                }

                if (_notificationContext.HasNotifications)
                {
                    return response;
                }

                if (user == null)
                {
                    _notificationContext.AddNotification("authorization", "You don't have permission");
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationServiceException("Authentication error", ex);
            }

            response.Content = await HandleJwt(user);

            return response;
        }

        private async Task<object> HandleJwt(User user)
        {
            var jwt = _jwtService.CreateJWT(user);
            await _refreshTokenService.Save(jwt.RefreshToken);

            return (new
            {
                accessToken = jwt.AccessToken,
                refreshToken = jwt.RefreshToken.Token,
                tokenType = jwt.TokenType,
                expiresIn = jwt.ExpiresIn,
                userId = user.Id
            });
        }

        private async Task<User> HandleUserAuthentication(AuthenticateRequest request)
        {
            var user = await _userService.Authenticate(request.Email, request.Password);

            if (user == null)
            {
                _notificationContext.AddNotification("authenticate", "Usuário ou senha inválidos");
                return null;
            }

            return user;
        }

        private async Task<User> HandleRefreshToken(AuthenticateRequest request)
        {
            var token = await _refreshTokenService.GetByToken(request.RefreshToken);

            if (token == null)
            {
                _notificationContext.AddNotification(nameof(request.RefreshToken), "Refresh Token inválido");
            }
            else if (token.ExpirationDate < DateTime.Now)
            {
                _notificationContext.AddNotification(nameof(request.RefreshToken), "Refresh Token expirado");
            }

            if (_notificationContext.HasNotifications)
            {
                return null;
            }

            return await _userService.FindByAsync(x => x.Person.Contact.Email == token.Username);
        }

    }
}
