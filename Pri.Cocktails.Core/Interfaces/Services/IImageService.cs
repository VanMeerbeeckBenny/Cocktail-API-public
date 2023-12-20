using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Interfaces.Services
{
    public interface IImageService
    {
        string GetUrl<T>(string fileName);
        Task<string> AddImageAsync<T>(IFormFile image);
    }
}
