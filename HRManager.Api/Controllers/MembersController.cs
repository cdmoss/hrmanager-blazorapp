using HRManager.Api.Services;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Controllers
{
    [Authorize]
    [Route("members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private ILogger<MembersController> _logger;

        public MembersController(IMemberService userService, ILogger<MembersController> logger)
        {
            _memberService = userService;
            _logger = logger;
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet("all/full")]
        public async Task<IActionResult> GetMembersFull()
        {
            return new ObjectResult(await _memberService.GetMembers<AdminMemberDto>());
        }

        //[Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet("all/minimal")]
        public async Task<IActionResult> GetMembersMinimal()
        {
            return new ObjectResult(await _memberService.GetMembers<MemberMinimalDto>());
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

            var result = await _memberService.AddMember(dto);

            if (result.Successful)
            {
                _logger.LogWarning("User successfully registered.");
                return new ObjectResult(result);
            }

            _logger.LogWarning($"An unsuccessful registration attempt was made:\n {result.Error}.");
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("admin/update-member")]
        public async Task<IActionResult> UpdateMemberForAdmin([FromBody]AdminMemberDto dto)
        {
            return new ObjectResult(await _memberService.UpdateMemberForAdmin(dto));
        }
        
        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("member/update-member")]
        public async Task<IActionResult> UpdateMemberForMember([FromBody] NonAdminMemberDto dto)
        {
            return new ObjectResult(await _memberService.UpdateMemberForMember(dto));
        }
    }
}
