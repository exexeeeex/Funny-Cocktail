using Domain.Entities;

namespace Domain.DTOS
{
    public class CocktailDTO : EntityBase
    {
        public string? Name { get; set; }
        public string? AuthorUsername { get; set; }
        public List<int> IngredientsId { get; set; } = new();
    }
}
