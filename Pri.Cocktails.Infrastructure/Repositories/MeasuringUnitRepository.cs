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
    public class MeasuringUnitRepository : BaseRepository<MeasuringUnit>,IMeasuringUnitRepository
    {
        public MeasuringUnitRepository(CocktailDbContext cocktailDbContext):base(cocktailDbContext)
        {

        }
    }
}
