using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Api.Dtos.GlassTypes;
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
    public class GlassTypesController : BaseController<IGlassTypeService,GlassType, GlassTypeResponseDto>
    {
        private readonly IImageService _imageService;
        public GlassTypesController(IGlassTypeService glassTypeService, IImageService imageService) :base(glassTypeService)
        {
            _imageService = imageService;
        }

        [HttpDelete]        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _itemService.DeleteAsync(id);
            if (result.IsSucces) return Ok($"{nameof(GlassType)} is deleted");
            return BadRequest(result.ValidationResults);
        }

        [HttpPost]        
        public async Task<IActionResult> Add([FromForm]GlassTypeRequestDto glassTypeRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _itemService.AddAsync(
                glassTypeRequestDto.Name,
                glassTypeRequestDto.Picture
                );

            if (result.IsSucces) return Ok("GlassType is added");
            return BadRequest(result.ValidationResults);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] GlassTypeUpdateRequestDto glassTypeRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            
            var result = await _itemService.UpdateAsync(
                glassTypeRequestDto.Id,
                glassTypeRequestDto.Name,
                glassTypeRequestDto.Picture
                );

            if (result.IsSucces) return Ok("GlassType is updated");
            return BadRequest(result.ValidationResults);
        }

        protected override IEnumerable<GlassTypeResponseDto> CreateResponseDto(IEnumerable<GlassType> glassTypes)
        {
            return glassTypes
                        .OrderBy(g => g.Name)
                        .Select(g => new GlassTypeResponseDto
                        {
                            Id = g.Id,
                            Name = g.Name,
                            Picture = _imageService.GetUrl<GlassType>(g?.Picture)
                        }).ToList();
        }
    }
    
}
