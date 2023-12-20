using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<ItemResultModel<Cocktail>> GetCocktailsFromCategoryAsync(int id);
        Task<ItemResultModel<Category>> AddAsync(string name);
        Task<ItemResultModel<Category>> UpdateAsync(int id,string name);
        Task<ItemResultModel<Category>> DeleteAsync(int id);
    }
}
