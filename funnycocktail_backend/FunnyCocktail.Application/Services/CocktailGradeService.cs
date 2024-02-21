using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunnyCocktail.Application.Services
{
    public class CocktailGradeService(ApplicationDataBaseContext context) : ICocktailGradeService
    {
        private readonly ApplicationDataBaseContext _context = context;

        public async Task<double> GetAverageRatingByIdAsync(int Id)
        {
            var cocktailCount = await _context.CocktailGrades.CountAsync(c => c.CocktailId == Id);
            double totalSum = 0;
            double averageRating = 0;

            foreach(var item in _context.CocktailGrades.Where(r => r.CocktailId == Id))
            {
                totalSum += item.Grade;
                averageRating = Math.Round((totalSum / cocktailCount), 2);
            }
            return averageRating;
        }

        public async Task<bool> RateTheCocktailAsync(CocktailGrade cocktailGrade)
        {
            _context.CocktailGrades.Add(cocktailGrade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
