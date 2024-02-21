using Domain.DTOS;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunnyCocktail.Controllers
{
    [ApiController]
    [Route("/api/cocktails")]
    public class CocktailController(ICocktailService cocktailService) : ControllerBase
    {
        private readonly ICocktailService _cocktailService = cocktailService;

        [HttpPost]
        [Route("/api/cocktails/addcocktail")]
        public async Task<IActionResult> AddCocktail([FromBody] CocktailDTO cocktailDTO) =>
            Ok(await _cocktailService.CreateCocktailAsync(cocktailDTO));

        [HttpGet]
        [Route("/api/cocktails/getall")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _cocktailService.GetAllCocktailsAsync());

        [HttpGet]
        [Route("/api/cocktails/getbyid")]
        public async Task<IActionResult> GetById(int Id) =>
            Ok(await _cocktailService.GetCocktailByIdAsync(Id));
    }
}
