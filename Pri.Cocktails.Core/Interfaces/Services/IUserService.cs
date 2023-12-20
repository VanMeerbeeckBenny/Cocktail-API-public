using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticateResultModel> Login(string username, string password);
        Task Logout();
        Task<AuthenticateResultModel> Register(string firstname, string lastname, string username,DateTime dateOfBirth, string password,
            string streetname, string houseNumber, string postalcode, string city, string country);        
        
    }
}
