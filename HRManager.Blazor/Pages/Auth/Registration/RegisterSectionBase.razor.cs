using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Auth.Registration
{
    public class RegisterSectionBase : ComponentBase
    {
        public RegisterSectionData data { get; set; }
        [Parameter]
        public EventCallback<RegisterSectionData> SectionCompleted { get; set; }
        [Parameter]
        public EventCallback PreviousSectionRequested { get; set; }
        [Parameter]
        public EventCallback DifferentSectionRequested { get; set; }

        protected virtual async Task GoToNextSection()
        {
            await SectionCompleted.InvokeAsync(data);
        }

        protected async Task HandlePreviousSectionRequested()
        {
            await PreviousSectionRequested.InvokeAsync();
        }

        protected async Task HandleDifferentSectionRequested()
        {
            await DifferentSectionRequested.InvokeAsync();
        }
    }
}
