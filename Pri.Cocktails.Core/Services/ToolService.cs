using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Core.Interfaces.Services;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services
{
    public class ToolService : BaseService<IToolRepository,Tool>,IToolService
    {
        private readonly IImageService _imageService;
        private readonly ICocktailRepository _cocktailRepository;

        public ToolService(IToolRepository toolRepository, ICocktailRepository cocktailRepository, IImageService imageService):base(toolRepository)
        {
           _imageService = imageService;
           _cocktailRepository = cocktailRepository;
        }

        public async Task<ItemResultModel<Tool>> AddAsync(string name, IFormFile image)
        {
            var tool = new Tool
            {
                Name = name,
                Picture = await _imageService.AddImageAsync<Tool>(image)
            };

            if(!await _itemRepository.AddAsync(tool))
            {
                return new ItemResultModel<Tool>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!!")
                    }
                };
            }

            return new ItemResultModel<Tool> { IsSucces = true };
        }

        public async Task<ItemResultModel<Tool>> UpdateAsync(int id,string name, IFormFile image)
        {
            var tool = await _itemRepository.GetByIdAsync(id);

            if(tool == null)
            {
                return new ItemResultModel<Tool>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!!")
                    }
                };
            };

            tool.Name = name;

            if(image !=null)tool.Picture = await _imageService.AddImageAsync<Tool>(image);
            

            if (!await _itemRepository.UpdateAsync(tool))
            {
                return new ItemResultModel<Tool>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!!")
                    }
                };
            };

            return new ItemResultModel<Tool> { IsSucces = true };
        }

        public async Task<ItemResultModel<Tool>> DeleteAsync(int id)
        {
            var tool = await _itemRepository.GetByIdAsync(id);
            if (tool == null)
            {
                return new ItemResultModel<Tool>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Tool do's not exists!!")
                    }
                };
            }
            //prevent deletion when cocktails are using this
            bool haseCocktails = _cocktailRepository.GetAll().Any(c => c.Tools
                                                                    .Select(t => t.Id)
                                                                    .Contains(id));

            if (haseCocktails)
            {
                return new ItemResultModel<Tool>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Can not delete beceause some cocktails are using this!!")
                    }
                };
            }

            await _itemRepository.DeleteAsync(tool);
            return new ItemResultModel<Tool> { IsSucces = true };
        }
    }
}
