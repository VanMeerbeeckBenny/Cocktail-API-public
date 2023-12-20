using System.Collections.Generic;

namespace Pri.Cocktails.Core.Entities
{
    public class IngredientType : BaseEntity
    {
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}