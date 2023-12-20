using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Categories
{
    public class CategoryUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill in a {0}")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
