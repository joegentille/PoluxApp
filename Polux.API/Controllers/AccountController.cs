using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Polux.API.Dtos;
using Polux.API.Errors;
using Polux.Core.Entities.Identity;
using System.Threading.Tasks;

namespace Polux.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            
            if(user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }

            // TODO false es para decirle que no bloquee el usuario luego de equivocarse.
            // Podemos luego investigar como hacer que lo bloquee luego de varios intentos.
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }

            return new UserDto
            {
                Email = user.Email,
                Token = "This will be a token",
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            // TODO por defecto identity esta configurado para aceptar passwords complejos
            // tambien hay la posibilidad de cambiar a aceptar passwords no complejos
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            return new UserDto
            {
                Email = user.Email,
                Token = "This will be a token",
                DisplayName = user.DisplayName
            };
        }
    }
}
