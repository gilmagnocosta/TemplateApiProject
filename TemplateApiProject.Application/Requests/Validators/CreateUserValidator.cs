using FluentValidation;
using System;
using TemplateApiProject.Application.Requests;

namespace TemplateApiProject.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {

            RuleFor(a => a.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome não informado");

            RuleFor(a => a.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Sobrenome não informado");

            RuleFor(a => a.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email não informado");

            RuleFor(a => a.Password)
                .NotNull().WithMessage("Senha não informada")
                .MinimumLength(6).WithMessage("A senha deve conter pelo menos 6 caracteres");

            RuleFor(a => a.Cpf)
                .NotNull()
                .NotEmpty()
                .WithMessage("CPF não informado");

            //RuleFor(a => a.Rg)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("RG não informado");

            RuleFor(a => a.Cellphone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Telefone Celular não informado");

            RuleFor(a => a.ZipCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("CEP não informado");

            RuleFor(a => a.Gender)
                .NotEmpty()
                .NotNull().WithMessage("Gênero não informado")
                .IsInEnum().WithMessage("Gênero informado não é valido");

            RuleFor(a => a.Birthdate)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now)
                .WithMessage("Data de nascimento não informado");

            RuleFor(a => a.AddressStreet)
                .NotNull()
                .NotEmpty()
                .WithMessage("Endereço não informado");

            RuleFor(a => a.AddressNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Número não informado");

            RuleFor(a => a.AddressNeighborhood)
                .NotNull()
                .NotEmpty()
                .WithMessage("Bairro não informado");

            RuleFor(a => a.AddressCity)
                .NotNull()
                .NotEmpty()
                .WithMessage("Cidade não informado");

            RuleFor(a => a.AddressState)
                .NotNull()
                .NotEmpty()
                .WithMessage("Estado não informado");

            // When user is professional
            RuleFor(a => a.HasAcademicFormation)
                .NotNull()
                .NotEmpty()
                .WithMessage("Tem formação acadêmica não informado");

            RuleFor(a => a.EducationalInstitution)
                .NotNull()
                .NotEmpty()
                .WithMessage("Instituição acadêmica não informado");
        }
    }
}