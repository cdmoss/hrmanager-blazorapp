using HRManager.Blazor.Pages.Account.Registration;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace HRManager.Blazor.Pages.Account
{
    public class CertificatesBase : RegisterSectionBase
    {
        [Parameter]
        public CertificatesData CertData { get; set; }
        [Parameter]
        public EventCallback<CertificatesData> CertDataChanged { get; set; }

        protected override async Task GoToNextSection()
        {
            await CertDataChanged.InvokeAsync(CertData);
            await base.GoToNextSection();
        }

        protected override async Task HandlePreviousSectionRequested()
        {
            await CertDataChanged.InvokeAsync(CertData);
            await base.HandlePreviousSectionRequested();
        }

        protected override async Task HandleDifferentSectionRequested()
        {
            await CertDataChanged.InvokeAsync(CertData);
            await base.HandlePreviousSectionRequested();
        }
    }
}
