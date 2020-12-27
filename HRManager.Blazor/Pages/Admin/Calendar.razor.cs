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
        [Inject]
        private IShiftService _shiftService { get; set; }
        [Inject]
        private IPositionService _positionService { get; set; }
        [Inject]
        private IUserService _userService { get; set; }
        private List<ShiftReadEditDto> shifts;
        private List<Position> positions;
        private List<MemberMinimalDto> members;
        private string[] resourceNames = new string[] { "Positions" };
        private string error;
        private View currentView = View.TimelineWeek;

        protected override async Task OnInitializedAsync()
        {
            var shiftResult = await _shiftService.GetShifts();
            if (shiftResult.Successful)
            {
                shifts = shiftResult.Dto;

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

        private async Task OnActionCompleted(ActionEventArgs<ShiftReadEditDto> args)
        {
            if (args.ActionType == ActionType.EventCreate)
            {
                var result = await _shiftService.AddShifts(args.AddedRecords);
                if (result.Successful)
                {
                    shifts = result.Dto;
                }
                else
                {
                    error = result.Error;
                }
            }
            else if (args.ActionType == ActionType.EventChange)
            {
                var result = await _shiftService.UpdateShifts(args.ChangedRecords);
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
    }
}
