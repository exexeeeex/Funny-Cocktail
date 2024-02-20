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
                    NumberOfCocktails = 0,
                    RoleId = 4
                });
                await _context.SaveChangesAsync();
            }

            var authorId = await _context.Authors.FirstOrDefaultAsync(a => a.Username.ToLower().Equals(cocktailDTO.AuthorUsername.ToLower()));
            authorId.NumberOfCocktails += 1;

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

            var allIngredients = await _context.Ingredients.ToListAsync();

            foreach (var item in _context.CocktailIngredients.Where(c => c.CocktailId == cocktailId.Id)) ingredientList.Add(item.IngredientId);
            foreach (var ingredientItem in ingredientList)
            {
                foreach(var item in allIngredients.Where(i => i.Id == ingredientItem))
                {
                    if (item.PowerId == 1) powerSum += 30;
                    else if (item.PowerId == 2) powerSum += 20;
                    else powerSum += 10;
                }
            }
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
            var allCocktailIngredients = _context.CocktailIngredients.ToList();

            foreach (var item in cockatilList)
            {
                var ingredientList = new List<Ingredient>();
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == item.AuthorId);

                var cocktailIngredients = allCocktailIngredients.Where(c => c.CocktailId == item.Id);

                foreach (var cocktailIngredient in cocktailIngredients)
                {
                    var ingredientId = cocktailIngredient.IngredientId;
                    var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == ingredientId);

                    if (ingredient != null) ingredientList.Add(ingredient);
                }

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

        public async Task<CocktailListDTO> GetCocktailByIdAsync(int Id)
        {
            var cocktail = await _context.Cocktails.FirstOrDefaultAsync(c => c.Id == Id);
            var allCocktailIngredient = await _context.CocktailIngredients.ToListAsync();
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == cocktail.AuthorId);

            var cocktailModel = new CocktailListDTO();

            foreach(var item in allCocktailIngredient)
            {
                var ingredientList = new List<Ingredient>();
                var ingredientId = item.IngredientId;
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == ingredientId);
                ingredientList.Add(ingredient);

                var cocktailModelTemp = new CocktailListDTO()
                {
                    Id = cocktail.Id,
                    AuthorName = author.Username,
                    CocktailName = cocktail.Name,
                    PowerId = cocktail.PowerId,
                    Ingredients = ingredientList
                };
                cocktailModel = cocktailModelTemp;
            }
            return cocktailModel;
        }
    }
}
