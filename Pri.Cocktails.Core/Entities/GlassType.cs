using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Core.Entities
{
    public class GlassType : BaseEntity
    {
        public ICollection<Cocktail> Coctails { get; set; }
        [MaxLength(100)]
        public string Picture { get; set; }
    }
}