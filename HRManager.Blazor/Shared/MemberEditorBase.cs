using HRManager.Blazor.Services;
using HRManager.Blazor.Shared;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Shared
{
    public class MemberEditorBase<TMemberDto> : ComponentBase where TMemberDto : MemberEditDto
    {
        [Inject]
        protected ITeamService _teamService { get; set; }
        [Parameter]
        public EventCallback<TMemberDto> MemberChanged { get; set; }
        protected PositionPickerBase<TMemberDto> positionPicker;
        [Parameter]
        public MemberEditDto Member { get; set; }
        protected List<string> errors = new List<string>();
        protected string selectedTab;

        protected void OnTabChanged(string name)
        {
            selectedTab = name;
        }
    }
}
