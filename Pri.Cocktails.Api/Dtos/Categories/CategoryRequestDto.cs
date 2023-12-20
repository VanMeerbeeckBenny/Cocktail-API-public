using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Categories
{
    public class CategoryRequestDto
    {
        [Required(ErrorMessage = "Please fill in {0}!")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
