using TemplateApiProject.Domain.Entity.Base;
using System;

namespace TemplateApiProject.Domain.Entity
{
    public class RefreshToken : BaseEntity
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
