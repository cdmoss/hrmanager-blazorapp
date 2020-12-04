using HRManager.Api.Data;
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
    public class PositionsController : ControllerBase
    {
        private readonly MainContext _context;

        public PositionsController(MainContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllPositions()
        {
            var positions = _context.Positions.Where(p => p.Name != "All").ToList();

            return new ObjectResult(positions);
        }
    }
}
