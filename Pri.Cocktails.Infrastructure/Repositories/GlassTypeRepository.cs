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
    public class GlassTypeRepository : BaseRepository<GlassType>,IGlassTypeRepository
    {
        public GlassTypeRepository(CocktailDbContext cocktailDbContext) :base(cocktailDbContext)
        {

        }
    }
}
