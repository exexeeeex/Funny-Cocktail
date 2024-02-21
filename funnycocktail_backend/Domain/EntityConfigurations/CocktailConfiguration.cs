using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Domain.EntityConfigurations
{
    public class CocktailConfiguration : IEntityTypeConfiguration<Cocktail>
    {
        public void Configure(EntityTypeBuilder<Cocktail> builder)
        {
            builder.HasIndex(c => c.PowerId).IsUnique(false);
            builder.HasIndex(c => c.AuthorId).IsUnique(false);
        }
    }
}
