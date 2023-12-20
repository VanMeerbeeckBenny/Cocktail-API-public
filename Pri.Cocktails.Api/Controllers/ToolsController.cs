using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Api.Dtos.Tools;
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
    public class ToolsController : BaseController<IToolService,Tool,ToolResponseDto>
    {
        private readonly IImageService _imageService;

        public ToolsController(IToolService toolService,IImageService imageService):base(toolService)
        {
            _imageService = imageService;
        }

        [HttpDelete]       
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _itemService.DeleteAsync(id);
            if (result.IsSucces) return Ok($"{nameof(Tool)} is deleted");
            return BadRequest(result.ValidationResults);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]ToolRequestDto toolRequestDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _itemService.AddAsync(
                toolRequestDto.Name,
                toolRequestDto.Picture
                );

            if (result.IsSucces) return Ok("Tool is added");
            return BadRequest(result.ValidationResults);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ToolUpdateRequestDto toolUpdateRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _itemService.UpdateAsync(
                toolUpdateRequest.Id,
                toolUpdateRequest.Name,
                toolUpdateRequest.Picture
                );

            if (result.IsSucces) return Ok("Tool is Updated");
            return BadRequest(result.ValidationResults);
        }

        
        protected override IEnumerable<ToolResponseDto> CreateResponseDto(IEnumerable<Tool> tools)
        {
            return tools
                    .OrderBy(g => g.Name)
                    .Select(g => new ToolResponseDto
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Picture = _imageService.GetUrl<Tool>(g?.Picture)
                    }).ToList();
        }
    }
}
