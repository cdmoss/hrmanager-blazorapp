using HRManager.Blazor.Services;
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
        [Inject]
        protected IPositionService _posService { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        public NonAdminMemberDto SelectedMember { get; set; }
        public List<Position> Positions { get; set; }

        protected List<string> errors;
        protected List<string> preferredPositions;
        protected string selectedTab;

        protected override async Task OnInitializedAsync()
        {
            var memberIdString = (await authenticationStateTask).User.Claims.FirstOrDefault(m => m.Type == "member_id").Value;
            int memberIdInt = 0;
            if (int.TryParse(memberIdString, out memberIdInt))
            {
                SelectedMember = (await _teamService.GetMember<NonAdminMemberDto>(memberIdInt)).Validate(errors);
            }

            Positions = (await _posService.GetPositions()).Validate(errors);

            preferredPositions = SelectedMember.Positions.Where(p => p.Association == AssociationType.Preferred).Select(p => p.Position.Name).ToList();

            selectedTab = SelectedMember.ApprovalStatus == ApprovalStatus.Pending ? "check" : "personal";
        }

        protected void OnTabChanged(string name)
        {
            selectedTab = name;
        }
    }
}
