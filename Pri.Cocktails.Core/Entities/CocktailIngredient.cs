using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Core.Entities
{
    public class CocktailIngredient 
    {
        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }        
        public string Amount { get; set; }
        public int? MeasuringUnitId { get; set; }
        public MeasuringUnit MeasuringUnit { get; set; }
    }
}