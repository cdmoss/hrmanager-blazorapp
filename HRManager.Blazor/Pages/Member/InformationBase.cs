using HRManager.Blazor.Pages.Shared;
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
    public class InformationBase : MemberEditBase
    {
        [Inject]
        protected ITeamService _teamService { get; set; }
        [Inject]
        protected IPositionService _posService { get; set; }

        [Parameter]
        public NonAdminMemberDto Member { get; set; }
        [Parameter]
        public EventCallback<NonAdminMemberDto> MemberChanged { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        
        protected List<string> errors = new List<string>();

        protected override async Task OnInitializedAsync()
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

            Positions = (_posService.GetPositions()).Validate(errors);
        }

        public override async Task UpdatePositions()
        {
            var memberPositions = new List<MemberPositionDto>();

            foreach (var position in preferredPositions)
            {
                var memberPosition = new MemberPositionDto()
                {
                    Position = Positions.FirstOrDefault(p => p.Name == position),
                    Association = AssociationType.Preferred
                };

                memberPositions.Add(memberPosition);
            }

            Member.Positions = memberPositions;

            await MemberChanged.InvokeAsync(Member);
        }

        protected async Task SaveChanges()
        {
            await UpdatePositions();
        }
    }
}
