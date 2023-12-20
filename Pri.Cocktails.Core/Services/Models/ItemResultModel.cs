using Pri.Cocktails.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services.Models
{
    public class ItemResultModel<T> :BaseResultModel where T : BaseEntity
    {        
        public IEnumerable<T> Items { get; set; }
    }
}
