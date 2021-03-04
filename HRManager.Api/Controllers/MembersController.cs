using HRManager.Api.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Controllers
{
    [Route("members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IDbSeeder _seederService;
        private readonly IWebHostEnvironment _env;

        public MembersController(IMemberService memberService, IWebHostEnvironment env, IDbSeeder seeder)
        {
            _memberService = memberService;
            _env = env;
            _seederService = seeder;
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet("all/full")]
        public async Task<IActionResult> GetMembersFull()
        {
            var result = await _memberService.GetMembers<AdminMemberDto>();
            return new ObjectResult(result);
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet("all/minimal")]
        public async Task<IActionResult> GetMembersMinimal()
        {
            return new ObjectResult(await _memberService.GetMembers<MemberMinimalDto>());
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]MemberRegisterDto dto)
        {

            var result = await _memberService.AddMember(dto);
            return new ObjectResult(result);
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("admin/update")]
        public async Task<IActionResult> UpdateMemberForAdmin([FromBody]AdminMemberDto dto)
        {
            return new ObjectResult(await _memberService.UpdateMemberForAdmin(dto));
        }
        
        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("member/update")]
        public async Task<IActionResult> UpdateMemberForMember([FromBody]NonAdminMemberDto dto)
        {
            return new ObjectResult(await _memberService.UpdateMemberForMember(dto));
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("member/delete")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            return new ObjectResult(await _memberService.DeleteMember(id));
        }

        [HttpGet("seed")]
        public IActionResult Seed()
        {
            if (_env.IsDevelopment())
            {
                return new ObjectResult(_seederService.SeedMembers());
            }
            else
            {
                return NotFound();
            }
        }
    }
}
