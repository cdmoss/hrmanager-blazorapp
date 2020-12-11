using HRManager.Api.Data;
using HRManager.Api.Services;
using HRManager.Common;
using HRManager.Common.Auth;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(MainContext context, IAuthService authService, ILogger<AuthController> logger)
        {
            _context = context;
            _authService = authService;
            _logger = logger;
        }

        // TODO: Implement real registration
        [HttpPost("register")]
        public async Task<IActionResult> Register(MemberRegisterDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                _logger.LogWarning("User attemped register with null data.");
                return BadRequest();
            }

            var result = await _authService.RegisterUser(dto);

            if (result.Successful)
            {
                _logger.LogWarning("User successfully registered.");
                return new ObjectResult(result);
            }

            _logger.LogWarning($"An unsuccessful registration attempt was made:\n {result.Errors}.");
            return BadRequest(result);
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
                _logger.LogWarning("An unsuccessful login attempt was made.");
                return Unauthorized(new LoginResult { Successful = false, Error = "Incorrect email or password."});
            }
        }

        [HttpGet("validate-username")]
        public async Task<IActionResult> ValidateUsername(string username)
        {
            return Ok(await _authService.ValidateUsername(username));
        }
    }
}
