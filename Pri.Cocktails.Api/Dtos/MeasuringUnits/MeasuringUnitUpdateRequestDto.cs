using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.MeasuringUnits
{
    public class MeasuringUnitUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill in {0}")]
        [MaxLength(100, ErrorMessage = "{0} is to long")]
        public string Name { get; set; }
    }
}
