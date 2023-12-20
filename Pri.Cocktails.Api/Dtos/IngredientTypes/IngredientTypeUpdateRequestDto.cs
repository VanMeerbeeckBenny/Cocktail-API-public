using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.IngredientTypes
{
    public class IngredientTypeUpdateRequestDto : IngredientTypeRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
    }
}
