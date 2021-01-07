using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common.Dtos;
using HRManager.Blazor.Services;
using Syncfusion.Blazor.Schedule;
using HRManager.Common;
using System.ComponentModel;
using System.Collections.ObjectModel;
using HRManager.Blazor.Adaptors;
using Microsoft.JSInterop;

namespace HRManager.Blazor.Pages.Admin
{
    public partial class Calendar : ComponentBase
    {
        enum SaveAction { NewShift, ExistingShift }

        [Inject]
        public IShiftService ShiftService { get; set; }
        [Inject]
        private IPositionService _positionService { get; set; }
        [Inject]
        private IMemberService _minimalService { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        private List<ShiftReadEditDto> shifts;
        private ShiftReadEditDto focusedShift = new ShiftReadEditDto();
        private SfSchedule<ShiftReadEditDto> schedule;
        private List<Position> positions;
        private List<MemberMinimalDto> members;
        private string[] resourceNames = new[] { "Positions" };
        private string error;
        private View currentView = View.TimelineWeek;
        private bool showEditor = false;
        private SaveAction saveAction;

        // used to prevent the form from submitting when a recurring day is clicked
        private bool formComplete = false;

        protected override void OnInitialized()
        {
            try
            {
                var shiftResult = ShiftService.GetShifts();
                if (shiftResult.Successful)
                {
                    shifts = shiftResult.Dto;
                    shifts.RemoveAll(s => s == null);

                    var positionResult = _positionService.GetPositions();
                    if (positionResult.Successful)
                    {
                        positions = positionResult.Dto;

                        var membersResult = _minimalService.GetMinimalMembers();
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private void SignalCompletedForm()
        {
            formComplete = true;
        }

        private void OnPopupOpen(PopupOpenEventArgs<ShiftReadEditDto> args)
        {
            if (args.Type == PopupType.QuickInfo)
            {
                args.Cancel = true;
            }
            //if (args.Type == PopupType.Editor)
            //{
            //    args.Cancel = true;

            //    saveAction = args.Data.Id == 0 ? SaveAction.NewShift : SaveAction.ExistingShift;

            //    focusedShift.Id = args.Data.Id;
            //    focusedShift.StartTime = args.Data.StartTime;
            //    focusedShift.EndTime = args.Data.EndTime;
            //    focusedShift.Description = args.Data.Description;
            //    focusedShift.PositionId = args.Data.PositionId;
            //    focusedShift.MemberProfileId = args.Data.MemberProfileId;
            //    focusedShift.IsAllDay = args.Data.IsAllDay;
            //    focusedShift.IsBlock = args.Data.IsBlock;
            //    focusedShift.IsRecurrence = args.Data.IsRecurrence;
            //    focusedShift.RecurrenceException = args.Data.RecurrenceException;
            //    focusedShift.RecurrenceRule = args.Data.RecurrenceRule;
            //    focusedShift.RecurrenceID = args.Data.RecurrenceID;
            //    focusedShift.IsRecurrence = args.Data.IsRecurrence;

            //    focusedShift.Description = args.Data.Description == null ? "" : args.Data.Description;
            //    focusedShift.Subject = args.Data.Subject == null ? "Add title" : args.Data.Subject;
            //    showEditor = true;
            //}
        }
    }
}
