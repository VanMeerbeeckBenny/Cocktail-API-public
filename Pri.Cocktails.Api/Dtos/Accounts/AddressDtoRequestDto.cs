using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Accounts
{
    public class AddressDtoRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}!")]
        [MaxLength(150)]
        public string Streetname { get; set; }
        [Required(ErrorMessage = "Please provide a {0}!")]
        [MaxLength(50)]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Please provide a {0}!")]
        [MaxLength(100)]
        public string PostalCode { get; set; }        
        public string City { get; set; }
        [Required(ErrorMessage = "Please provide a {0}!")]
        [MaxLength(150)]
        public string Country { get; set; }
    }
}
