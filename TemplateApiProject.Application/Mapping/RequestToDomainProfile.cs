using TemplateApiProject.Application.Requests;
using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Entity.ValueObjects;
using TemplateApiProject.Domain.Enums;

namespace TemplateApiProject.Application.Mapping
{
    public class RequestToDomainProfile : AutoMapper.Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateUserRequest, User>().AfterMap((request, entity) =>
             {
                 entity.Person = new Person()
                 {
                     FirstName = request.FirstName,
                     LastName = request.LastName,
                     Gender = request.Gender,
                     Birthdate = request.Birthdate,
                     Documentation = new Documentation
                     {
                         CPF = request.Cpf,
                         RG = request.Rg
                     },
                     Contact = new Contact()
                     {
                         Email = request.Email,
                         CellPhone = request.Cellphone
                     },
                     Address = new Address
                     {
                         City = request.AddressCity,
                         Country = "Brasil",
                         Neighborhood = request.AddressNeighborhood,
                         Number = request.AddressNumber,
                         State = request.AddressState,
                         Street = request.AddressStreet,
                         ZipCode = request.ZipCode,
                     }
                 };
                 entity.Username = request.Email;
             });
        }
    }
}
