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
    [Route(Constants.ControllerNames.Timesheet)]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _tsService;
        private readonly IDbSeeder _dbSeeder;

        public TimesheetController(ITimesheetService tsService, IDbSeeder dbSeeder)
        {
            _tsService = tsService;
            _dbSeeder = dbSeeder;
        }

        [HttpGet(Constants.ControllerEndpoints.GetArchived)]
        public async Task<IActionResult> GetArchivedTimeEntries()
        {
            return new ObjectResult(await _tsService.GetArchivedTimeEntries());
        }

        [HttpGet(Constants.ControllerEndpoints.GetCurrent)]
        public async Task<IActionResult> GetCurrentTimeEntries()
        {
            return new ObjectResult(await _tsService.GetCurrentTimeEntries());
        }

        [HttpPost(Constants.ControllerEndpoints.AddFullEntry)]
        public async Task<IActionResult> AddFullEntry(TimeEntryCreateDto dto)
        {
            return new ObjectResult(await _tsService.AddFullEntry(dto));
        }

        [HttpPost(Constants.ControllerEndpoints.Update)]
        public async Task<IActionResult> UpdateEntry(TimeEntryReadEditDto dto)
        {
            return new ObjectResult(await _tsService.UpdateEntry(dto));
        }

        [HttpPost(Constants.ControllerEndpoints.Punch)]
        public async Task<IActionResult> PunchClock(TimeEntryCreateDto dto)
        {
            return new ObjectResult(await _tsService.PunchClock(dto));
        }

        [HttpGet(Constants.ControllerEndpoints.Seed)]
        public IActionResult Seed()
        {
            return new ObjectResult(_dbSeeder.SeedTimeEntries());
        }
    }
}
