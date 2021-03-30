using HRManager.Blazor.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
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
        [Inject]
        public ITeamService _memberService { get; set; }

        protected List<AdminAlertListDto> alerts =  new List<AdminAlertListDto>();
        protected List<string> errors = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            var result = await _alertService.GetAdminAlerts();
            if (!result.Successful)
            {
                errors.Add(result.Error);
                return;
            }

            alerts = result.Data;

            if (alerts.Count > 0)
            {
                foreach (var alert in alerts)
                {
                    if (string.IsNullOrEmpty(alert.AddressedBy))
                    {
                        alert.AddressedBy = "Unaddressed";
                    }
                }
            }
        }

        protected async Task UpdateStatus(AdminMemberDto member, ApprovalStatus status)
        {
            member.ApprovalStatus = status;
            //alert.AddressedBy = 
            await _memberService.UpdateMember(member);
        }

        protected async Task DeleteAlert(AdminAlertListDto alert)
        {
            alert.Archived = true;
            //alert.AddressedBy = 
            await _alertService.UpdateAlert(alert);
        }

        protected async Task BeginActionHandler(ActionEventArgs<AdminAlertListDto> args)
        {

        }

        protected async Task GoToMemberDetails(RecordDoubleClickEventArgs<AdminAlertListDto> args)
        {
            
        }
    }
}
