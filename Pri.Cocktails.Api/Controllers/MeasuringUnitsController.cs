using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Api.Dtos.MeasuringUnits;
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
    public class MeasuringUnitsController : BaseController<IMeasuringUnitService, MeasuringUnit,MeasuringUnitResponseDto>
    {
        public MeasuringUnitsController(IMeasuringUnitService inteface) : base(inteface)
        {
        }

        [HttpDelete]        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _itemService.DeleteAsync(id);
            if (result.IsSucces) return Ok($"{nameof(MeasuringUnit)} is deleted");
            return BadRequest(result.ValidationResults);
        }

        [HttpPost]
        public async Task<IActionResult>Add(MeasuringUnitRequestDto measuringUnitRequestDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values);
            var result = await _itemService.AddAsync(measuringUnitRequestDto.Name);
            if(!result.IsSucces) return BadRequest(result.ValidationResults);
            return Ok("Measuring unit is added");
        }

        [HttpPut]
        public async Task<IActionResult> Update(MeasuringUnitUpdateRequestDto measuringUnitUpdateRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            var result = await _itemService.UpdateAsync(
                measuringUnitUpdateRequestDto.Id,
                measuringUnitUpdateRequestDto.Name);

            if (!result.IsSucces) return BadRequest(result.ValidationResults);
            return Ok("Measuring unit is updated");
        }
        protected override IEnumerable<MeasuringUnitResponseDto> CreateResponseDto(IEnumerable<MeasuringUnit> measuringUnits)
        {
            return measuringUnits.Select(mu => new MeasuringUnitResponseDto
            {
                Id = mu.Id,
                Name = mu.Name
            }).ToList();
        }
    }
}
