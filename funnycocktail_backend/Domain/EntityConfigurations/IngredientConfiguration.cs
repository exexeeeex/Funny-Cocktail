using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Domain.EntityConfigurations
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(i => i.PowerId).IsUnique(false);

            builder.HasData(
                new Ingredient { Id = 1, Image = "Хранить в base64", Name = "Апельсиновый сок", PowerId = 1 });
            builder.HasData(
                new Ingredient { Id = 2, Image = "Хранить в base64", Name = "Пиво", PowerId = 2 });
            builder.HasData(
                new Ingredient { Id = 3, Image = "Хранить в base64", Name = "Водка", PowerId = 3 });
        }
    }
}
