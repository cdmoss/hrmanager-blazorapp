﻿using HRManager.Api.Services;
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
    [Route("[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftsController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetMembers()
        {
            return new ObjectResult(await _shiftService.GetShifts());
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddShift([FromBody] List<ShiftReadEditDto> dtos)
        {
            return new ObjectResult(await _shiftService.AddShifts(dtos));
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateShift([FromBody] List<ShiftReadEditDto> dtos)
        {
            return new ObjectResult(await _shiftService.UpdateShifts(dtos));
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteShift([FromBody]List<int> ids)
        {
            return new ObjectResult(await _shiftService.DeleteShifts(ids));
        }
    }
}
