using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICocktailGradeService
    {
        public Task<bool> RateTheCocktailAsync(CocktailGrade cocktailGrade);
        public Task<double> GetAverageRatingByIdAsync(int Id);
    }
}
