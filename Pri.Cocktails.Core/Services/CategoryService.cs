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
    public class CategoryService : BaseService<ICategoryRepository, Category>,ICategoryService
    {
        private readonly ICocktailRepository _cocktailRepository;

        public CategoryService(ICategoryRepository categoryRepository,ICocktailRepository cocktailRepository):base(categoryRepository)
        {
            _cocktailRepository = cocktailRepository;
        }

        public async Task<ItemResultModel<Cocktail>> GetCocktailsFromCategoryAsync(int id)
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

            var cocktail = await _cocktailRepository.GetByCategoryIdAsync(id);

            if (cocktail == null || !cocktail.Any())
            {
                result.ValidationResults = new List<ValidationResult>
                {
                    new ValidationResult("Nothing is found!")
                };

                return result;
            }

            result.Items = cocktail;
            result.IsSucces = true;

            return result;

        }

        public async Task<ItemResultModel<Category>> AddAsync(string name)
        {
            var category = new Category
            {
                Name = name
            };

            if (! await _itemRepository.AddAsync(category))
            {
                return new ItemResultModel<Category>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong!!")
                    }
                };
            }

            return new ItemResultModel<Category> { IsSucces = true };

        }

        public async Task<ItemResultModel<Category>> UpdateAsync(int id, string name)
        {
            var category = await _itemRepository.GetByIdAsync(id);

            if (category == null)
            {
                return new ItemResultModel<Category>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong")
                    }
                };
            }

            category.Name = name;

            if(!await _itemRepository.UpdateAsync(category))
            {
                return new ItemResultModel<Category>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Something went wrong")
                    }
                };
            }

            return new ItemResultModel<Category> { IsSucces = true };
        }

        public async Task<ItemResultModel<Category>> DeleteAsync(int id)
        {
            var category = await _itemRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ItemResultModel<Category>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Category do's not exists!!")
                    }
                };
            }
            //prevent deletion when cocktails are using this
            var cocktails = await _cocktailRepository.GetByCategoryIdAsync(id);
            if(cocktails.Any())
            {
                return new ItemResultModel<Category>
                {
                    ValidationResults = new List<ValidationResult>
                    {
                        new ValidationResult("Can not delete beceause some cocktails are using this!!")
                    }
                };
            }

            await _itemRepository.DeleteAsync(category);
            return new ItemResultModel<Category> { IsSucces = true };
        }
    }
}
