using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Api.AutoMapper;
using Pri.Cocktails.Api.Dtos.Categories;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Cocktails.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class CategoriesController : BaseController<ICategoryService, Category, CategoryResponseDto>
    {
        private readonly IImageService _imageService;

        public CategoriesController(ICategoryService categoryService,IImageService imageService): base(categoryService)
        {
            _imageService = imageService;
        }

        [HttpGet("{id:int}/cocktails")]
        public async Task<IActionResult> GetCocktailsFromCategory(int id)
        {

            var result = await _itemService.GetCocktailsFromCategoryAsync(id);
            if (!result.IsSucces) return NotFound(result.ValidationResults);

            var cocktailDto =CocktailProfile.CreateResponseDto(result.Items,_imageService);
            return Ok(cocktailDto);

        }

        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)        
        { 
            var result = await _itemService.DeleteAsync(id);
            if (result.IsSucces) return Ok($"{nameof(Category)} is deleted");
            return BadRequest(result.ValidationResults);
        }

        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add(CategoryRequestDto categoryRequestDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _itemService.AddAsync(categoryRequestDto.Name);

            if(result.IsSucces)return Ok("Category is added");
            return BadRequest(result.ValidationResults);
        }

        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update(CategoryUpdateRequestDto categoryUpdateRequestDto)
        {
            if(!ModelState.IsValid)return BadRequest(ModelState.Values);

            var result = await _itemService.UpdateAsync(
                categoryUpdateRequestDto.Id,
                categoryUpdateRequestDto.Name);

            if (result.IsSucces) return Ok("Category is updated.");
            return BadRequest(result.ValidationResults);
        }

        protected override IEnumerable<CategoryResponseDto> CreateResponseDto(IEnumerable<Category> categories)
        {
            return categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
