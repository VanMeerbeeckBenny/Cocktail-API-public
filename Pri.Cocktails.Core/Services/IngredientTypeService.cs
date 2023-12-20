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
    public class IngredientTypeService : BaseService<IIngredientTypeRepository,IngredientType>, IIngredientTypeService
    {        

        public IngredientTypeService(IIngredientTypeRepository ingredientTypeRepository):base(ingredientTypeRepository)
        {
           
        }

        public async Task<ItemResultModel<IngredientType>> AddAsync(string name)
        {
            var ingredientType = new IngredientType { Name = name };

            if (!await _itemRepository.AddAsync(ingredientType))
            {
                return new ItemResultModel<IngredientType>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something wnet wrong!")
                    }
                };
            }

            return new ItemResultModel<IngredientType> { IsSucces = true };
        }

        public async Task<ItemResultModel<IngredientType>> UpdateAsync(int id,string name)
        {
            var ingredientType = await _itemRepository.GetByIdAsync(id);

            if (ingredientType == null)
            {
                return new ItemResultModel<IngredientType>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!")
                    }
                };
            }

            ingredientType.Name = name;

            if (!await _itemRepository.UpdateAsync(ingredientType))
            {
                return new ItemResultModel<IngredientType>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!")
                    }
                };
            }

            return new ItemResultModel<IngredientType> { IsSucces = true };
        }

        public async Task<ItemResultModel<IngredientType>> DeleteAsync(int id)
        {
            var ingredientType = await _itemRepository.GetByIdAsync(id);
            if (ingredientType == null)
            {
                return new ItemResultModel<IngredientType>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Ingredient type do's not exists!!")
                    }
                };
            }
            //prevent deletion when ingredients are using this
            bool haseIngredient = ingredientType.Ingredients.Any();

            if (haseIngredient)
            {
                return new ItemResultModel<IngredientType>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Can not delete beceause some ingredients are using this!!")
                    }
                };
            }

            await _itemRepository.DeleteAsync(ingredientType);
            return new ItemResultModel<IngredientType> { IsSucces = true };
        }
    }
}
