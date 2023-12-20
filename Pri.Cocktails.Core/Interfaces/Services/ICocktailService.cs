using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface ICocktailService : IBaseService<Cocktail>    {        
        
        Task<ItemResultModel<Cocktail>> SearchByNameAsync(string needle);
        Task<ItemResultModel<Cocktail>> GetByRole(string role, string userId);
        Task<ItemResultModel<Cocktail>> AddAsync(string currentUserId,int? cocktailCategoryId, IFormFile image, string instructions, int? glassTypeId, string name, ICollection<int> tools, ICollection<CocktailIngredient> ingredients);
        Task<ItemResultModel<Cocktail>> UpdateAsync(string currentUserId,int id,int? cocktailCategoryId, IFormFile image, string instructions, int? glassTypeId, string name, ICollection<int> tools, ICollection<CocktailIngredient> ingredients);
        Task<ItemResultModel<Cocktail>> DeleteAsync(int id,string userId,string role);
    }
}
