using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Account.Registration
{
    public class RegisterSectionBase : ComponentBase
    {
        [Parameter]
        public EventCallback<MemberSectionData> SectionCompleted { get; set; }
        [Parameter]
        public EventCallback<MemberSectionData> PreviousSectionRequested { get; set; }
        [Parameter]
        public EventCallback<MemberSectionData> DifferentSectionRequested { get; set; }
        [Parameter]
        public Register.RegistrationType Type { get; set; }

        protected virtual async Task GoToNextSection()
        {
            await SectionCompleted.InvokeAsync();
        }

        protected virtual async Task HandlePreviousSectionRequested()
        {
            await PreviousSectionRequested.InvokeAsync();
        }

        protected virtual async Task HandleDifferentSectionRequested()
        {
            await DifferentSectionRequested.InvokeAsync();
        }
    }
}
