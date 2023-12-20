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
    public interface IGlassTypeService : IBaseService<GlassType>
    {
        Task<ItemResultModel<GlassType>> AddAsync(string name,IFormFile image);
        Task<ItemResultModel<GlassType>> UpdateAsync(int id,string name, IFormFile image);
        Task<ItemResultModel<GlassType>> DeleteAsync(int id);

    }
}
