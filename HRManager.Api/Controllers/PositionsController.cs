using HRManager.Api.Data;
using HRManager.Api.Services;
using HRManager.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Controllers
{
    [Route(Constants.ControllerNames.Positions)]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IDbSeeder _seeder;

        public PositionsController(IPositionService positionService, IDbSeeder seeder)
        {
            _positionService = positionService;
            _seeder = seeder;
        }

        [HttpGet(Constants.Routes.All)]
        public async Task<IActionResult> GetAllPositions()
        {
            var positions = await _positionService.GetPositions();
            return new ObjectResult(positions);
        }

        [HttpGet(Constants.Routes.Seed)]
        public IActionResult SeedPositions()
        {
            var result = _seeder.SeedPositions();
            return new ObjectResult(result);
        }
    }
}
