using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.MeasuringUnits
{
    public class MeasuringUnitRequestDto
    {
        [Required(ErrorMessage = "Please fill in {0}")]
        [MaxLength(100, ErrorMessage = "{0} is to long")]
        public string Name { get; set; }
    }
}
