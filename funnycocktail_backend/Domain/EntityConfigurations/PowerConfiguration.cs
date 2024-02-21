using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Domain.EntityConfigurations
{
    public class PowerConfiguration : IEntityTypeConfiguration<Power>
    {
        public void Configure(EntityTypeBuilder<Power> builder)
        {
            builder.HasData(
                new Power { Id = 1, Name = "Сильный" });
            builder.HasData(
                new Power { Id = 2, Name = "Средний" });
            builder.HasData(
                new Power { Id = 3, Name = "Слабый" });
        }
    }
}
