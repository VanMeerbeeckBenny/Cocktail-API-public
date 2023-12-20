using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Api.AutoMapper;
using Pri.Cocktails.Api.Dtos.Ingredients;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pri.Cocktails.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : BaseController<IIngredientService,Ingredient, IngredientBasicResponseDto>
    {
        private readonly IImageService _imageService;

        public IngredientsController(IIngredientService ingredientService,IImageService imageService):base(ingredientService)
        {
            _imageService = imageService;
        }

        [HttpGet("{id:int}/cocktails")]
        public async Task<IActionResult> GetCoctailsFromIngredient(int id)
        {
            var cocktail = await _itemService.GetCocktailFromIngredientAsync(id);
            if (!cocktail.IsSucces) return NotFound();
            var cocktailDto = CocktailProfile.CreateResponseDto(cocktail.Items,_imageService);
            return Ok(cocktailDto);
        }

        [HttpGet("{needle}")]
        public async Task<IActionResult> SearchByNameAsync(string needle)
        {
            var result = await _itemService.SearchByNameAsync(needle);
            if (!result.IsSucces) return NotFound();
            var itemDto = CreateResponseDto(result.Items);
            return Ok(itemDto);

        }

        [HttpGet("user")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> GetByRole()
        {
            var role = User.FindFirst(c => c.Type == ClaimTypes.Role).Value;
            string currentUserId = role != null ? User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value : null;

            var result = await _itemService.GetByRole(role, currentUserId);
            if (!result.IsSucces) return NotFound();
            var itemDto = IngredientProfile.CreateResponseDto(result.Items, _imageService);
            return Ok(itemDto);

        }

        [HttpDelete]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Delete(int id)
        {
            string role = User.FindFirst(c => c.Type == ClaimTypes.Role).Value;
            string userId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var result = await _itemService.DeleteAsync(id, userId, role);
            if (result.IsSucces) return Ok($"{nameof(Ingredient)} is deleted");
            return BadRequest(result.ValidationResults);
        }

        [HttpPost]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Add([FromForm]IngredientRequestDto ingredientRequestDto)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState.Values);
            string currentUserId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var result = await _itemService.AddAsync(
                currentUserId,
                ingredientRequestDto.Name,
                ingredientRequestDto.IngredientTypeId,
                ingredientRequestDto.Picture
                );
            if (result.IsSucces) return Ok("Ingredient has been added");
            return BadRequest(result.ValidationResults);
        }

        [HttpPut]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Update([FromForm]IngredientUpdateRequestDto ingredientUpdateRequestDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values);

            var role = User.FindFirst(c => c.Value == "user");
            string currentUserId = role != null ? User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value : null;

            var result = await _itemService.UpdateAsync(
                currentUserId,
                ingredientUpdateRequestDto.Id,
                ingredientUpdateRequestDto.Name,
                ingredientUpdateRequestDto.IngredientTypeId,
                ingredientUpdateRequestDto.Picture
                );

            if (result.IsSucces) return Ok("Ingredient is updated");
            return BadRequest(result.ValidationResults);
        }

       

        protected override IEnumerable<IngredientBasicResponseDto> CreateResponseDto(IEnumerable<Ingredient> ingredients)
        {
            return IngredientProfile.CreateResponseDto(ingredients, _imageService);
        }
    }
}
