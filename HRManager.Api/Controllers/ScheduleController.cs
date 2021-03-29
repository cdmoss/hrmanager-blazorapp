//using HRManager.Api.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HRManager.Api.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class ScheduleController : ControllerBase
//    {
//        private readonly IScheduleService _scheduleService;

//        public ScheduleController(IScheduleService scheduleService)
//        {
//            _scheduleService = scheduleService;
//        }

//        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
//        [HttpGet("data")]
//        public async Task<IActionResult> GetScheduleData()
//        {
//            return new ObjectResult(await _scheduleService.GetScheduleData());
//        }
//    }
//}
