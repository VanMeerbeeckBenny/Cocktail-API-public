using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pri.Cocktails.Api.Dtos.Cocktails;
using Pri.Cocktails.Api.AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Pri.Cocktails.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailsController : BaseController<ICocktailService, Cocktail, CocktailResponseDto>
    {
        private readonly IImageService _imageService;
        public CocktailsController(ICocktailService cocktailService, IImageService imageService) : base(cocktailService)
        {
            _imageService = imageService;
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
            string role = User.FindFirst(c => c.Type == ClaimTypes.Role).Value;
            string currentUserId = role != null ? User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value : null;

            var result = await _itemService.GetByRole(role, currentUserId);
            if (!result.IsSucces) return NotFound();
            var itemDto = CocktailProfile.CreateResponseDto(result.Items, _imageService);
            return Ok(itemDto);

        }

        [HttpDelete]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Delete(int id)
        {
            string role = User.FindFirst(c => c.Type == ClaimTypes.Role).Value;
            string userId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var result = await _itemService.DeleteAsync(id, userId, role);
            if (result.IsSucces) return Ok($"{nameof(Cocktail)} is deleted");
            return BadRequest(result.ValidationResults);
        }

        [HttpPost]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Add([FromForm] CocktailRequestDto cocktailRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            string currentUserId =User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var result = await _itemService.AddAsync(
                currentUserId,
                cocktailRequestDto.CocktailCategoryId,
                cocktailRequestDto.Picture,
                cocktailRequestDto.Instrucktions,
                cocktailRequestDto.GlassTypeId,
                cocktailRequestDto.Name,
                cocktailRequestDto.Tools,
                cocktailRequestDto.Ingredient.Select(i => new CocktailIngredient
                {
                    IngredientId = i.IngredientId,
                    Amount = i.Amount,
                    MeasuringUnitId = i.MeasuringUnitId
                }).ToList()
                );
            if (!result.IsSucces) return BadRequest("Cocktail is not added");
            else return Ok("Cocktail is added");

        }

        [HttpPut]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Update([FromForm] CocktailUpdateRequestDto cocktailUpdateRequestDto)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState.Values);            

            var role = User.FindFirst(c => c.Value == "user");
            string currentUserId = role != null ? User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value : null;

            var result = await _itemService.UpdateAsync(
                currentUserId,
                cocktailUpdateRequestDto.Id,
                cocktailUpdateRequestDto.CocktailCategoryId,
                cocktailUpdateRequestDto.Picture,
                cocktailUpdateRequestDto.Instrucktions,
                cocktailUpdateRequestDto.GlassTypeId,
                cocktailUpdateRequestDto.Name,
                cocktailUpdateRequestDto.Tools,
                cocktailUpdateRequestDto.Ingredient.Select(i => new CocktailIngredient
                {
                    IngredientId = i.IngredientId,
                    Amount = i.Amount,
                    MeasuringUnitId = i.MeasuringUnitId
                }).ToList()
                );
            if (!result.IsSucces) return BadRequest(result.ValidationResults);
            else return Ok("Cocktail is updated");

        }

        protected override IEnumerable<CocktailResponseDto> CreateResponseDto(IEnumerable<Cocktail> cocktails)
        {
            return CocktailProfile.CreateResponseDto(cocktails, _imageService);
        }
    }
}
