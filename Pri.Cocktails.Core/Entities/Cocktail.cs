using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Core.Entities
{
    public class Cocktail : BaseEntity
    {
        public int? CocktailCategoryId { get; set; }
        public Category CocktailCategory { get; set; }
        [MaxLength(100)]
        public string Picture { get; set; }
        [Required]
        public string Instrucktions { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int? GlassTypeId { get; set; }
        public GlassType Glass { get; set; }
        public ICollection<Tool> Tools { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredient { get; set; }
    }
}