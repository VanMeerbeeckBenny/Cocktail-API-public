using System;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Accounts
{
    public class AccountRegisterRequestDto
    {
        [Required(ErrorMessage = "Please provide a E-mail!")]
        [EmailAddress(ErrorMessage = "Please provide a valid E-mail!")]
        [MaxLength(320)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide a {0}!")]
        [MaxLength(100)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please provide a {0}")]
        [MaxLength(100)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please provide a {0}")]       
        [MaxLength(100)]
        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage ="Password are not the same")]
        [Required(ErrorMessage = "Please repeat password!!")]
        [MaxLength(100)]
        public string RepeatPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressDtoRequestDto Address { get; set; }
    }
}
