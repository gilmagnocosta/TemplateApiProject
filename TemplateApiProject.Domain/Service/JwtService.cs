using Microsoft.IdentityModel.Tokens;
using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Domain.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;

namespace TemplateApiProject.Domain.Service
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _settings;

        public JwtService(JwtSettings settings)
        {
            _settings = settings;
        }

        public JsonWebToken CreateJWT(User user)
        {
            var identity = GetClaimsIdentity(user);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                IssuedAt = _settings.IssuedAt,
                NotBefore = _settings.NotBefore,
                Expires = _settings.AccessTokenExpiration,
                SigningCredentials = _settings.SigningCredentials
            });

            var accessToken = handler.WriteToken(securityToken);

            return new JsonWebToken
            {
                AccessToken = accessToken,
                RefreshToken = CreateRefreshToken(user.Username),
                ExpiresIn = (long)TimeSpan.FromMinutes(_settings.ValidForMinutes).TotalSeconds
            };
        }

        private RefreshToken CreateRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                Username = username,
                ExpirationDate = _settings.RefreshTokenExpiration
            };

            string token;
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }

            refreshToken.Token = token.Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);

            return refreshToken;
        }

        private static ClaimsIdentity GetClaimsIdentity(User user)
        {
            var identity = new ClaimsIdentity
            (
                new GenericIdentity(user.Person.Contact.Email),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
                }
            );

            //foreach (var role in user.Roles)
            //{
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Profile.ToString()));
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //}

            //foreach (var policy in user.Permissions)
            //{
            //    identity.AddClaim(new Claim("permissions", policy));
            //}

            return identity;
        }
    }
}