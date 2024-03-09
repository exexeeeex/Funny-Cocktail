using Domain.Entities;
using System.Text.Json.Serialization;

namespace Domain.DTOS
{
    public class CocktailReviewDTO : EntityBase
    {
        [JsonPropertyName("nickname")]
        public string? Username { get; set; }
        [JsonPropertyName("reviewText")]
        public string? ReviewText { get; set; }
        public string? CocktailName { get; set; }
        [JsonPropertyName("cocktailId")]
        public int CocktailId { get; set; }
        [JsonPropertyName("reviewCount")]
        public int ReviewCount { get; set; }
    }
}
