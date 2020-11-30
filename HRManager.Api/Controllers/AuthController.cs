using HRManager.Api.Data;
using HRManager.Api.Services;
using HRManager.Common;
using HRManager.Common.Auth;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly UserManager<UserProfile> _userManager;
        private readonly IAuthService _authService;

        public AuthController(MainContext context, UserManager<UserProfile> userManager, IAuthService authService)
        {
            _context = context;
            _userManager = userManager;
            _authService = authService;
        }

        // TODO: Implement real registration
        [HttpPost("register")]
        public async Task<IActionResult> Register(TestRegisterDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new UserProfile { UserName = dto.Email, Email = dto.Email };
            var creationResult = await _userManager.CreateAsync(user, dto.Password);
            if (!creationResult.Succeeded)
            {
                var errors = creationResult.Errors.Select(e => e.Description);
                return BadRequest(new RegisterResult { Errors = errors, Successful = false });
            }

            var roleResult = _userManager.AddToRoleAsync(user, Enum.GetName(typeof(UserRole), dto.Role));

            return new ObjectResult(new RegisterResult { Successful = true });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (await _authService.IsValidLoginCredentials(dto))
            {
                return new ObjectResult(await _authService.LoginUser(dto));
            }
            else
            {
                return Unauthorized(new LoginResult { Successful = false, Error = "Incorrect email or password."});
            }
        }
    }
}
