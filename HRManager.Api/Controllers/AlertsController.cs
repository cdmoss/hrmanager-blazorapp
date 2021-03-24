using HRManager.Api.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet("admin")]
        public IActionResult GetAdminAlerts()
        {
            return new ObjectResult(_alertService.GetAdminAlerts());
        }
    }
}
