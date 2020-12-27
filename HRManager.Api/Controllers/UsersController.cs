using HRManager.Api.Services;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Controllers
{
    [Authorize]
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet("members")]
        public async Task<IActionResult> GetMembers()
        {
            return new ObjectResult(await _userService.GetMembers<MemberAdminReadEditDto>());
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("update-member")]
        public async Task<IActionResult> UpdateMember([FromBody]MemberAdminReadEditDto dto)
        {
            return new ObjectResult(await _userService.UpdateMember(dto));
        }
    }
}
