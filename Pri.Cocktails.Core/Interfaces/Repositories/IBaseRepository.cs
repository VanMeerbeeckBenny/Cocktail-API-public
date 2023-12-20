using Pri.Cocktails.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Repositories
{
    public interface IBaseRepository <T> where T : BaseEntity
    {
        Task<bool> AddAsync(T toAdd);
        Task DeleteAsync(T toDelete);
        Task<bool> UpdateAsync(T toUpdate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);        
    }
}
