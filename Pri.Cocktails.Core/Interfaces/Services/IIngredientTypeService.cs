using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface IIngredientTypeService : IBaseService<IngredientType>
    {
        Task<ItemResultModel<IngredientType>> AddAsync(string name);
        Task<ItemResultModel<IngredientType>> UpdateAsync(int id,string name);
        Task<ItemResultModel<IngredientType>> DeleteAsync(int id);
    }
}
