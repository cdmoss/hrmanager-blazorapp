using HRManager.Blazor.Services;
using HRManager.Blazor.Shared;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public partial class MemberEditor<TMemberDto> : ComponentBase where TMemberDto : MemberEditDto
    {
        [Inject]
        protected ITeamService _teamService { get; set; }
        [Parameter]
        public bool isMember { get; set; }
        [Parameter]
        public EventCallback<TMemberDto> MemberChanged { get; set; }
        [Parameter]
        public RenderFragment<PositionPickerBase<TMemberDto>> PositionPicker { get; set; }
        [Parameter]
        public TMemberDto Member { get; set; }
        protected List<string> errors = new List<string>();
        protected string selectedTab;

        protected void OnTabChanged(string name)
        {
            selectedTab = name;
        }
    }
}
