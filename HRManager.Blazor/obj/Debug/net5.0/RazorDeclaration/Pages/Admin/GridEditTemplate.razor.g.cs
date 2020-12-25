// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace HRManager.Blazor.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using HRManager.Common.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using HRManager.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using HRManager.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using HRManager.Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\GridEditTemplate.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\GridEditTemplate.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\GridEditTemplate.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
    public partial class GridEditTemplate : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\GridEditTemplate.razor"
       
    [Parameter]
    public MemberAdminReadEditDto Member { get; set; }
    [Parameter]
    public List<Position> Positions { get; set; }
    [Parameter]
    public EventCallback<MemberAdminReadEditDto> MemberChanged { get; set; }

    Dictionary<AssociationType, string[]> selectedPositions { get; set; }

    protected override void OnInitialized()
    {
        selectedPositions = new Dictionary<AssociationType, string[]>();

        var preferred = Member.Positions.Where(p => p.Association == AssociationType.Preferred).Select(p => p.Position.Name).ToArray();
        var assigned = Member.Positions.Where(p => p.Association == AssociationType.Assigned).Select(p => p.Position.Name).ToArray();
        var preferredAndAssigned = Member.Positions.Where(p => p.Association == AssociationType.PreferredAndAssigned).Select(p => p.Position.Name).ToArray();

        selectedPositions.Add(AssociationType.Assigned, assigned);
        selectedPositions.Add(AssociationType.Preferred, preferred);
        selectedPositions.Add(AssociationType.PreferredAndAssigned, preferredAndAssigned);
    }

    string selectedTab = "personal";

    public async Task UpdatePositions()
    {
        var memberPositions = new List<MemberPositionDto>();

        foreach (var position in selectedPositions[AssociationType.Preferred])
        {
            var memberPosition = new MemberPositionDto()
            {
                Position = Positions.FirstOrDefault(p => p.Name == position),
                Association = AssociationType.Preferred
            };

            memberPositions.Add(memberPosition);
        }

        foreach (var position in selectedPositions[AssociationType.Assigned])
        {
            var memberPosition = new MemberPositionDto()
            {
                Position = Positions.FirstOrDefault(p => p.Name == position),
                Association = AssociationType.Assigned
            };

            memberPositions.Add(memberPosition);
        }

        foreach (var position in selectedPositions[AssociationType.PreferredAndAssigned])
        {
            if (selectedPositions[AssociationType.Assigned].Contains(position))
            {
                var memberPosition = new MemberPositionDto()
                {
                    Position = Positions.FirstOrDefault(p => p.Name == position),
                    Association = AssociationType.PreferredAndAssigned
                };

                memberPositions.Add(memberPosition);
            }
        }

        Member.Positions = memberPositions;

        await MemberChanged.InvokeAsync(Member);
    }

    private void OnTabChanged(string name)
    {
        selectedTab = name;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
