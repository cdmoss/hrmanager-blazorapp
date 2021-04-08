using HRManager.Blazor.Shared;
using HRManager.Common;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class AdminPositionPickerBase : PositionPickerBase<AdminMemberDto>
    {
        protected List<string> assignedPositions = new List<string>();
        protected List<string> preferredAndAssignedPositions = new List<string>();

        protected override void OnInitialized()
        {
            SetupPositions();
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

            Member.Positions = memberPositions;

            await MemberChanged.InvokeAsync(Member);
        }

        protected override void SetupPositions()
        {
            base.SetupPositions();
            assignedPositions = Member.Positions.Where(p => p.Association == AssociationType.Assigned).Select(p => p.Position.Name).ToList();
            preferredAndAssignedPositions = Member.Positions.Where(p => p.Association == AssociationType.PreferredAndAssigned).Select(p => p.Position.Name).ToList();
        }
    }
}
