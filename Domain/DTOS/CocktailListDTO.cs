using Domain.Entities;

namespace Domain.DTOS
{
    public class CocktailListDTO
    {
        public int Id { get; set; }
        public string? CocktailName { get; set; }
        public string? AuthorName { get;set; }
        public int PowerId { get; set; }
        public List<Ingredient> Ingredients { get; set;} = new List<Ingredient>();
    }
}
