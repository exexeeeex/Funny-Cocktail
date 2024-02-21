using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class CocktailGrade : EntityBase
    {
        public int Grade { get; set; }
        public int? CocktailId { get; set; }
        [JsonIgnore]
        public Cocktail? Cocktail { get; set; }
    }
}
