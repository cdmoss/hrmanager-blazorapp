using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class TSGridEditTemplateBase : ComponentBase
    {
        [Parameter]
        public EventCallback<TimeEntryReadEditDto> SelectedTimeEntryChanged { get; set; }
        [Parameter]
        public TimeEntryReadEditDto SelectedTimeEntry { get; set; }
        [Parameter]
        public List<Position> Positions { get; set; }
        [Parameter]
        public List<MemberMinimalDto> Members { get; set; }
        [Parameter]
        public DateTime EntryDate { get; set; }
        [Parameter]
        public DateTime StartTime { get; set; }
        [Parameter]
        public DateTime EndTime { get; set; }
        protected bool hideEndTime = false;

        protected override void OnInitialized()
        {
            hideEndTime = SelectedTimeEntry.EndTime == null;
        }

        public void ParseTimes()
        {
            SelectedTimeEntry.StartTime = EntryDate + StartTime.TimeOfDay;
            if (!hideEndTime)
            {
                SelectedTimeEntry.EndTime = EntryDate + EndTime.TimeOfDay;
            }

            SelectedTimeEntryChanged.InvokeAsync(SelectedTimeEntry);
        }
    }
}
