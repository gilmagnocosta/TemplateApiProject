using TemplateApiProject.Application.Responses;
using TemplateApiProject.Domain.Entity;

namespace TemplateApiProject.Application.Mapping
{
    public class DomainToResponseProfile : AutoMapper.Profile
    {
        public DomainToResponseProfile()
        {
            
            CreateMap<User, FindUserResponse>().AfterMap((entity, response) =>
            {
                response.FirstName = entity.Person.FirstName;
                response.LastName = entity.Person.LastName;
                response.Email = entity.Person.Contact.Email;
            });
        }
    }
}
