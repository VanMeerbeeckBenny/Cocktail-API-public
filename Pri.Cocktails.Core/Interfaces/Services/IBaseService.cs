using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<ItemResultModel<T>> GetAllAsync();
        Task<ItemResultModel<T>> GetByIdAsync(int id);        
        
    }
}
