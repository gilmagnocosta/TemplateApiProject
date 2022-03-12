using FluentValidation;
using TemplateApiProject.Application.Requests;

namespace TemplateApiProject.Application.Validators
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateValidator()
        {
            RuleFor(a => a.Password)
                .NotEmpty().When(x => x.GrantType == "password" || string.IsNullOrEmpty(x.GrantType))
                .WithMessage("Senha não informada");

            RuleFor(a => a.Email)
                .NotNull().When(x => x.GrantType == "password" || string.IsNullOrEmpty(x.GrantType))
                .WithMessage("Email não informado");

            RuleFor(a => a.RefreshToken)
                .NotNull()
                .NotEmpty()
                .When(x => !string.IsNullOrEmpty(x.GrantType) && x.GrantType == "refresh_token")
                .WithMessage("Refresh Token not informed");
        }
    }
}
