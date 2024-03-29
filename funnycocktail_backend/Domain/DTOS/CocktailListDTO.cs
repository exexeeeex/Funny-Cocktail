﻿using Domain.Entities;

namespace Domain.DTOS
{
    public class CocktailListDTO
    {
        public int Id { get; set; }
        public string? CocktailName { get; set; }
        public string? AuthorName { get;set; }
        public string? Description { get; set; }
        public int PowerId { get; set; }
    }
}
