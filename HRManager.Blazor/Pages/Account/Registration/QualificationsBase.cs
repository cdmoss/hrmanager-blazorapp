using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Account.Registration
{
    public class QualificationsBase : RegisterSectionBase
    {
        [Parameter]
        public EventCallback<QualificationsData> QualificationsDataChanged { get; set; }
        [Parameter]
        public QualificationsData QualificationsData { get; set; }

        protected override async Task GoToNextSection()
        {
            await QualificationsDataChanged.InvokeAsync(QualificationsData);
            await base.GoToNextSection();
        }

        protected override async Task HandlePreviousSectionRequested()
        {
            await QualificationsDataChanged.InvokeAsync(QualificationsData);
            await base.HandlePreviousSectionRequested();
        }

        protected override async Task HandleDifferentSectionRequested()
        {
            await QualificationsDataChanged.InvokeAsync(QualificationsData);
            await base.HandlePreviousSectionRequested();
        }

        protected void HandleCurrentJobCheckChanged()
        {
            StateHasChanged();
        }
    }
}
