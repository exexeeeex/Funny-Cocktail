using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Ingredient : EntityBase
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int PowerId { get; set; }
        [JsonIgnore]
        public Power? Power { get; set; }
    }
}
