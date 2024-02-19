using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Cocktail : EntityBase
    {
        public string? Name { get; set; }
        public int AuthorId { get; set; }
        public int PowerId { get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }
        [JsonIgnore]
        public Power? Power { get; set; }
    }
}
