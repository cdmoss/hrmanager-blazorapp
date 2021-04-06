using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Shared
{
    public class MemberEditBase : ComponentBase
    {
        [Parameter]
        public List<Position> Positions { get; set; }

        protected List<string> preferredPositions;

        protected string selectedTab;

        public virtual async Task UpdatePositions() {}

        protected void OnTabChanged(string name)
        {
            selectedTab = name;
        }
    }
}
