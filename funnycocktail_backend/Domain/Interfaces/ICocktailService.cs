﻿using Domain.DTOS;
namespace Domain.Interfaces
{
    public interface ICocktailService
    {
        public Task<string> CreateCocktailAsync(CocktailDTO cocktailDTO);
        public Task<List<CocktailListDTO>> GetAllCocktailsAsync();
        public Task<CocktailListDTO> GetCocktailByIdAsync(int Id);
        public Task<bool> CreateUserAsync(string username);
        public bool AddingUserRole(string username);
    }
}