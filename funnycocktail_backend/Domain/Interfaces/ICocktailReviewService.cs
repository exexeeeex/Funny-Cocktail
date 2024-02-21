using Domain.DTOS;

namespace Domain.Interfaces
{
    public interface ICocktailReviewService
    {
        public Task<bool> CreateReviewAsync(CocktailReviewDTO cocktailReview);
        public Task<List<CocktailReviewDTO>> GetAllCocktailReviewsByIdAsync(int Id);
    }
}
