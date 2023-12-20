using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Api.Dtos.CocktailIngredients;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Cocktails
{
    public class CocktailRequestDto
    {
        [Required(ErrorMessage = "Please fill in {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a category")]
        public int? CocktailCategoryId { get; set; }
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = "Please fill in {0}")]
        public string Instrucktions { get; set; }
        [Required(ErrorMessage = "Please provide a glasstype")]
        public int? GlassTypeId { get; set; }
        public ICollection<int> Tools { get; set; }
        [Required]
        public List<CocktailIngredientRequestDto> Ingredient { get; set; }
    }
}
