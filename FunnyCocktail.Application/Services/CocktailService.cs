using Domain.Data;
using Domain.DTOS;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunnyCocktail.Application.Services
{
    public class CocktailService(ApplicationDataBaseContext context) : ICocktailService
    {
        private readonly ApplicationDataBaseContext _context = context;
        public async Task<string> CreateCocktailAsync(CocktailDTO cocktailDTO)
        {
            var cocktail = await _context.Cocktails.FirstOrDefaultAsync(c => c.Name.ToLower().Equals(cocktailDTO.Name.ToLower()));
            if (cocktail != null) throw new ArgumentException("Коктейль с таким именем уже существует");
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Username.ToLower().Equals(cocktailDTO.AuthorUsername.ToLower()));
            if (author == null)
            {
                await _context.AddAsync(new Author()
                {
                    Username = cocktailDTO.AuthorUsername,
                    NumberOfCocktails = 1,
                    RoleId = 4
                });
                await _context.SaveChangesAsync();
            }

            var authorId = await _context.Authors.FirstOrDefaultAsync(a => a.Username.ToLower().Equals(cocktailDTO.AuthorUsername.ToLower()));

            await _context.Cocktails.AddAsync(new Cocktail()
            {
                AuthorId = authorId.Id,
                Name = cocktailDTO.Name,
                PowerId = 1,
            });
            await _context.SaveChangesAsync();
            var cocktailId = await _context.Cocktails.FirstOrDefaultAsync(c => c.Name.ToLower().Equals(cocktailDTO.Name.ToLower()));

            foreach (var item in cocktailDTO.IngredientsId)
            {
                var cocktailIngredientModel = new CocktailIngredient()
                {
                    CocktailId = cocktailId.Id,
                    IngredientId = item
                };
                _context.CocktailIngredients.Add(cocktailIngredientModel);
                await _context.SaveChangesAsync();
            }

            var ingredientList = new List<int>();
            int powerSum = 0;

            foreach (var item in _context.CocktailIngredients.Where(c => c.CocktailId == cocktailId.Id)) ingredientList.Add(item.IngredientId);
            foreach (var ingredientItem in ingredientList) powerSum += 10;
            if (powerSum >= 10 && powerSum <= 40) cocktailId.PowerId = 3;
            else if (powerSum >= 30 && powerSum <= 60) cocktailId.PowerId = 2;
            else if (powerSum >= 50 && powerSum <= 80) cocktailId.PowerId = 1;
            else cocktailId.PowerId = 1;
            await _context.SaveChangesAsync();
            return $"{cocktailDTO.Name} успешно добавлен!";
        }

        public async Task<List<CocktailListDTO>> GetAllCocktailsAsync()
        {
            var cockatilList = await _context.Cocktails.ToListAsync();
            var cocktailDtoList = new List<CocktailListDTO>();

            foreach (var item in cockatilList)
            {
                var ingredientList = new List<int>();
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == item.AuthorId);

                foreach (var ingredient in _context.CocktailIngredients.Where(c => c.CocktailId == item.Id))
                    ingredientList.Add(ingredient.IngredientId);

                var cocktailModel = new CocktailListDTO()
                {
                    Id = item.Id,
                    AuthorName = author.Username,
                    CocktailName = item.Name,
                    PowerId = item.PowerId,
                    Ingredients = ingredientList,
                };

                cocktailDtoList.Add(cocktailModel);
            }

            return cocktailDtoList;
        }
    }
}
