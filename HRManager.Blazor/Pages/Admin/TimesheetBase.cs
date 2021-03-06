﻿using HRManager.Common.Dtos;
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
    //TODO: add delete function
    public class TimesheetBase : ComponentBase
    {
        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        public ITimesheetService _tsService { get; set; }
        [Inject]
        public IPositionService _posService { get; set; }
        [Inject]
        public ITeamService _memberService { get; set; }
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

            bool getEntriesSuccessful = await GetEntriesAsync(true);
            if (!getEntriesSuccessful)
            {
                return;
            }

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

        protected async Task<bool> GetEntriesAsync(bool isCurrent)
        {
            if (isCurrent)
            {
                var tsResult = await _tsService.GetCurrentTimeEntries();
                if (!tsResult.Successful)
                {
                    pageErrors.Add(tsResult.Error);
                    return false;
                }
                timeEntries = tsResult.Data.OrderBy(s => s.StartTime).ToList();
                return true;
            }
            else
            {
                var tsResult = await _tsService.GetArchivedTimeEntries();
                if (!tsResult.Successful)
                {
                    pageErrors.Add(tsResult.Error);
                    return false;
                }
                timeEntries = tsResult.Data.OrderBy(s => s.EndTime.Value).ToList();
                return true;
            }
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
                await GetEntriesAsync(false);
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
                await GetEntriesAsync(true);
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

            await GetEntriesAsync(true);
        }

        protected async Task GetArchived()
        {
            current = false;

            await GetEntriesAsync(false);
        }

        protected void ModalCancel()
        {
            showFullModal = false;
            showClockInModal = false;
        }
    }
}
