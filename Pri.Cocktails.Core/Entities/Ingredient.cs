using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Entities
{
    public class Ingredient : BaseEntity
    {
        [MaxLength(100)]
        public string Picture { get; set; }
        public int IngredientTypeId { get; set; }
        public IngredientType IngredientType { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredient { get; set; }
    }
}
