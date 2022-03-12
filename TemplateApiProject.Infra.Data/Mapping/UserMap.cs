using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Application.Data.Mapping.Base;
using TemplateApiProject.Infra.Utils.Security;
using System;

namespace TemplateApiProject.Application.Data.Mapping
{
    public class UserMap : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            var personId = new Guid("5CAFC63F-4BF4-46F5-9615-D343F34071E9");
            var userId = Guid.NewGuid();

            builder.HasOne(x => x.Person);
            builder.Property(x => x.Username);
            builder.Property(x => x.Password);
            builder.Property(x => x.Profile);

            builder.HasData(
                new User
                {
                    Id = userId,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    Password = PasswordGenerator.Generate("ssadmin"),
                    Profile = Domain.Enums.ProfileEnum.Admin,
                    Username = "admin@admin.com",
                    PersonId = personId
                }
                );
        }
    }
}
