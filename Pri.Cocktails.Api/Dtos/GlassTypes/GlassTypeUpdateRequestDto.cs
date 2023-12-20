using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.GlassTypes
{
    public class GlassTypeUpdateRequestDto : GlassTypeRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        
    }
}
