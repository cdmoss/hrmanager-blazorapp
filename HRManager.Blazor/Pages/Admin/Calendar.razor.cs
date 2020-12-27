using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common.Dtos;
using HRManager.Blazor.Services;
using Syncfusion.Blazor.Schedule;
using HRManager.Common;

namespace HRManager.Blazor.Pages.Admin
{
    public partial class Calendar
    {
        enum SaveAction { NewShift, ExistingShift }

        [Inject]
        private IShiftService _shiftService { get; set; }
        [Inject]
        private IPositionService _positionService { get; set; }
        [Inject]
        private IUserService _userService { get; set; }
        private SfSchedule<ShiftReadEditDto> schedule;
        private List<ShiftReadEditDto> shifts;
        private ShiftReadEditDto focusedShift = new ShiftReadEditDto();
        private List<Position> positions;
        private List<MemberMinimalDto> members;
        private string[] resourceNames = new string[] { "Positions" };
        private string error;
        private View currentView = View.TimelineWeek;
        private bool showEditor = false;
        private SaveAction saveAction;

        protected override async Task OnInitializedAsync()
        {
            var shiftResult = await _shiftService.GetShifts();
            if (shiftResult.Successful)
            {
                shifts = shiftResult.Dto;
                shifts.RemoveAll(s => s == null);

                var positionResult = await _positionService.GetPositions();
                if (positionResult.Successful)
                {
                    positions = positionResult.Dto;

                    var membersResult = await _userService.GetMembers<MemberMinimalDto>();
                    if (membersResult.Successful)
                    {
                        members = membersResult.Dto;
                    }
                    else
                    {
                        error = positionResult.Error;
                    }
                }
                else
                {
                    error = positionResult.Error;
                }
            }
            else
            {
                error = shiftResult.Error;
            }
        }
        
        private async Task SaveShift()
        {
            showEditor = false;
            schedule.ShowSpinner();
            if (saveAction == SaveAction.NewShift)
            {
                var result = await _shiftService.AddShifts(new List<ShiftReadEditDto>() { focusedShift });
                if (result.Successful)
                {
                    shifts = result.Dto;
                }
                else
                {
                    error = result.Error;
                }
            }
            else
            {
                var result = await _shiftService.UpdateShifts(new List<ShiftReadEditDto>() { focusedShift });
                if (result.Successful)
                {
                    shifts = result.Dto;
                }
                else
                {
                    error = result.Error;
                }
            }
            schedule.HideSpinner();
        }

        private async Task OnActionBegin(ActionEventArgs<ShiftReadEditDto> args)
        {
            if (args.ActionType == ActionType.EventRemove)
            {
                var ids = args.DeletedRecords.Select(p => p.Id).ToList();

                var result = await _shiftService.DeleteShifts(ids);
                if (result.Successful)
                {
                    shifts = result.Dto;
                }
                else
                {
                    error = result.Error;
                }
            }
        }

        private void OnPopupOpen(PopupOpenEventArgs<ShiftReadEditDto> args)
        {
            schedule.ShowSpinner();
            if (args.Type == PopupType.QuickInfo)
            {
                args.Cancel = true;

                saveAction = args.Data.Id == 0 ? SaveAction.NewShift : SaveAction.ExistingShift;

                focusedShift.Id = args.Data.Id;
                focusedShift.StartTime = args.Data.StartTime;
                focusedShift.EndTime = args.Data.EndTime;
                focusedShift.Description = args.Data.Description;
                focusedShift.PositionId = args.Data.PositionId;
                focusedShift.MemberProfileId = args.Data.MemberProfileId;
                focusedShift.IsAllDay = args.Data.IsAllDay;
                focusedShift.IsBlock = args.Data.IsBlock;
                focusedShift.IsRecurrence = args.Data.IsRecurrence;
                focusedShift.RecurrenceException = args.Data.RecurrenceException;
                focusedShift.RecurrenceID = args.Data.RecurrenceID;
                focusedShift.RecurrenceRule = args.Data.RecurrenceRule;

                focusedShift.Description = args.Data.Description == null ? "" : args.Data.Description;
                focusedShift.Subject = args.Data.Subject == null ? "Add title" : args.Data.Subject;
                showEditor = true;
            }
            if (args.Type == PopupType.Editor)
            {
                args.Cancel = true;
            }
            schedule.HideSpinner();
        }
    }
}
