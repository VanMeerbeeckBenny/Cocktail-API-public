using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Core.Interfaces.Services;
using Pri.Cocktails.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services
{
    public class CocktailService : BaseService<ICocktailRepository,Cocktail>,ICocktailService
    {
        private readonly IImageService _imageService;
        private readonly IToolRepository _toolRepository;

        public CocktailService(ICocktailRepository cocktailRepository,IToolRepository toolRepository,IImageService imageService) : base(cocktailRepository)
        {
            _imageService = imageService;
            _toolRepository = toolRepository;
        }  

       

        public async Task<ItemResultModel<Cocktail>> SearchByNameAsync(string needle)
        {
            var result = new ItemResultModel<Cocktail>();

            if (string.IsNullOrEmpty(needle))
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Enter a Search")
                };
                return result;
            }

            var items = await _itemRepository.SearchByNameAsync(needle);

            if (items == null || !items.Any())
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Nothig is found")
                };
                return result;
            }

            result.Items = items;
            result.IsSucces = true;
            return result;
        }

        public async Task<ItemResultModel<Cocktail>> AddAsync(string userId,int? cocktailCategoryId, IFormFile image, string instructions, int? glassTypeId, string name, ICollection<int> tools, ICollection<CocktailIngredient> ingredients)
        {
            var allTools = await _toolRepository.GetAllAsync();
            var newCocktail = new Cocktail
            {
                UserId = userId,
                CocktailCategoryId = cocktailCategoryId,
                Picture = await _imageService.AddImageAsync<Cocktail>(image),
                Instrucktions = instructions,
                GlassTypeId = glassTypeId,
                Name = name,
                Tools = tools != null ? allTools.Where(t => tools.Contains(t.Id)).ToList() : null

        };


            if (!await _itemRepository.AddAsync(newCocktail))
            {
                return new ItemResultModel<Cocktail>
                {
                    IsSucces = false,
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Something went wrong")
                        }
                };
            }
            //now we have Id of the made Cocktail we can insert ingredients 
            var cocktail = await _itemRepository.GetByIdAsync(newCocktail.Id);
            var result =  await AddIngredients(ingredients, cocktail);
            if (result.IsSucces == false)
            {
                await _itemRepository.DeleteAsync(cocktail);
                return result;
            }
            else return result;
        }

        public async Task<ItemResultModel<Cocktail>> GetByRole(string role, string userId = null)
        {
            IEnumerable<Cocktail> cocktails = null;

            if (role == "admin") cocktails = await _itemRepository.GetAllAsync();
            if (role == "user") cocktails = await  _itemRepository.GetByUserId(userId);

            if (cocktails == null || !cocktails.Any()) return new ItemResultModel<Cocktail>
            {
                ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Something went wrong!")
                }
            };

            return new ItemResultModel<Cocktail>
            {
                IsSucces = true,
                Items = cocktails
            };
        }

        public async Task<ItemResultModel<Cocktail>> UpdateAsync(string currentUserId,int id,int? cocktailCategoryId, IFormFile image, string instructions, int? glassTypeId, string name, ICollection<int> tools, ICollection<CocktailIngredient> ingredients)
        {
            var allTools = await _toolRepository.GetAllAsync();
            var cocktail = await _itemRepository.GetByIdAsync(id);
            
            if (cocktail == null) return new ItemResultModel<Cocktail>
            {
                ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Something went wrong!")
                }
            };

            //check if user owns the cocktail
            if (cocktail.UserId.ToString() != currentUserId && !String.IsNullOrEmpty(currentUserId))
            {
                return new ItemResultModel<Cocktail>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("No permission!")
                    }
                };
            }

            //Clear tools as some may been removed
            cocktail.Tools.Clear();

            cocktail.CocktailCategoryId = cocktailCategoryId;
            if (image != null) cocktail.Picture = await _imageService.AddImageAsync<Cocktail>(image);
            cocktail.Instrucktions = instructions;
            cocktail.GlassTypeId = glassTypeId;
            cocktail.Name = name;
            cocktail.Tools = tools != null ? allTools.Where(t => tools.Contains(t.Id)).ToList():null;         
            
            return await AddIngredients(ingredients, cocktail);           
            
        }

        public async Task<ItemResultModel<Cocktail>> DeleteAsync(int id,string userId,string role)
        {
            var cocktail = await _itemRepository.GetByIdAsync(id);            

            if (cocktail == null)
            {
                return new ItemResultModel<Cocktail>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Cocktail do's not exists!!")
                    }
                };
            }

            if (role != "admin")
            {
                if (userId != cocktail.UserId)
                {
                    return new ItemResultModel<Cocktail>
                    {
                        ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("No permission!!")
                        }
                    };
                }
            }

            await _itemRepository.DeleteAsync(cocktail);
            return new ItemResultModel<Cocktail> { IsSucces = true };
        }

        private async Task<ItemResultModel<Cocktail>> AddIngredients(ICollection<CocktailIngredient> ingredients, Cocktail cocktail)
        {
            
            //Empty list in case items were removed
            cocktail.CocktailIngredient.Clear();
            //Add ingredients            
            cocktail.CocktailIngredient = ingredients.Select(i => new CocktailIngredient
            {
                CocktailId = cocktail.Id,
                IngredientId = i.IngredientId,
                Amount = i.Amount,
                MeasuringUnitId = i.MeasuringUnitId,
            }).ToList();

            if (!await _itemRepository.UpdateAsync(cocktail))
            {
                //If something whent wrong in creating we dont want a cocktail without ingredients                
                return new ItemResultModel<Cocktail>
                {                    
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Something went wrong!!")
                        }
                };
            }

            return new ItemResultModel<Cocktail> { IsSucces = true };

        }    

    }
}
