﻿using Domain.DTOS;
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
        public async Task<IActionResult> AddCocktail(CocktailDTO cocktailDTO) =>
            Ok(await _cocktailService.CreateCocktailAsync(cocktailDTO));

        [HttpGet]
        [Route("/api/cocktails/getall")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _cocktailService.GetAllCocktailsAsync());
    }
}
