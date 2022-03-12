using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Entity.ValueObjects;
using TemplateApiProject.Application.Data.Mapping.Base;
using System;

namespace TemplateApiProject.Application.Data.Mapping
{
    public class PersonMap : BaseEntityTypeConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            var personId = new Guid("5CAFC63F-4BF4-46F5-9615-D343F34071E9");

            builder.OwnsOne(x => x.Documentation).HasData(new
            {
                PersonId = personId,
                CPF = "00000000000",
                RG = "000000000"
            });

            builder.OwnsOne(x => x.Address).HasData(new
            {
                PersonId = personId,
                City = "Admin",
                Country = "Brazil",
                Neighborhood = "Admin",
                Number = "0",
                State = "Admin",
                Street = "Admin",
                ZipCode = "00000-000"
            });

            builder.OwnsOne(x => x.Contact).HasData(new
            {
                PersonId = personId,
                Email = "admin@admin.com"
            });

            builder.Property(x => x.Birthdate);
            builder.Property(x => x.FirstName);
            builder.Property(x => x.Gender);
            builder.Property(x => x.LastName);

            builder.HasData(new
            {
                Id = personId,
                CreatedAt = DateTime.Now,
                IsActive = true,
                Birthdate = DateTime.Today,
                FirstName = "User",
                Gender = Domain.Enums.GenderEnum.Male,
                LastName = "Admin"
            });
        }
    }
}
