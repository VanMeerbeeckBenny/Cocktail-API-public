using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Ingredients
{
    public class IngredientUpdateRequestDto : IngredientRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
    }
}
