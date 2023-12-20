using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface IIngredientService : IBaseService<Ingredient>
    {
        Task<ItemResultModel<Cocktail>> GetCocktailFromIngredientAsync(int id);
        Task<ItemResultModel<Ingredient>> SearchByNameAsync(string needle);
        Task<ItemResultModel<Ingredient>> GetByRole(string role, string userId);
        Task<ItemResultModel<Ingredient>> AddAsync(string userId,string name, int ingredientTypeId, IFormFile picture);
        Task<ItemResultModel<Ingredient>> UpdateAsync(string currentUserId,int id,string name, int ingredientTypeId, IFormFile picture);       
        Task<ItemResultModel<Ingredient>> DeleteAsync(int id, string userID, string role);

    }
}
