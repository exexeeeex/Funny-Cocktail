using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunnyCocktail.Application.Services
{
    public class IngredientService(ApplicationDataBaseContext context) : IIngredientService
    {
        private readonly ApplicationDataBaseContext _context = context;
        public async Task<string> AddIngredientAsync(Ingredient ingredient)
        {
            var hasIngredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Name.ToLower().Equals(ingredient.Name.ToLower()));
            if (hasIngredient != null) throw new ArgumentException("Ингредиент существует!");
            var ingredientModel = new Ingredient()
            {
                Name = ingredient.Name,
                PowerId = ingredient.PowerId,
                Image = ingredient.Image,
            };
            _context.Ingredients.Add(ingredientModel);
            await _context.SaveChangesAsync();
            return $"Ингредиент {ingredient.Name} успешно добавлен!";
        }

        public async Task<List<Ingredient>> GetIngredientListByCocktailIdAsync(int Id)
        {
            var cocktailList = await _context.CocktailIngredients.Where(c => c.CocktailId == Id).ToListAsync();
            List<Ingredient> ingredientList = [];
            foreach(var item in cocktailList)
            {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == item.IngredientId);
                ingredientList.Add(ingredient);
            }
            return ingredientList;
        }

        public async Task<string> RemoveIngredientAsync(int id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
            _context.Ingredients.Remove(ingredient!);
            await _context.SaveChangesAsync();
            return $"Ингредиент {ingredient!.Name} был успешно удалён!";
        }
    }
}
