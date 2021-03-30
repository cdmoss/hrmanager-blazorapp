using HRManager.Api.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HRManager.Blazor.Pages.Member
{
    public class InformationBase : ComponentBase
    {
        [Inject]
        protected ITeamService _teamService { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }

        [Parameter]
        public NonAdminMemberDto SelectedMember { get; set; }

        protected string selectedTab;

        protected override async Task OnInitializedAsync()
        {
            var memberIdString = (await authenticationStateTask).User.Claims.FirstOrDefault(m => m.Type == "member_id").Value;
            int memberIdInt = 0;
            if (int.TryParse(memberIdString, out memberIdInt))
            {
                List<string> errors = new List<string>();
                var result = await _teamService.GetMember<NonAdminMemberDto>(memberIdInt);

                SelectedMember = result.Validate(errors);
                
            }
            selectedTab = SelectedMember.ApprovalStatus == ApprovalStatus.Pending ? "check" : "personal";
        }

        protected void OnTabChanged(string name)
        {
            selectedTab = name;
        }
    }
}
