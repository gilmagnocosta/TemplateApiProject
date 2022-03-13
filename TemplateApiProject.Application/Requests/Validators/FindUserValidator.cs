using FluentValidation;
using System;
using TemplateApiProject.Application.Requests;

namespace TemplateApiProject.Application.Validators
{
    public class FindUserValidator : AbstractValidator<FindUserRequest>
    {
        public FindUserValidator()
        {

            RuleFor(a => a.Id)
                .NotNull()
                .NotEmpty()
                .NotEqual(a=> Guid.Empty)
                .WithMessage("Id não informado");

        }
    }
}