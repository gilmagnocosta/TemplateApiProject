using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TemplateApiProject.Application.Responses;
using TemplateApiProject.Domain.Enums;

namespace TemplateApiProject.Application.Requests
{
    public class CreateUserRequest : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cellphone { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string ZipCode { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public string AddressNeighborhood { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public bool HasAcademicFormation { get; set; }
        public string EducationalInstitution { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ProfileEnum? Profile { get; set; }

        public CreateUserRequest() { }
    }
}
