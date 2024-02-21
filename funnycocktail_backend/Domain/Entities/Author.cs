using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Author : EntityBase
    {
        public string? Username { get; set; }
        public int NumberOfCocktails { get; set; }
        public int RoleId { get; set; }
        [JsonIgnore]
        public Role? Role { get; set; }
    }
}
