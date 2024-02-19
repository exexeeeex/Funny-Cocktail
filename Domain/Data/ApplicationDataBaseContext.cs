using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class ApplicationDataBaseContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Cocktail> Cocktails => Set<Cocktail>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Power> Powers => Set<Power>();
        public DbSet<CocktailIngredient> CocktailIngredients => Set<CocktailIngredient>();

        public ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cocktail>().HasIndex(c => c.PowerId).IsUnique(false);
            modelBuilder.Entity<Cocktail>().HasIndex(c => c.AuthorId).IsUnique(false);
            modelBuilder.Entity<Ingredient>().HasIndex(i => i.PowerId).IsUnique(false);
            modelBuilder.Entity<Author>().HasIndex(a => a.RoleId).IsUnique(false);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 2, Name = "Бармен" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 3, Name = "Пьяница" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 4, Name = "Начинающий" });

            modelBuilder.Entity<Power>().HasData(
                new Power { Id = 1, Name = "Сильный" });
            modelBuilder.Entity<Power>().HasData(
                new Power { Id = 2, Name = "Средний" });
            modelBuilder.Entity<Power>().HasData(
                new Power { Id = 3, Name = "Слабый" });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Image = "Хранить в base64", Name = "Апельсиновый сок", PowerId = 1 });
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 2, Image = "Хранить в base64", Name = "Пиво", PowerId = 2 });
        }
    }
}
