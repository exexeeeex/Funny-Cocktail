using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunnyCocktail.Controllers
{
    [ApiController]
    [Route("/api/authors/")]
    public class AuthorController(IAuthorService authorService) : ControllerBase
    {
        private readonly IAuthorService _authorService = authorService;

        [HttpGet("getauthorbyid")]
        public async Task<IActionResult> GetById(int Id) =>
            Ok(await _authorService.GetAuthorByIdAsync(Id));

        [HttpPost("createusername")]
        public async Task<IActionResult> CreateUsername(string username) => 
            Ok(await _authorService.CreateUsernameAsync(username));
    }
}
