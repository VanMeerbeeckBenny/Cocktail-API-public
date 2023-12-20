using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Core.Entities
{
    public class Tool : BaseEntity
    {
        [MaxLength(100)]
        public string Picture { get; set; }
        public ICollection<Cocktail> Cocktails { get; set; }
    }
}