using Domain.DTOS;
namespace Domain.Interfaces
{
    public interface ICocktailService
    {
        public Task<string> CreateCocktailAsync(CocktailDTO cocktailDTO);
        public Task<List<CocktailListDTO>> GetAllCocktailsAsync();
        public Task<CocktailListDTO> GetCocktailByIdAsync(int Id);
        public bool AddingUserRole(string username);
    }
}
