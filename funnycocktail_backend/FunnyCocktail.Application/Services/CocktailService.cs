using Domain.Data;
using Domain.DTOS;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunnyCocktail.Application.Services
{
    public class CocktailService(ApplicationDataBaseContext context, IAuthorService authorService) : ICocktailService
    {
        private readonly ApplicationDataBaseContext _context = context;
        private readonly IAuthorService _authorService = authorService;

        public async Task<string> CreateCocktailAsync(CocktailDTO cocktailDTO)
        {
            var cocktail = await _context.Cocktails.FirstOrDefaultAsync(c => c.Name.ToLower().Equals(cocktailDTO.Name.ToLower()));
            if (cocktail != null) throw new ArgumentException("Коктейль с таким именем уже существует");
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Username.ToLower().Equals(cocktailDTO.AuthorUsername.ToLower()));
            if (author == null) await _authorService.CreateUsernameAsync(cocktailDTO.AuthorUsername);

            var authorId = await _context.Authors.FirstOrDefaultAsync(a => a.Username.ToLower().Equals(cocktailDTO.AuthorUsername.ToLower()));
            authorId.NumberOfCocktails += 1;

            await _context.Cocktails.AddAsync(new Cocktail()
            {
                AuthorId = authorId.Id,
                Name = cocktailDTO.Name,
                Description = cocktailDTO.Description,
                PowerId = 1,
            });
            await _context.SaveChangesAsync();
            AddingUserRole(authorId.Username);
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

        public bool AddingUserRole(string username)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Username == username);
            if (author.NumberOfCocktails >= 10) author.RoleId = 3;
            if (author.NumberOfCocktails >= 50) author.RoleId = 2;
            _context.SaveChanges();
            return true;
        }

        public async Task<List<CocktailListDTO>> GetAllCocktailsAsync()
        {
            var cockatilListTemp = await _context.Cocktails.ToListAsync();
            var cocktailList = new List<CocktailListDTO>();
            foreach(var item in cockatilListTemp)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(i => i.Id == item.AuthorId);
                var cocktailModel = new CocktailListDTO()
                {
                    Id = item.Id,
                    CocktailName = item.Name,
                    AuthorName = author.Username,
                    Description = item.Description,
                    PowerId = item.PowerId
                };
                cocktailList.Add(cocktailModel);
            }
            return cocktailList;
        }

        public async Task<CocktailListDTO> GetCocktailByIdAsync(int Id)
        {
            var cocktail = await _context.Cocktails.FirstOrDefaultAsync(c => c.Id == Id);
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == cocktail.AuthorId);
            var cocktailModel = new CocktailListDTO()
            {
                AuthorName = author.Username,
                CocktailName = cocktail.Name,
                Description = cocktail.Description,
                PowerId = cocktail.PowerId
            };
            return cocktailModel;
        }
    }
}
