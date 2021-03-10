using Blazored.Modal;
using Blazored.Modal.Services;
using HRManager.Blazor.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class ClockInModalBase : ComponentBase
    {
        [Inject]
        public IPositionService PositionService { get; set; }
        [Inject]
        public IMemberService MemberService { get; set; }
        [Inject]
        public ITimesheetService TSService { get; set; }
        [CascadingParameter]
        public BlazoredModalInstance Modal { get; set; }
        [Parameter]
        public TimeEntryCreateDto ClockInEntry { get; set; }

        protected CustomValidator timeEntryValidator = new CustomValidator();
        protected List<Position> positions = new List<Position>();
        protected List<MemberMinimalDto> members = new List<MemberMinimalDto>();
        protected List<string> pageErrors = new List<string>();

        protected override void OnInitialized()
        {
            var posResult = PositionService.GetPositions();
            if (posResult.Successful)
            {
                positions = posResult.Data;
            }
            else
            {
                pageErrors.Add(posResult.Error);
            }

            var memResult = MemberService.GetMinimalMembers();
            if (memResult.Successful)
            {
                members = memResult.Data;
            }
            else
            {
                pageErrors.Add(memResult.Error);
            }
        }

        protected async Task ClockIn()
        {
            timeEntryValidator.ClearErrors();

            var errors = new Dictionary<string, List<string>>();

            if (ClockInEntry.PositionId == 0)
            {
                errors.Add(nameof(TimeEntry.PositionId), new List<string>() { "A position must be selected." });
            }
            if (ClockInEntry.MemberId == 0)
            {
                errors.Add(nameof(TimeEntry.MemberId), new List<string>() { "A member must be selected" });
            }

            if (errors.Count() > 0)
            {
                timeEntryValidator.DisplayErrors(errors);
            }
            else
            {
                ClockInEntry.StartTime = DateTime.Now;
                var result = await TSService.PunchClock(ClockInEntry);
                await Modal.CloseAsync(ModalResult.Ok(result));
            }
        }

        protected async Task ModalCancel()
        {
            await Modal.CloseAsync(ModalResult.Cancel());
        }
    }
}
