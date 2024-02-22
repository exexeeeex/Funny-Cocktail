using Domain.Entities;

namespace Domain.DTOS
{
    public class CocktailReviewDTO : EntityBase
    {
        public string? Username { get; set; }
        public string? ReviewText { get; set; }
        public string? CocktailName { get; set; }
        public int CocktailId { get; set; }
    }
}
