using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunnyCocktail.Controllers
{
    [ApiController]
    [Route("/api/ingredients")]
    public class IngredientController(ILogger<IngredientController> logger, IIngredientService ingredientService) 
        : ControllerBase
    {
        private readonly ILogger<IngredientController> _logger = logger;
        private readonly IIngredientService _ingredientService = ingredientService;

        [HttpPost]
        [Route("/api/ingredients/add")]
        public async Task<IActionResult> AddIngredient([FromBody] Ingredient ingredient) =>
            Ok(await _ingredientService.AddIngredientAsync(ingredient));

        [HttpDelete]
        [Route("/api/ingredients/remove")]
        public async Task<IActionResult> RemoveIngredient(int id) =>
            Ok(await _ingredientService.RemoveIngredientAsync(id));
    }
}
