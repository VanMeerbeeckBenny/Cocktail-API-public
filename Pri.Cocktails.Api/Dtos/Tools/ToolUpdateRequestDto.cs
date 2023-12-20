using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Tools
{
    public class ToolUpdateRequestDto : ToolRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        
    }
}
