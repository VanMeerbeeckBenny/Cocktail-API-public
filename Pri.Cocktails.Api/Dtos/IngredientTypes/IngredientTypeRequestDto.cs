using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.IngredientTypes
{
    public class IngredientTypeRequestDto
    {
        [Required(ErrorMessage = "Please fill in a {0}")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
