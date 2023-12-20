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
    public class IngredientRepository : BaseRepository<Ingredient>,IIngredientRepository
    {
        public IngredientRepository(CocktailDbContext cocktailDbContext):base(cocktailDbContext) 
        {

        }

        public override async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _table
                .Include(c => c.IngredientType)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public override async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _table
                .Include(c => c.IngredientType)
                .FirstOrDefaultAsync(i => i.Id == id);

        }

        public async Task<IEnumerable<Ingredient>> GetByUserId(string id)
        {
            return await _table
                .Include(c => c.IngredientType)
                .Where(i => i.UserId == id)
                .ToListAsync();

        }

        public async Task<IEnumerable<Ingredient>> SearchByNameAsync(string needle)
        {
            return await _table
               .Include(c => c.IngredientType)
               .Where(c => c.Name.ToUpper().Contains(needle.ToUpper()))
               .OrderBy(c => c.Name)
               .ToListAsync();
        }
    }
}
