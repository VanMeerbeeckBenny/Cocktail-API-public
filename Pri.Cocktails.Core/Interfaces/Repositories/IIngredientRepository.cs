using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pri.Cocktails.Core.Entities;

namespace Pri.Cocktails.Core.Interfaces.Repositories
{
    public interface IIngredientRepository:IBaseRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> SearchByNameAsync(string needle);
        Task<IEnumerable<Ingredient>> GetByUserId(string id);
    }
}
