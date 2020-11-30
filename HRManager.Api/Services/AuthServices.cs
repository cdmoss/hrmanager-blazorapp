using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Auth;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface IAuthService
    {
        Task<LoginResult> LoginUser(LoginDto dto);
        Task<bool> IsValidLoginCredentials(LoginDto dto);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<UserProfile> _userManager;
        private readonly MainContext _context;

        public AuthService(UserManager<UserProfile> userManager, MainContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<LoginResult> LoginUser(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Email);

            var claims = GetClaims(user);

            var token = GenerateToken(claims);

            var result = new LoginResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Successful = true
            };

            return result;
        }

        private JwtSecurityToken GenerateToken(List<Claim> claims)
        {

            var token = new JwtSecurityToken(
                new JwtHeader(
                    // TODO: store key in azure key vault or alternative
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretdsfdsfsfsdfsfsdfsfsfsfsfgghdgfhdf")),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims)
            );

            return token;
        }

        private List<Claim> GetClaims(UserProfile user)
        {
            var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new { ur.UserId, ur.RoleId, r.Name };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToString()),
                // TODO: Add refresh tokens
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return claims;
        }

        public async Task<bool> IsValidLoginCredentials(LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return false;
            }

            var user = await _userManager.FindByNameAsync(dto.Email);

            if (user == null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(user, dto.Password);
        }
    }
}
