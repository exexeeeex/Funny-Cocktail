using Domain.DTOS;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunnyCocktail.Controllers
{
    [ApiController]
    [Route("/api/cocktailsreviews")]
    public class CocktailReviewController(ICocktailReviewService cocktailReviewService) : ControllerBase
    {
        private readonly ICocktailReviewService _cocktailReviewService = cocktailReviewService;

        [HttpPost]
        [Route("/api/cocktailsreviews/addreview")]
        public async Task<IActionResult> AddReview([FromBody] CocktailReviewDTO cocktailReviewDTO) =>
            Ok(await _cocktailReviewService.CreateReviewAsync(cocktailReviewDTO));

        [HttpGet]
        [Route("/api/cocktailsreviews/getreviewsbyid")]
        public async Task<IActionResult> GetReviewsById(int Id) =>
            Ok(await _cocktailReviewService.GetAllCocktailReviewsByIdAsync(Id));

        [HttpGet]
        [Route("/api/cocktailsreviews/getallreviews")]
        public async Task<IActionResult> GetAllReviews() => 
            Ok(await _cocktailReviewService.GetAllCocktailReviewsAsync());
    }
}
