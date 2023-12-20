using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Pri.Cocktails.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHostEnvironment _hostEnvironment;
        protected const string defaultFile = "default.png";

        public ImageService(IHttpContextAccessor contextAccessor,IHostEnvironment hostEnvironment)
        {
            _contextAccessor = contextAccessor;
            _hostEnvironment = hostEnvironment;
        }

        public string GetUrl<T>(string fileName)
        {
            string baseImageURL = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}/images/";
            string completePath = $"{baseImageURL}{typeof(T).Name.ToLower()}/{fileName ?? defaultFile}";


            return completePath;
        }

        public async Task<string> AddImageAsync<T>(IFormFile image)
        {
            if (image != null)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                string pathName = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "images", typeof(T).Name.ToLower());

                Directory.CreateDirectory(pathName);

                string fullPath = Path.Combine(pathName, fileName);
                using (FileStream fileStream = new(fullPath, FileMode.Create))
                    await image.CopyToAsync(fileStream);

                return fileName;
            }
            else return null;

        }
    }
}
