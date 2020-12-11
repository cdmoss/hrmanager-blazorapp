// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace HRManager.Blazor.Pages.Auth.Registration
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
#line 15 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AvailabilityDay.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AvailabilityDay.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
    public partial class AvailabilityDay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AvailabilityDay.razor"
       
    [Parameter]
    public List<AvailabilityDto> Availabilities { get; set; }
    [Parameter]
    public EventCallback<List<AvailabilityDto>> AvailabilitiesChanged { get; set; }

    private void AddTime()
    {
        Availabilities.Add(new AvailabilityDto());
        StateHasChanged();
    }

    private void RemoveTime(AvailabilityDto availability)
    {
        Availabilities.Remove(availability);
        StateHasChanged();
    }

    private async Task HandleAvailabilitiesChanged()
    {
        await AvailabilitiesChanged.InvokeAsync(Availabilities);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
