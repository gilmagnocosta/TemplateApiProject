using TemplateApiProject.Domain.Entity.Base;
using TemplateApiProject.Domain.Enums;
using System;

namespace TemplateApiProject.Domain.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual Person Person { get; set; }
        public virtual Guid PersonId { get; set; }
        public ProfileEnum? Profile { get; set; }
    }
}
