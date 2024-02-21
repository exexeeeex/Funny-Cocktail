using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class CocktailReview : EntityBase
    {
        public string ReviewText { get; set; } = null!;
        public int CocktailId { get; set; }
        public int? AuthorId { get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }
        [JsonIgnore]
        public Cocktail? Cocktail { get; set; }
    }
}
