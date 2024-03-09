using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunnyCocktail.Controllers
{
    [ApiController]
    [Route("/api/ingredients/")]
    public class IngredientController(ILogger<IngredientController> logger, IIngredientService ingredientService) 
        : ControllerBase
    {
        private readonly ILogger<IngredientController> _logger = logger;
        private readonly IIngredientService _ingredientService = ingredientService;

        [HttpPost("add")]
        public async Task<IActionResult> AddIngredient([FromBody] Ingredient ingredient) =>
            Ok(await _ingredientService.AddIngredientAsync(ingredient));

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveIngredient(int id) =>
            Ok(await _ingredientService.RemoveIngredientAsync(id));

        [HttpGet("getbycocktailid")]
        public async Task<IActionResult> GetByCocktailId(int Id) =>
            Ok(await _ingredientService.GetIngredientListByCocktailIdAsync(Id));
    }
}
