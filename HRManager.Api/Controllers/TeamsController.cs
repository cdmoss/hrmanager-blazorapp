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
    [Route(Constants.ControllerNames.Teams)]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IDbSeeder _seederService;
        private readonly IWebHostEnvironment _env;

        public TeamsController(ITeamService memberService, IWebHostEnvironment env, IDbSeeder seeder)
        {
            _teamService = memberService;
            _env = env;
            _seederService = seeder;
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpGet(Constants.ControllerEndpoints.FullTeam)]
        public async Task<IActionResult> GetMembersFull()
        {
            var result = await _teamService.GetMembers<AdminMemberDto>();
            return new ObjectResult(result);
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpGet(Constants.ControllerEndpoints.MinimalTeam)]
        public async Task<IActionResult> GetMembersMinimal()
        {
            return new ObjectResult(await _teamService.GetMembers<MemberMinimalDto>());
        }

        [HttpPost(Constants.ControllerEndpoints.Register)]
        public async Task<IActionResult> Register([FromBody]MemberRegisterDto dto)
        {

            var result = await _teamService.AddMember(dto);
            return new ObjectResult(result);
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpPost(Constants.ControllerEndpoints.UpdateAdmin)]
        public async Task<IActionResult> UpdateMemberForAdmin([FromBody]AdminMemberDto dto)
        {
            return new ObjectResult(await _teamService.UpdateMemberForAdmin(dto));
        }
        
        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpPost(Constants.ControllerEndpoints.UpdateMember)]
        public async Task<IActionResult> UpdateMemberForMember([FromBody]NonAdminMemberDto dto)
        {
            return new ObjectResult(await _teamService.UpdateMemberForMember(dto));
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpPost(Constants.ControllerEndpoints.Delete)]
        public async Task<IActionResult> DeleteMember(int id)
        {
            return new ObjectResult(await _teamService.DeleteMember(id));
        }

        [HttpGet(Constants.ControllerEndpoints.Seed)]
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
