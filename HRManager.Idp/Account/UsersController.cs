using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common.Dtos;
using HRManager.Idp.Services;

namespace HRManager.Idp.Account
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]MemberRegisterDto dto)
        {
            return new ObjectResult(await _userService.RegisterUser(dto));
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove()
        {
            return null;
        }
    }
}
