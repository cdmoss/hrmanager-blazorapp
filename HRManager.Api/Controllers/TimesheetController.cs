using HRManager.Api.Services;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("get-archived")]
        public async Task<IActionResult> GetArchivedTimeEntries()
        {
            return new ObjectResult(await _tsService.GetArchivedTimeEntries());
        }

        [HttpGet("get-current")]
        public async Task<IActionResult> GetCurrentTimeEntries()
        {
            return new ObjectResult(await _tsService.GetCurrentTimeEntries());
        }

        [HttpPost("add-full-entry")]
        public async Task<IActionResult> AddFullEntry(TimeEntryCreateDto dto)
        {
            return new ObjectResult(await _tsService.AddFullEntry(dto));
        }

        [HttpPost("punch")]
        public async Task<IActionResult> PunchClock(TimeEntryCreateDto dto)
        {
            return new ObjectResult(await _tsService.PunchClock(dto));
        }

        [HttpGet("seed")]
        public IActionResult Seed()
        {
            return new ObjectResult(_dbSeeder.SeedTimeEntries());
        }
    }
}
