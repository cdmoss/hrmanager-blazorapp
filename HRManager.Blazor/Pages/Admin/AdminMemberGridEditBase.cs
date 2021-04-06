using HRManager.Blazor.Pages.Shared;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class AdminMemberGridEditBase : MemberEditBase
    {
        [Parameter]
        public AdminMemberDto SelectedMember { get; set; }
        [Parameter]
        public EventCallback<AdminMemberDto> SelectedMemberChanged { get; set; }

        protected List<string> assignedPositions = new List<string>();
        protected List<string> preferredAndAssignedPositions = new List<string>();

        protected override void OnInitialized()
        {
            preferredPositions = SelectedMember.Positions.Where(p => p.Association == AssociationType.Preferred).Select(p => p.Position.Name).ToList();
            assignedPositions = SelectedMember.Positions.Where(p => p.Association == AssociationType.Assigned).Select(p => p.Position.Name).ToList();
            preferredAndAssignedPositions = SelectedMember.Positions.Where(p => p.Association == AssociationType.PreferredAndAssigned).Select(p => p.Position.Name).ToList();
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

            foreach (var position in assignedPositions)
            {
                var memberPosition = new MemberPositionDto()
                {
                    Position = Positions.FirstOrDefault(p => p.Name == position),
                    Association = AssociationType.Assigned
                };

                memberPositions.Add(memberPosition);
            }

            foreach (var position in preferredPositions)
            {
                if (assignedPositions.Contains(position))
                {
                    var memberPosition = new MemberPositionDto()
                    {
                        Position = Positions.FirstOrDefault(p => p.Name == position),
                        Association = AssociationType.PreferredAndAssigned
                    };

                    memberPositions.Add(memberPosition);
                }
            }

            SelectedMember.Positions = memberPositions;

            await SelectedMemberChanged.InvokeAsync(SelectedMember);
        }
    }
}
