using Microsoft.AspNetCore.Identity;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Core.Interfaces.Services;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService; 
        

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;        
        }          

        public async Task<AuthenticateResultModel> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password,false,false);

            if (!result.Succeeded)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Login failed!" }
                };
            }

            var user = await _userManager.FindByNameAsync(username);
            var claims = (List<Claim>) await _userManager.GetClaimsAsync(user);
            //role word hier opgeslagen en nadien meegegeven om op basis van de role eventueel een menu te maken in de front-end
            string role = claims.Where(c => c.Type == ClaimTypes.Role).Select(r => r.Value).FirstOrDefault();

            var token = _jwtService.GenerateToken(claims);

            var serializedToken = _jwtService.SerializeToken(token);

            return new AuthenticateResultModel
            {
                IsSucces = true,
                Messages = new List<string> { serializedToken,role }
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticateResultModel> Register(string firstname, string lastname, string username,DateTime dateOfBirth, string password, string streetname, string houseNumber, string postalcode, string city, string country)
        {
            Address adress = new Address
            {
                Streetname = streetname,
                HouseNumber = houseNumber,
                PostalCode = postalcode,
                City = city,
                Country = country
            };

            ApplicationUser user = new ApplicationUser
            {
                UserName = username,
                Email = username,
                Firstname = firstname,
                Lastname = lastname,
                DateOfBirth = dateOfBirth,
                Address = adress,
            };

            var result = await _userManager.CreateAsync(user,password);

            if (!result.Succeeded)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Registration failed!" }
                };
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,"user"),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim("Registration-date",DateTime.UtcNow.ToString("yy-MM-dd"))
            };
            await _userManager.AddClaimsAsync(user, claims);

            return new AuthenticateResultModel
            {
                IsSucces = true,
                Messages = new List<string> { "User registered!" }
            };
            
        }
    }
}
