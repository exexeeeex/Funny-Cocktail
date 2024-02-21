using Domain.Data;
using Domain.DTOS;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunnyCocktail.Application.Services
{
    public class CocktailReviewService(ApplicationDataBaseContext context, ICocktailService cocktailService) : ICocktailReviewService
    {
        private readonly ApplicationDataBaseContext _context = context;
        private readonly ICocktailService _cocktailService = cocktailService;

        public async Task<bool> CreateReviewAsync(CocktailReviewDTO cocktailReview)
        {
            var user = await _context.Authors.FirstOrDefaultAsync(a => a.Username == cocktailReview.Username);
            if (user == null) throw new ArgumentException("Вам нужно создать коктейль, чтобы написать отзыв!");
            var reviewModel = new CocktailReview()
            {
                AuthorId = user.Id,
                CocktailId = cocktailReview.CocktailId,
                ReviewText = cocktailReview.ReviewText
            };
            _context.CocktailReviews.Add(reviewModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CocktailReviewDTO>> GetAllCocktailReviewsByIdAsync(int Id)
        {
            var cocktailReviewsListTemp = await _context.CocktailReviews.Where(c => c.CocktailId == Id).ToListAsync();
            var cocktailReviewList = new List<CocktailReviewDTO>();
            foreach(var item in cocktailReviewsListTemp)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == item.AuthorId);
                var cocktailReviewModel = new CocktailReviewDTO()
                {
                    Username = author.Username,
                    ReviewText = item.ReviewText,
                    CocktailId = item.CocktailId,
                };
                cocktailReviewList.Add(cocktailReviewModel);
            }
            return cocktailReviewList;
        }
    }
}
