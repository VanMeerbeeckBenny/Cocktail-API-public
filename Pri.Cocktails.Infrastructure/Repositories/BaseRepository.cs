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
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly CocktailDbContext _cocktailContext;
        protected readonly DbSet<T> _table;

        public BaseRepository(CocktailDbContext cocktailDbContext)
        {
            _cocktailContext = cocktailDbContext;
            _table = _cocktailContext.Set<T>();

        }

        public async Task<bool> AddAsync(T toAdd)
        {
            _table.Add(toAdd);
            return await SaveChangesAsync();
        }

        public async Task DeleteAsync(T toDelete)
        {
            _table.Remove(toDelete);
            await _cocktailContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(x => x.Id == id);
        }      

        public async Task<bool> UpdateAsync(T toUpdate)
        {
            _table.Update(toUpdate);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _cocktailContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {                   
                return false;
            }
        }
    }
}
