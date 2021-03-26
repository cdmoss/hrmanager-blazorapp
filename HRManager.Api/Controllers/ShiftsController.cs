using HRManager.Api.Services;
using HRManager.Common;
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
    [Route(Constants.ControllerNames.Shifts)]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftsController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        //[Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpGet(Constants.ControllerEndpoints.All)]
        public async Task<IActionResult> GetShifts()
        {
            return new ObjectResult(await _shiftService.GetShifts());
        }

        //[Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpPost(Constants.ControllerEndpoints.Add)]
        public async Task<IActionResult> AddShift([FromBody] List<ShiftReadEditDto> dtos)
        {
            return new ObjectResult(await _shiftService.AddShifts(dtos));
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpPost(Constants.ControllerEndpoints.Update)]
        public async Task<IActionResult> UpdateShift([FromBody] List<ShiftReadEditDto> dtos)
        {
            return new ObjectResult(await _shiftService.UpdateShifts(dtos));
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpPost(Constants.ControllerEndpoints.Delete)]
        public async Task<IActionResult> DeleteShift([FromBody]List<int> ids)
        {
            return new ObjectResult(await _shiftService.DeleteShifts(ids));
        }
    }
}
