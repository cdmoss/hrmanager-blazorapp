using HRManager.Api.Data;
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

        public AuthController(MainContext context, UserManager<UserProfile> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterResult { Errors = errors, Successful = false });
            }

            return new ObjectResult(new RegisterResult { Successful = true });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (await IsValidCredentials(dto))
            {
                return new ObjectResult(await GenerateToken(dto.Email));
            }
            else
            {
                return Unauthorized(new LoginResult { Successful = false, Error = "Incorrect email or password."});
            }
        }

        private async Task<bool> IsValidCredentials(LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return false;
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);
            return await _userManager.CheckPasswordAsync(user, dto.Password);
        }

        private async Task<dynamic> GenerateToken(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);

            var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new { ur.UserId, ur.RoleId, r.Name };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToString()),
                // TODO: Add refresh tokens
            };

            foreach (var role in roles)
            {
                //claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var token = new JwtSecurityToken(
                new JwtHeader(
                    // TODO: store key in azure key vault or alternative
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretdsfdsfsfsdfsfsdfsfsfsfsfgghdgfhdf")),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims)
            );

            var result = new LoginResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Successful = true
            };

            return result;
        }
    }
}
