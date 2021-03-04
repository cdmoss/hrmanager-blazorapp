using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Blazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using HRManager.Common;
using Microsoft.AspNetCore.Components.Forms;

namespace HRManager.Blazor.Pages.Admin
{
    public class TimesheetBase : ComponentBase
    {
        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        public ITimesheetService _tsService { get; set; }
        [Inject]
        public IPositionService _posService { get; set; }
        [Inject]
        public IMemberService _memberService { get; set; }
        protected CustomValidator timeEntryValidator;
        protected List<TimeEntryReadEditDto> timeEntries;
        protected TimeEntryCreateDto newEntry = new TimeEntryCreateDto();
        protected List<Position> positions;
        protected List<MemberMinimalDto> members;
        protected List<string> pageErrors = new List<string>();
        protected TSGridEditTemplate editTemplate = new TSGridEditTemplate();
        protected bool showAddEntryModal = false;
        protected bool showClockInModal = false;

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                return;
            }

            var tsResult = await _tsService.GetCurrentTimeEntries();
            if (!tsResult.Successful)
            {
                pageErrors.Add(tsResult.Error);
            }
            timeEntries = tsResult.Data;

            var positionResult = _posService.GetPositions();
            if (!positionResult.Successful)
            {
                pageErrors.Add(positionResult.Error);
            }
            positions = positionResult.Data;

            var membersResult = _memberService.GetMinimalMembers();
            if (!membersResult.Successful)
            {
                pageErrors.Add(membersResult.Error);
            }
            members = membersResult.Data;
        }

        protected async Task BeginActionHandler(ActionEventArgs<TimeEntryReadEditDto> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                var result = await _tsService.UpdateTimeEntry(args.Data);
                if (result.Successful)
                {
                    timeEntries = result.Data;
                }
                else
                {
                    pageErrors.Add(result.Error);
                }
            }
        }

        protected void ShowAddEntryModal()
        {
            showAddEntryModal = true;
        }

        protected void ShowClockInModal()
        {
            showClockInModal = true;
        }

        protected async Task SaveFullEntry()
        {
            timeEntryValidator.ClearErrors();

            var errors = new Dictionary<string, List<string>>();

            if (newEntry.PositionId == 0)
            {
                errors.Add(nameof(newEntry.PositionId), new List<string>() { "A position must be selected." });
            }
            if (newEntry.MemberId == 0)
            {
                errors.Add(nameof(newEntry.MemberId), new List<string>() { "A member must be selected" });
            }

            if (errors.Count() > 0)
            {
                timeEntryValidator.DisplayErrors(errors);
            }
            else
            {
                var result = await _tsService.AddTimeEntry(newEntry);
                if (result.Successful)
                {
                    showAddEntryModal = false;

                    await GetArchived();
                    //TODO: add success indicator
                }
                else
                {
                    //TODO: add add failure indicator
                }
            }
        }

        protected async Task ClockIn()
        {
            var errors = ValidateEntryFormErrors();

            if (errors.Count() > 0)
            {
                timeEntryValidator.DisplayErrors(errors);
            }
            else
            {
                newEntry.StartTime = DateTime.Now;

                var result = await _tsService.PunchClock(newEntry);
                if (result.Successful)
                {
                    showClockInModal = false;

                    await GetCurrent();
                    //TODO: add success indicator
                }
                else
                {
                    //TODO: add add failure indicator
                }
            }
        }

        private Dictionary<string, List<string>> ValidateEntryFormErrors()
        {
            timeEntryValidator.ClearErrors();

            var errors = new Dictionary<string, List<string>>();

            if (newEntry.PositionId == 0)
            {
                errors.Add(nameof(newEntry.PositionId), new List<string>() { "A position must be selected." });
            }
            if (newEntry.MemberId == 0)
            {
                errors.Add(nameof(newEntry.MemberId), new List<string>() { "A member must be selected" });
            }

            return errors;
        }

        protected async Task GetCurrent()
        {
            var tsResult = await _tsService.GetCurrentTimeEntries();
            if (!tsResult.Successful)
            {
                pageErrors.Add(tsResult.Error);
            }
            timeEntries = tsResult.Data;
        }

        protected async Task GetArchived()
        {
            var tsResult = await _tsService.GetArchivedTimeEntries();
            if (!tsResult.Successful)
            {
                pageErrors.Add(tsResult.Error);
            }
            timeEntries = tsResult.Data;
        }

        protected void ModalCancel()
        {
            showAddEntryModal = false;
            showClockInModal = false;
        }
    }
}
