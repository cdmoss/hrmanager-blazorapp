using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Account.Registration
{
    public class AccountCredsBase : RegisterSectionBase
    {
        // TODO: validate email input
        [Parameter]
        public EventCallback<AccountCredsData> AccountDataChanged { get; set; }
        [Parameter]
        public AccountCredsData AccountData { get; set; }

        protected override async Task GoToNextSection()
        {
            await AccountDataChanged.InvokeAsync(AccountData);
            await base.GoToNextSection();
        }

        protected override async Task HandlePreviousSectionRequested()
        {
            await AccountDataChanged.InvokeAsync(AccountData);
            await base.HandlePreviousSectionRequested();
        }

        protected override async Task HandleDifferentSectionRequested()
        {
            await AccountDataChanged.InvokeAsync(AccountData);
            await base.HandlePreviousSectionRequested();
        }
    }
}
