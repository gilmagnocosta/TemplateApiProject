using TemplateApiProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApiProject.Domain.Interface.Service
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        bool LoggedIn { get; }
    }
}
