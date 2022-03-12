using System.Text.Json.Serialization;
using TemplateApiProject.Application.Responses.Base;
using TemplateApiProject.Application.ViewModel.Base;

namespace TemplateApiProject.Application.Responses
{
    public class FindUserResponse : ResponseBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
