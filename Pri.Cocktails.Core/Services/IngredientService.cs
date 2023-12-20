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
    public class IngredientService : BaseService<IIngredientRepository, Ingredient>,IIngredientService
    {
        private readonly IImageService _imageService;
        private readonly ICocktailRepository _cocktailRepository;

        public IngredientService(IIngredientRepository ingredientRepository,ICocktailRepository cocktailRepository,IImageService imageService ):base(ingredientRepository)
        {
            _cocktailRepository = cocktailRepository;
            _imageService = imageService;
        }
        public async Task<ItemResultModel<Cocktail>> GetCocktailFromIngredientAsync(int id)
        {
            var result = new ItemResultModel<Cocktail>();

            if (id <= 0)
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Nothing is found")
                };
                return result;
            }

            var cocktails = await _cocktailRepository.GetByIngredientIdAsync(id);

            if (cocktails == null || !cocktails.Any())
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Nothing is found")
                };
                return result;
            }

            result.Items = cocktails;
            result.IsSucces = true;

            return result;
        }

        public async Task<ItemResultModel<Ingredient>> GetByRole(string role, string userId)
        {
            IEnumerable<Ingredient> ingredients = null;

            if (role == "admin") ingredients = await _itemRepository.GetAllAsync();
            if (role == "user") ingredients = await _itemRepository.GetByUserId(userId);

            if (ingredients == null || !ingredients.Any()) return new ItemResultModel<Ingredient>
            {
                ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Something went wrong!")
                }
            };

            return new ItemResultModel<Ingredient>
            {
                IsSucces = true,
                Items = ingredients
            };
        }

        public async Task<ItemResultModel<Ingredient>> SearchByNameAsync(string needle)
        {
            var result = new ItemResultModel<Ingredient>();

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

        public async Task<ItemResultModel<Ingredient>> AddAsync(string currentUserId, string name, int ingredientTypeId, IFormFile picture)
        {
            var ingredient = new Ingredient
            {
                Name = name,
                IngredientTypeId = ingredientTypeId,
                Picture = await _imageService.AddImageAsync<Ingredient>(picture),
                UserId = currentUserId
               
            };
           
            if(!await _itemRepository.AddAsync(ingredient))
            {
                return new ItemResultModel<Ingredient>
                {
                    IsSucces = false,
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Failed to add ingredients")
                        }
                };
            }
            return new ItemResultModel<Ingredient> { IsSucces = true };


        }       


        public async Task<ItemResultModel<Ingredient>> UpdateAsync(string currentUserId,int id,string name, int ingredientTypeId, IFormFile picture)
        {            
            var ingredient = await _itemRepository.GetByIdAsync(id);
            if (ingredient == null)
            {
                return new ItemResultModel<Ingredient>
                {                   
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Failed to update ingredient")
                        }
                };
            }

            //check if user owns the ingredient
            if (ingredient.UserId.ToString() != currentUserId && !String.IsNullOrEmpty(currentUserId))
            {
                return new ItemResultModel<Ingredient>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("No permission!")
                    }
                };
            }

            ingredient.Name = name;
            ingredient.IngredientTypeId = ingredientTypeId;
            if (picture != null)
                ingredient.Picture = await _imageService.AddImageAsync<Ingredient>(picture);

            
            if(!await _itemRepository.UpdateAsync(ingredient))
            {
                return new ItemResultModel<Ingredient>
                {                    
                    ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("Failed to update ingredient")
                        }
                };
            } 
            
            return new ItemResultModel<Ingredient> { IsSucces = true };      

            
        }

        public async Task<ItemResultModel<Ingredient>> DeleteAsync(int id,string userId,string role)
        {            
            var ingredient = await _itemRepository.GetByIdAsync(id);            

            if (ingredient == null)
            {
                return new ItemResultModel<Ingredient>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Ingredient do's not exists!!")
                    }
                };
            }

            //prevent deletion when cocktails are using this
            var cocktails = await _cocktailRepository.GetByIngredientIdAsync(id);
            if (cocktails.Any())
            {
                return new ItemResultModel<Ingredient>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Can not delete beceause some cocktails are using this!!")
                    }
                };
            }

            if (role != "admin")
            {
                if (userId != ingredient.UserId)
                {
                    return new ItemResultModel<Ingredient>
                    {
                        ValidationResults = new List<ValidationResult>
                        {
                            new ValidationResult("No permission!!")
                        }
                    };
                }
            }            

            await _itemRepository.DeleteAsync(ingredient);
            return new ItemResultModel<Ingredient> { IsSucces = true };
        }
    }
}
