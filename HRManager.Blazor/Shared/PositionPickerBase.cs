using HRManager.Blazor.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Shared
{
    public class PositionPickerBase<TMemberDto> : ComponentBase where TMemberDto : MemberEditDto
    {
        [Inject]
        protected IPositionService _posService { get; set; }
        [Parameter]
        public TMemberDto Member { get; set; }
        [Parameter]
        public EventCallback<TMemberDto> MemberChanged { get; set; }
        [Parameter]
        public List<Position> Positions { get; set; }
        protected List<string> preferredPositions;
        protected List<string> errors;

        protected override void OnInitialized()
        {
            SetupPositions();
        }

        public virtual async Task UpdatePositions() 
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

        protected virtual void SetupPositions()
        {
            preferredPositions = Member.Positions.Where(p => p.Association == AssociationType.Preferred).Select(p => p.Position.Name).ToList();
            Positions = (_posService.GetPositions()).Validate(errors);
        }
    }
}
