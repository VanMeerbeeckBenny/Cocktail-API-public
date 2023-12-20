using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface IMeasuringUnitService : IBaseService<MeasuringUnit>
    {
        Task<ItemResultModel<MeasuringUnit>> AddAsync(string name);
        Task<ItemResultModel<MeasuringUnit>> UpdateAsync(int id,string name);
        Task<ItemResultModel<MeasuringUnit>> DeleteAsync(int id);
    }
}
