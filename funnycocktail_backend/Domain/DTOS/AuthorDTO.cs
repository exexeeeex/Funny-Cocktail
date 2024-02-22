using Domain.Entities;

namespace Domain.DTOS
{
    public class AuthorDTO : EntityBase
    {
        public string? Username { get; set; }
        public long? NumberOfCocktails { get; set; }
        public string? Role { get; set; }
        public List<Cocktail> CocktailList { get; set; } = new List<Cocktail>();
    }
}
