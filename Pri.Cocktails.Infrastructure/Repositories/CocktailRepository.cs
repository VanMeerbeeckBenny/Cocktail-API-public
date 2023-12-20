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
    public class CocktailRepository : BaseRepository<Cocktail>,ICocktailRepository
    {
        public CocktailRepository(CocktailDbContext cocktailDbContext):base(cocktailDbContext)
        {

        }

        public override async Task<Cocktail> GetByIdAsync(int id)
        {
            return await _table.Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.MeasuringUnit)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient.IngredientType)
                .Include(c => c.Tools)
                .Include(c => c.CocktailCategory)
                .Include(c => c.Glass)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cocktail>> GetByUserId(string id)
        {
            return await _table.Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.MeasuringUnit)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient.IngredientType)
                .Include(c => c.Tools)
                .Include(c => c.CocktailCategory)
                .Include(c => c.Glass)
                .Where(c => c.UserId == id)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Cocktail>> GetAllAsync()
        {
            return await _table.Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient.IngredientType)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.MeasuringUnit)
                .Include(c => c.Tools)
                .Include(c => c.CocktailCategory)
                .Include(c => c.Glass)
                .OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<Cocktail>> SearchByNameAsync(string needle)
        {
            return await _table.Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient.IngredientType)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.MeasuringUnit)
                .Include(c => c.Tools)
                .Include(c => c.CocktailCategory)
                .Include(c => c.Glass)
                .Where(c => c.Name.ToUpper().Contains(needle.ToUpper()))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
        public async Task<IEnumerable<Cocktail>> GetByIngredientIdAsync(int id)
        {
            return await _table.Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient.IngredientType)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.MeasuringUnit)
                .Include(c => c.Tools)
                .Include(c => c.CocktailCategory)
                .Include(c => c.Glass)
                .Where(c => c.CocktailIngredient.Select(ci => ci.Ingredient.Id).Contains(id))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cocktail>> GetByCategoryIdAsync(int id)
        {
            return await _table.Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.Ingredient.IngredientType)
                .Include(c => c.CocktailIngredient)
                .ThenInclude(ci => ci.MeasuringUnit)
                .Include(c => c.Tools)
                .Include(c => c.CocktailCategory)
                .Include(c => c.Glass)
                .Where(c => c.CocktailCategoryId == id)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public IQueryable<Cocktail> GetAll()
        {
            return _table.AsQueryable();
        }
    }
}
