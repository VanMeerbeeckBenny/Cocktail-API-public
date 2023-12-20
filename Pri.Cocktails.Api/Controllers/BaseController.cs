using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pri.Cocktails.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<Tinterface,Tclass,TDto> : ControllerBase where Tinterface : IBaseService<Tclass> where Tclass : BaseEntity
    {
        protected readonly Tinterface _itemService;
        protected const string DefaultPicture = "default.png";
        public BaseController(Tinterface inteface)
        {

            _itemService = inteface;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _itemService.GetAllAsync();
            if (!result.IsSucces) return NotFound();
            var itemDto = CreateResponseDto(result.Items);

            return Ok(itemDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _itemService.GetByIdAsync(id);
            if (!result.IsSucces) return NotFound();
            var itemDto = CreateResponseDto(result.Items);
            return Ok(itemDto);
        }       

        protected abstract IEnumerable<TDto> CreateResponseDto(IEnumerable<Tclass> items);
    }
}
