using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Cocktails.Api.AutoMapper;
using Pri.Cocktails.Api.Dtos.Accounts;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pri.Cocktails.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;       
        

        public AccountsController(IUserService userService)
        {
            _userService = userService;     
            
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var result = await _userService.Login(loginRequestDto.Username, loginRequestDto.Password);
            if (!result.IsSucces) return Unauthorized(result.Messages);

            return Ok(new AccountLoginResponseDto { Token = result.Messages.First(),Role = result.Messages.ElementAt(1)});
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult>Register(AccountRegisterRequestDto registerRequestDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values);   

            var result =await _userService.Register(
                registerRequestDto.Firstname,
                registerRequestDto.Lastname,
                registerRequestDto.Username,
                registerRequestDto.DateOfBirth,
                registerRequestDto.Password,                
                registerRequestDto.Address.Streetname,
                registerRequestDto.Address.HouseNumber,
                registerRequestDto.Address.PostalCode,
                registerRequestDto.Address.City,
                registerRequestDto.Address.Country
                );

            if(!result.IsSucces) return BadRequest(result.Messages);
            return Ok(result.Messages);
        }      

        
    }
}
