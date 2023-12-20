using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface IToolService : IBaseService<Tool>
    {
        Task<ItemResultModel<Tool>> AddAsync(string name, IFormFile image);
        Task<ItemResultModel<Tool>> UpdateAsync(int id,string name, IFormFile image);
        Task<ItemResultModel<Tool>> DeleteAsync(int id);
    }
}
