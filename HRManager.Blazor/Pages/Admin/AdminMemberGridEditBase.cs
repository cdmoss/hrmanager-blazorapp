using HRManager.Blazor.Pages.Shared;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class AdminMemberGridEditBase : MemberEditorBase
    {
        [Parameter]
        public AdminMemberDto SelectedMember { get; set; }
        [Parameter]
        public EventCallback<AdminMemberDto> SelectedMemberChanged { get; set; }
    }   
}
