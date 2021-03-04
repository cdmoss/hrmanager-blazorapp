using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common.Dtos;
using HRManager.Idp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HRManager.Idp.Account
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        private readonly IDbSeeder _seederService;

        public UsersController(IUserService userService, IWebHostEnvironment env, IDbSeeder seeder)
        {
            _userService = userService;
            _env = env;
            _seederService = seeder;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]IdentityDto dto)
        {
            return new ObjectResult(await _userService.RegisterUser(dto));
        }

        [HttpPost("update-username")]
        public async Task<IActionResult> Update(string newUsername, string id)
        {
            return new ObjectResult(await _userService.UpdateUsername(newUsername, new Guid(id)));
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("remove")]
        public async Task<IActionResult> Remove(string id)
        {
            var guid = new Guid(id);
            return new ObjectResult(await _userService.RemoveUser(guid));
        }

        // TODO: remove this for production
        [HttpPost("seed")]
        public async Task<IActionResult> Seed([FromBody] List<int> ids)
        {
            if (_env.IsDevelopment())
            {
                var successfulSeed = await _seederService.SeedUsers(ids);

                if (successfulSeed)
                {
                    return Ok();
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            return NotFound();
        }
    }
}
