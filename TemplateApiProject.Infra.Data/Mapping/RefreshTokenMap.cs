using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Application.Data.Mapping.Base;

namespace TemplateApiProject.Application.Data.Mapping
{
    public class RefreshTokenMap : BaseEntityTypeConfiguration<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(x => x.ExpirationDate);
            builder.Property(x => x.Token);
            builder.Property(x => x.Username);
        }
    }
}
