using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Core.Interfaces.Services;
using Pri.Cocktails.Core.Services.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services
{
    public class GlassTypeService : BaseService<IGlassTypeRepository,GlassType>,IGlassTypeService
    {
        private readonly IImageService _imageService;
        private readonly ICocktailRepository _cocktailRepository;

        public GlassTypeService(IGlassTypeRepository glassTypeRepository,ICocktailRepository cocktailRepository, IImageService imageService):base(glassTypeRepository)
        {
            _imageService = imageService;
            _cocktailRepository = cocktailRepository;
        }

        public async Task<ItemResultModel<GlassType>> AddAsync(string name, IFormFile image)
        {
            var glassType = new GlassType
            {
                Name = name,
                Picture = await _imageService.AddImageAsync<GlassType>(image)
            };
                        
            if(!await _itemRepository.AddAsync(glassType))
            {
                return new ItemResultModel<GlassType>
                {
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Something went wrong!!")
                        }
                };
            }

            return new ItemResultModel<GlassType> { IsSucces = true };

        }

        public async Task<ItemResultModel<GlassType>> UpdateAsync(int id, string name, IFormFile image)
        {
            var glassType = await _itemRepository.GetByIdAsync(id);
            if(glassType == null)
            {
                return new ItemResultModel<GlassType>
                {
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Something went wrong!!")
                        }
                };
            }

            glassType.Name = name;            
            if (image != null) glassType.Picture = await _imageService.AddImageAsync<GlassType>(image);

            if (!await _itemRepository.UpdateAsync(glassType))
            {
                return new ItemResultModel<GlassType>
                {
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Something went wrong!!")
                        }
                };
            }

            return new ItemResultModel<GlassType> { IsSucces = true };
        }


        public async Task<ItemResultModel<GlassType>> DeleteAsync(int id)
        {
            var glassType = await _itemRepository.GetByIdAsync(id);
            if (glassType == null)
            {
                return new ItemResultModel<GlassType>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("GlassType do's not exists!!")
                    }
                };
            }
            //prevent deletion when cocktails are using this
            bool haseCocktails = _cocktailRepository.GetAll().Any(c => c.GlassTypeId == id);
            if (haseCocktails)
            {
                return new ItemResultModel<GlassType>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Can not delete beceause some cocktails are using this!!")
                    }
                };
            }

            await _itemRepository.DeleteAsync(glassType);
            return new ItemResultModel<GlassType> { IsSucces = true };
        }
    }


}
