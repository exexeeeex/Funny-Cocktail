using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasIndex(a => a.RoleId).IsUnique(false);
        }
    }
}
