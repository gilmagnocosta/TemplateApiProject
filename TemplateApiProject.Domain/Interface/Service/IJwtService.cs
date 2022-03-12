using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Model;

namespace TemplateApiProject.Domain.Interface.Service
{
    public interface IJwtService
    {
        JsonWebToken CreateJWT(User user);
    }
}
