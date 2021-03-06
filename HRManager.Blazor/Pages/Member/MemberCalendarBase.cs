﻿using HRManager.Blazor.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Member
{
    public class MemberCalendarBase : ComponentBase
    {
        protected List<string> errors = new List<string>();

        protected enum SaveAction { NewShift, ExistingShift }

        [Inject]
        public IShiftService ShiftService { get; set; }
        [Inject]
        protected IPositionService _positionService { get; set; }
        [Inject]
        protected ITeamService _minimalService { get; set; }
        [Inject]
        protected IJSRuntime _js { get; set; }
        protected List<ShiftReadEditDto> shifts;
        protected ShiftReadEditDto focusedShift = new ShiftReadEditDto();
        protected SfSchedule<ShiftReadEditDto> schedule;
        protected List<Position> positions;
        protected List<MemberMinimalDto> members;
        protected string[] resourceNames = new[] { "Positions" };
        protected string error;
        protected View currentView = View.TimelineWeek;
        protected bool showEditor = false;
        protected SaveAction saveAction;

        // used to prevent the form from submitting when a recurring day is clicked
        protected bool formComplete = false;

        protected override void OnInitialized()
        {
            try
            {
                var shiftResult = ShiftService.GetShifts();
                if (shiftResult.Successful)
                {
                    shifts = shiftResult.Data;
                    shifts.RemoveAll(s => s == null);

                    var positionResult = _positionService.GetPositions();
                    if (positionResult.Successful)
                    {
                        positions = positionResult.Data;

                        var membersResult = _minimalService.GetMinimalMembers();
                        if (membersResult.Successful)
                        {
                            members = membersResult.Data;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        protected void SignalCompletedForm()
        {
            formComplete = true;
        }

        protected void OnPopupOpen(PopupOpenEventArgs<ShiftReadEditDto> args)
        {
            if (args.Type == PopupType.QuickInfo)
            {
                args.Cancel = true;
            }
        }
    }
}
