#pragma checksum "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\RegisterSectionButtonContainer.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc312071e9e0ab62655d0a311b66385f09e97666"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages.Account.Registration
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
#nullable restore
#line 1 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\RegisterSectionButtonContainer.razor"
using Syncfusion.Blazor.ProgressBar;

#line default
#line hidden
#nullable disable
    public partial class RegisterSectionButtonContainer : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<br b-pf1xp863fm>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "btn-container");
            __builder.AddAttribute(3, "b-pf1xp863fm");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "id", "back-btn");
            __builder.AddAttribute(6, "type", "button");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\RegisterSectionButtonContainer.razor"
                                                  GoToPreviousSection

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "class", "btn btn-dark");
            __builder.AddAttribute(9, "b-pf1xp863fm");
            __builder.AddContent(10, "Previous");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.OpenElement(12, "button");
            __builder.AddAttribute(13, "id", "next-btn");
            __builder.AddAttribute(14, "type", "submit");
            __builder.AddAttribute(15, "form", 
#nullable restore
#line 19 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\RegisterSectionButtonContainer.razor"
                                               Progress

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(16, "class", "btn btn-primary");
            __builder.AddAttribute(17, "b-pf1xp863fm");
            __builder.AddContent(18, "Next");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\RegisterSectionButtonContainer.razor"
       
    [Parameter]
    public EventCallback<string> PreviousSectionRequested { get; set; }
    [Parameter]
    public int Progress { get; set; }

    private async Task GoToPreviousSection()
    {
        await PreviousSectionRequested.InvokeAsync();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
