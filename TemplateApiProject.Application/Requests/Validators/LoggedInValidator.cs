using FluentValidation;
using TemplateApiProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateApiProject.Application.Requests;

namespace TemplateApiProject.Application.Validators
{
    public class LoggedInValidator : AbstractValidator<LoggedInRequest>
    {
        public LoggedInValidator()
        {
            RuleFor(a => a.UsedId)
                .NotEmpty()
                .WithMessage("Id do usuario não informado");
        }
    }
}
