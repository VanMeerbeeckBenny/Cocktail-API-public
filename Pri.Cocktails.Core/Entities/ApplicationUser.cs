using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Cocktail> Cocktails { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
