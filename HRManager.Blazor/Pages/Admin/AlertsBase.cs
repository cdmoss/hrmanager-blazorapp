using HRManager.Blazor.Services;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class AlertsBase : ComponentBase
    {
        [Inject]
        public IAlertService _alertService { get; set; }

        protected List<AdminAlertListDto> alerts =  new List<AdminAlertListDto>();
        protected List<string> errors = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            var result = await _alertService.GetAdminAlerts();
            if (!result.Successful)
            {
                errors.Add(result.Error);
            }

            alerts = result.Data;
        }
    }
}
