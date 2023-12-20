using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Tools
{
    public class ToolRequestDto
    {
        [Required(ErrorMessage ="Please fill in {0}")]
        [MaxLength(100, ErrorMessage = "{0} is to long")]
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
    }
}
