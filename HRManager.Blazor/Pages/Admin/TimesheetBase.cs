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
using Blazored.Modal;
using Blazored.Modal.Services;

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
        [Inject]
        public IModalService _modalService { get; set; }
        protected CustomValidator timeEntryValidator;
        protected List<TimeEntryReadEditDto> timeEntries;
        protected List<Position> positions;
        protected List<MemberMinimalDto> members;
        protected List<string> pageErrors = new List<string>();
        
        protected bool showClockInModal = false;
        protected bool showFullModal = false;
        protected bool current = true;

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
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.BeginEdit))
            {
                args.Cancel = true;
                var parameters = new ModalParameters();
                parameters.Add("TimeEntry", args.Data);
                parameters.Add("IsNewEntry", false);
                var modal = _modalService.Show(typeof(FullEntryModal), "Edit entry details", parameters);
                var modalResult = await modal.Result;
                var apiResult = modalResult.Cancelled ? null : modalResult.Data as ApiResult<List<TimeEntryReadEditDto>>;
                if (apiResult == null)
                {
                    modal.Close();
                    return;
                }
                if (apiResult.Successful)
                {
                    modal.Close();
                    //TODO: notify edit time entry success
                }
                else
                {
                    modal.Close();
                    pageErrors.Add(apiResult.Error);
                }
            }
        }

        protected async Task ShowAddEntryModal()
        {
            var parameters = new ModalParameters();
            parameters.Add("TimeEntry", new TimeEntryReadEditDto());
            parameters.Add("IsNewEntry", true);
            var modal = _modalService.Show(typeof(FullEntryModal), "Add new entry", parameters);
            var modalResult = await modal.Result;
            var apiResult = modalResult.Cancelled ? null : modalResult.Data as ApiResult<List<TimeEntryReadEditDto>>;
            if (apiResult == null)
            {
                modal.Close();
                return;
            }
            if (apiResult.Successful)
            {
                modal.Close();
                var result = await _tsService.GetArchivedTimeEntries();
                if (result.Successful)
                {
                    timeEntries = result.Data;
                }
                else
                {
                    pageErrors.Add(result.Error);
                }
                //TODO: notify edit time entry success
            }
            else
            {
                modal.Close();
                pageErrors.Add(apiResult.Error);
            }
        }

        protected async Task ShowClockInModal()
        {
            var parameters = new ModalParameters();
            parameters.Add("ClockInEntry", new TimeEntryCreateDto());
            var modal = _modalService.Show(typeof(ClockInModal), "New clock in", parameters);
            var modalResult = await modal.Result;
            var apiResult = modalResult.Cancelled ? null : modalResult.Data as ApiResult<List<TimeEntryReadEditDto>>;
            if (apiResult == null)
            {
                modal.Close();
                return;
            }
            if (apiResult.Successful)
            {
                modal.Close();
                var result = await _tsService.GetCurrentTimeEntries();
                if (result.Successful)
                {
                    timeEntries = result.Data;
                }
                else
                {
                    pageErrors.Add(result.Error);
                }
                //TODO: notify edit time entry success
            }
            else
            {
                modal.Close();
                pageErrors.Add(apiResult.Error);
            }
        }

        protected async Task GetCurrent()
        {
            current = true;

            var tsResult = await _tsService.GetCurrentTimeEntries();
            if (!tsResult.Successful)
            {
                pageErrors.Add(tsResult.Error);
            }
            timeEntries = tsResult.Data;
        }

        protected async Task GetArchived()
        {
            current = false;

            var tsResult = await _tsService.GetArchivedTimeEntries();
            if (!tsResult.Successful)
            {
                pageErrors.Add(tsResult.Error);
            }
            timeEntries = tsResult.Data;
        }

        protected void ModalCancel()
        {
            showFullModal = false;
            showClockInModal = false;
        }
    }
}
