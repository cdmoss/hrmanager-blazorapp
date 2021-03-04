using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Account.Registration
{
    public class AvailabilityBase : RegisterSectionBase
    {
        [Parameter]
        public EventCallback<Dictionary<DayOfWeek, List<AvailabilityDto>>> AvailabilitiesDataChanged { get; set; }
        [Parameter]
        public Dictionary<DayOfWeek, List<AvailabilityDto>> AvailabilitiesData { get; set; }


        protected override void OnInitialized()
        {
            if (!AvailabilitiesData.Any())
            {
                foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
                {
                    AvailabilitiesData.Add((DayOfWeek)day, new List<AvailabilityDto>());
                }
            }
        }

        protected override async Task GoToNextSection()
        {
            await AvailabilitiesDataChanged.InvokeAsync(AvailabilitiesData);
            await base.GoToNextSection();
        }

        protected override async Task HandlePreviousSectionRequested()
        {
            await AvailabilitiesDataChanged.InvokeAsync(AvailabilitiesData);
            await base.HandlePreviousSectionRequested();
        }

        protected override async Task HandleDifferentSectionRequested()
        {
            await AvailabilitiesDataChanged.InvokeAsync(AvailabilitiesData);
            await base.HandlePreviousSectionRequested();
        }
    }
}
