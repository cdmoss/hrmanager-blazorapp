using HRManager.Blazor.Pages.Shared;
using HRManager.Blazor.Services;
using HRManager.Blazor.Shared;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HRManager.Blazor.Pages.Member
{
    public class InformationBase : ComponentBase
    {
        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            await GetApprovalStatus();
        }

        protected async Task GetApprovalStatus()
        {
            var memberIdString = (await authenticationStateTask).User.Claims.FirstOrDefault(m => m.Type == "member_id").Value;
            int memberIdInt = 0;
            if (int.TryParse(memberIdString, out memberIdInt))
            {
                Member = (await _teamService.GetMember(memberIdInt)).Validate(errors);
                if (errors.Count() == 0)
                {
                    if (Member.ApprovalStatus == ApprovalStatus.Approved)
                    {
                        selectedTab = "personal";
                    }
                    if (Member.ApprovalStatus == ApprovalStatus.Pending)
                    {
                        selectedTab = "checks";
                    }
                }
            }
        }

        protected async Task SaveChanges()
        {
            await positionPicker.UpdatePositions();
            
            //await _teamService.()
        }
    }
}
