using Domain.Data;
using Domain.DTOS;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunnyCocktail.Application.Services
{
    public class AuthorService(ApplicationDataBaseContext context) : IAuthorService
    {
        private readonly ApplicationDataBaseContext _context = context;
        public async Task<AuthorDTO> GetAuthorByIdAsync(int Id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == Id);
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == author.RoleId);
            var cocktails = await _context.Cocktails.Where(c => c.AuthorId == Id).ToListAsync();
            var authorModel = new AuthorDTO()
            {
                Id = Id,
                Username = author.Username,
                NumberOfCocktails = author.NumberOfCocktails,
                Role = role.Name,
                CocktailList = cocktails,
            };
            return authorModel;
        }
    }
}
