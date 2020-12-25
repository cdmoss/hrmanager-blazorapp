using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common.Dtos;
using HRManager.Blazor.Services;
using Syncfusion.Blazor.Schedule;

namespace HRManager.Blazor.Pages.Admin
{
    public partial class Calendar
    {
        [Inject]
        private IShiftService _shiftService { get; set; }
        private List<ShiftReadEditDto> shifts;
        string error;

        protected override async Task OnInitializedAsync()
        {
            var result = await _shiftService.GetShifts();
            if (result.Successful)
            {
                shifts = result.Dto;
            }
            else
            {
                error = result.Error;
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
            else if (args.ActionType == ActionType.EventRemove)
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
