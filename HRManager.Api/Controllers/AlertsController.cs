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
    [Route(Constants.ControllerNames.Alerts)]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpGet(Constants.RoleNames.Admin)]
        public IActionResult GetAdminAlerts()
        {
            return new ObjectResult(_alertService.GetAdminAlerts());
        }

        [Authorize(Roles = Constants.RoleNames.Admin + ", " + Constants.RoleNames.SuperAdmin)]
        [HttpGet(Constants.Routes.Update + "/" + Constants.RoleNames.Admin)]
        public IActionResult UpdateAdminAlerts([FromBody]AdminAlertListDto dto)
        {
            return new ObjectResult(_alertService.UpdateAlert(dto));
        }
    }
}
