#pragma checksum "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Shared\PageMenus\TimesheetMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bed8c8bb651651dbbb9e190391daa0f1286e0c8"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages.Shared.PageMenus
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Common.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Blazor.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
    public partial class TimesheetMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "d-flex align-items-center");
            __builder.OpenElement(2, "button");
            __builder.AddAttribute(3, "class", "btn btn-primary");
            __builder.AddAttribute(4, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Shared\PageMenus\TimesheetMenu.razor"
                                              RaiseClockInClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "style", "margin-right:1px;");
            __builder.AddContent(6, "Clock in");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n    ");
            __builder.OpenElement(8, "button");
            __builder.AddAttribute(9, "class", "btn btn-primary");
            __builder.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 36 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Shared\PageMenus\TimesheetMenu.razor"
                                              RaiseAddEntryClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(11, "Add entry");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.AddMarkupContent(13, "<span>&nbsp;</span>\r\n    ");
            __builder.AddMarkupContent(14, "<span>&nbsp;</span>\r\n    ");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "class", "btn btn-primary");
            __builder.AddAttribute(17, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Shared\PageMenus\TimesheetMenu.razor"
                                              RaiseArchivedClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "style", "margin-right:1px;");
            __builder.AddContent(19, "Archived");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.OpenElement(21, "button");
            __builder.AddAttribute(22, "class", "btn btn-primary");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Shared\PageMenus\TimesheetMenu.razor"
                                              RaiseCurrentClicked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(24, "Current");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n\r\n    ");
            __builder.AddMarkupContent(26, "<form action=\"account/logout\" method=\"post\"><button type=\"submit\" class=\"btn btn-primary\">Logout</button></form>");
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Shared\PageMenus\TimesheetMenu.razor"
       
    [Parameter]
    public EventCallback AddEntryClicked { get; set; }
    [Parameter]
    public EventCallback ClockInClicked { get; set; }
    [Parameter]
    public EventCallback GetArchivedClicked { get; set; }
    [Parameter]
    public EventCallback GetCurrentClicked { get; set; }

    private async Task RaiseAddEntryClicked()
    {
        await AddEntryClicked.InvokeAsync();
    }

    private async Task RaiseClockInClicked()
    {
        await ClockInClicked.InvokeAsync();
    }

    private async Task RaiseArchivedClicked()
    {
        await GetArchivedClicked.InvokeAsync();
    }

    private async Task RaiseCurrentClicked()
    {
        await GetCurrentClicked.InvokeAsync();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
