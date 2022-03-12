using TemplateApiProject.Domain.Entity.Base;
using TemplateApiProject.Domain.Entity.ValueObjects;
using TemplateApiProject.Domain.Enums;
using System;

namespace TemplateApiProject.Domain.Entity
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual Address Address { get; set; }
        public virtual Documentation Documentation { get; set; }
        public virtual Contact Contact { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
