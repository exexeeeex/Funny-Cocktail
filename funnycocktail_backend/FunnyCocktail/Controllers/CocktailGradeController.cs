using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunnyCocktail.Controllers
{
    [ApiController]
    [Route("/api/cocktailgrades")]
    public class CocktailGradeController(ICocktailGradeService cocktailGradeService) : ControllerBase
    {
        private readonly ICocktailGradeService _cocktailGradeService = cocktailGradeService;

        [HttpGet]
        [Route("/api/cocktailgrades/getaverageratingbyid")]
        public async Task<IActionResult> GetAverageRating(int Id) =>
            Ok(await _cocktailGradeService.GetAverageRatingByIdAsync(Id));

        [HttpPost]
        [Route("/api/cocktailgrades/ratethecocktail")]
        public async Task<IActionResult> RatingTheCocktail([FromBody] CocktailGrade cocktailGrade) =>
            Ok(await _cocktailGradeService.RateTheCocktailAsync(cocktailGrade));
    }
}
