using Pri.Cocktails.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Repositories
{
    public interface ICocktailRepository : IBaseRepository<Cocktail>
    {
        Task<IEnumerable<Cocktail>> GetByIngredientIdAsync(int id);
        Task<IEnumerable<Cocktail>> GetByCategoryIdAsync(int id);
        Task<IEnumerable<Cocktail>> SearchByNameAsync(string needle);
        Task<IEnumerable<Cocktail>> GetByUserId(string id);
        IQueryable<Cocktail> GetAll();
    }
}
