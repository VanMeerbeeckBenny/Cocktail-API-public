using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Api.Dtos.IngredientTypes;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Cocktails.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "admin")]
    public class IngredientTypesController : BaseController<IIngredientTypeService,IngredientType,IngredientTypeResponseDto>
    {
        public IngredientTypesController(IIngredientTypeService ingredientTypeService):base(ingredientTypeService)
        {

        }

        [HttpDelete]        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _itemService.DeleteAsync(id);
            if (result.IsSucces) return Ok($"{nameof(IngredientType)} is deleted");
            return BadRequest(result.ValidationResults);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IngredientTypeRequestDto ingredientTypeRequestDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _itemService.AddAsync(ingredientTypeRequestDto.Name);

            if (result.IsSucces) return Ok("Ingredienttype is addet");
            return BadRequest(result.ValidationResults);
        }

        [HttpPut]
        public async Task<IActionResult> Update(IngredientTypeUpdateRequestDto ingredientTypeUpdateRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _itemService.UpdateAsync(
                ingredientTypeUpdateRequestDto.Id,
                ingredientTypeUpdateRequestDto.Name);

            if (result.IsSucces) return Ok("Ingredienttype is updated");
            return BadRequest(result.ValidationResults);
        }
        protected override IEnumerable<IngredientTypeResponseDto> CreateResponseDto(IEnumerable<IngredientType> ingredientTypes)
        {
            return ingredientTypes.Select(i => new IngredientTypeResponseDto
            {
                Id = i.Id,
                Name = i.Name,
            });
        }
    }
}
