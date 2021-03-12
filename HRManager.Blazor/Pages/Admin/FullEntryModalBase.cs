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
    public class FullEntryModalBase : ComponentBase
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
        public TimeEntryReadEditDto TimeEntry { get; set; }
        [Parameter]
        public bool IsNewEntry { get; set; }

        protected CustomValidator timeEntryValidator = new CustomValidator();
        protected List<Position> positions = new List<Position>();
        protected List<MemberMinimalDto> members = new List<MemberMinimalDto>();
        protected List<string> pageErrors = new List<string>();
        protected DateTime newStartTime = DateTime.Now.Date + new TimeSpan(0, 8, 0, 0, 0);
        protected DateTime newEndTime = DateTime.Now.Date + new TimeSpan(0, 16, 0, 0, 0);
        protected DateTime newDate = DateTime.Now.Date;
        protected bool hideEndTime = false;

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

            if (TimeEntry.MemberId == 0)
            {
                TimeEntry.StartTime = newStartTime;
                TimeEntry.EndTime = newEndTime;
            }
            else
            {
                newStartTime = TimeEntry.StartTime.Date + TimeEntry.StartTime.TimeOfDay;
                if (TimeEntry.EndTime != null)
                {
                    newEndTime = TimeEntry.EndTime.Value.Date + TimeEntry.EndTime.Value.TimeOfDay;
                }
                else
                {
                    hideEndTime = true;
                }

                newDate = TimeEntry.StartTime.Date;
            } 
        }

        protected async Task SaveEntry()
        {
            timeEntryValidator.ClearErrors();

            var errors = new Dictionary<string, List<string>>();

            if (TimeEntry.PositionId == 0)
            {
                errors.Add(nameof(TimeEntry.PositionId), new List<string>() { "A position must be selected." });
            }
            if (TimeEntry.MemberId == 0)
            {
                errors.Add(nameof(TimeEntry.MemberId), new List<string>() { "A member must be selected" });
            }

            if (errors.Count() > 0)
            {
                timeEntryValidator.DisplayErrors(errors);
            }
            else
            {
                TimeEntry.StartTime = newDate.Date + newStartTime.TimeOfDay;
                TimeEntry.EndTime = newDate.Date + newEndTime.TimeOfDay;
                if (IsNewEntry)
                {
                    var newEntry = new TimeEntryCreateDto()
                    {
                        MemberId = TimeEntry.MemberId,
                        PositionId = TimeEntry.PositionId,
                        StartTime = TimeEntry.StartTime,
                        EndTime = TimeEntry.EndTime
                    };

                    var result = await TSService.AddTimeEntry(newEntry);
                    await Modal.CloseAsync(ModalResult.Ok(result));
                }
                else
                {
                    var result = await TSService.UpdateTimeEntry(TimeEntry);
                    await Modal.CloseAsync(ModalResult.Ok(result));
                }
            }
        }

        protected async Task ModalCancel()
        {
            await Modal.CloseAsync(ModalResult.Cancel());
        }
    }
}
