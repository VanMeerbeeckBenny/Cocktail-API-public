using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.GlassTypes
{
    public class GlassTypeRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]
        [MaxLength(100, ErrorMessage = "{0} is to long")]
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
    }
}
