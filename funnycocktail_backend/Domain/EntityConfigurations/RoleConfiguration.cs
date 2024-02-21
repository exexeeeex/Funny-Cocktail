using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Domain.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role { Id = 1, Name = "Admin" });
            builder.HasData(
                new Role { Id = 2, Name = "Бармен" });
            builder.HasData(
                new Role { Id = 3, Name = "Пьяница" });
            builder.HasData(
                new Role { Id = 4, Name = "Начинающий" });
        }
    }
}
