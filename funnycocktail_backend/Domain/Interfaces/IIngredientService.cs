using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIngredientService
    {
        public Task<string> AddIngredientAsync(Ingredient ingredient);
        public Task<string> RemoveIngredientAsync(int id);
    }
}
