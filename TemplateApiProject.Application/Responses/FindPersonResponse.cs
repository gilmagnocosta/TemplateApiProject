using TemplateApiProject.Application.Responses.Base;
using TemplateApiProject.Application.ViewModel.Base;
using TemplateApiProject.Domain.Enums;
using System;

namespace TemplateApiProject.Application.Responses
{
    public class FindPersonResponse : ResponseBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public AddressResponse Address { get; set; }
        public DocumentationResponse Documentation { get; set; }
        public ContactResponse Contact { get; set; }
    }
}
