using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Accounts
{
    public class AccountLoginRequestDto
    {
        [Required(ErrorMessage = "Please provide a E-mail!")]
        [EmailAddress(ErrorMessage = "Please provide a valid E-mail!")]
        [MaxLength(320)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide a {0}")]        
        public string Password { get; set; }
    }
}
