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
        public TimeEntryReadEditDto SelectedTimeEntry { get; set; }
    }
}
