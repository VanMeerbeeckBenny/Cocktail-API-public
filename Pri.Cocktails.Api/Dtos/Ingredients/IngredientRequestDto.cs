using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Ingredients
{
    public class IngredientRequestDto
    {
        [Required(ErrorMessage ="Please provide a value for {0}")]
        [MaxLength(100, ErrorMessage = "{0} is to long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for IngredientType")]
        public int IngredientTypeId { get; set; }
        public IFormFile Picture { get; set; }
    }
}
