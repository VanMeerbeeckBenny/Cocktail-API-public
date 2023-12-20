using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Pri.Cocktails.Api.CustumSwagger;

namespace Pri.Cocktails.Api.Dtos.CocktailIngredients
{
    [ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class CocktailIngredientRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int IngredientId { get; set; }        
        public string Amount { get; set; }        
        public int MeasuringUnitId { get; set; }
    }
}
