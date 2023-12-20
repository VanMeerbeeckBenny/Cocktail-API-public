using Microsoft.EntityFrameworkCore;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Infrastructure.Repositories
{
    public class IngredientTypeRepository : BaseRepository<IngredientType>,IIngredientTypeRepository
    {
        public IngredientTypeRepository(CocktailDbContext cocktailDbContext):base(cocktailDbContext)
        {

        }

        public override async Task<IngredientType> GetByIdAsync(int id)
        {
            return await _table
                .Include(c => c.Ingredients)
                .FirstOrDefaultAsync(i => i.Id == id);

        }
    }
}
