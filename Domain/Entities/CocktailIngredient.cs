using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class CocktailIngredient : EntityBase
    {
        public int CocktailId { get; set; }
        public int IngredientId { get; set; }
        [JsonIgnore]
        public Cocktail? Cocktail { get; set; }
        [JsonIgnore]
        public Ingredient? Ingredient { get; set; }
    }
}
