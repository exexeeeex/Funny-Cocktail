using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public DbSet<CocktailGrade> CocktailGrades => Set<CocktailGrade>();
        public DbSet<CocktailReview> CocktailReviews => Set<CocktailReview>();

        public ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
