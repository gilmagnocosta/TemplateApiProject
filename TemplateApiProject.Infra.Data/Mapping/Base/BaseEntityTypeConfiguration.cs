using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApiProject.Domain.Entity.Base;

namespace TemplateApiProject.Application.Data.Mapping.Base
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.IsActive);
        }
    }
}
