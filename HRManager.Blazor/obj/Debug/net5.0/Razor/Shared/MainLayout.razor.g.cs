#pragma checksum "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "163a63a3eacfcf26bd583e2bfa4c4146cb629ad8"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Common.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using HRManager.Blazor.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<HRManager.Blazor.Pages.Shared.AuthChecker>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\r\n\r\n");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "page");
            __builder.AddAttribute(4, "b-ljcv0tknf5");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "sidebar");
            __builder.AddAttribute(7, "b-ljcv0tknf5");
#nullable restore
#line 45 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
         if (navMenuType == "admin")
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Shared.AdminNavMenu>(8);
            __builder.AddAttribute(9, "PageChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, 
#nullable restore
#line 47 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
                                       OnPageChanged

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
#nullable restore
#line 48 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
        }
        else if (navMenuType == "member")
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Shared.MemberNavMenu>(10);
            __builder.CloseComponent();
#nullable restore
#line 52 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "main");
            __builder.AddAttribute(14, "b-ljcv0tknf5");
            __builder.OpenElement(15, "form");
            __builder.AddAttribute(16, "action", "/account/logout");
            __builder.AddAttribute(17, "method", "post");
            __builder.AddAttribute(18, "class", "top-row px-4");
            __builder.AddAttribute(19, "b-ljcv0tknf5");
            __builder.OpenElement(20, "span");
            __builder.AddAttribute(21, "class", "font-weight-bold my-auto");
            __builder.AddAttribute(22, "b-ljcv0tknf5");
            __builder.AddContent(23, 
#nullable restore
#line 56 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
                                                    currentPage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n            ");
            __builder.AddMarkupContent(25, "<a href=\"/account/logout\" class=\"ml-md-auto\" b-ljcv0tknf5>Logout</a>\r\n            ");
            __builder.OpenElement(26, "input");
            __builder.AddAttribute(27, "type", "hidden");
            __builder.AddAttribute(28, "name", "_RequestVerificationToken");
            __builder.AddAttribute(29, "value", 
#nullable restore
#line 59 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
                                                                          _tokenProvider.XsrfToken

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(30, "b-ljcv0tknf5");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n\r\n        ");
            __builder.AddContent(32, 
#nullable restore
#line 62 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 7 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Shared\MainLayout.razor"
       
    [CascadingParameter]
    private Task<AuthenticationState> authState { get; set; }
    private string currentPage = "Members";
    private string navMenuType;

    protected override async Task OnInitializedAsync()
    {

        var user = (await authState).User;

        // if user isn't authenticated, redirect them to login
        if (!user.Identity.IsAuthenticated)
        {
            _nav.NavigateTo($"/account/login?redirectUri={_nav.Uri}", true);
        }

        // if they are, determine what role they're in and redirect them accordingly
        if (user.IsInRole("Admin") || user.IsInRole("SuperAdmin"))
        {
            navMenuType = "admin";
        }
        else if (user.IsInRole("Member"))
        {
            navMenuType = "member";
        }
    }

    private void OnPageChanged(string pageName)
    {
        currentPage = pageName;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HRManager.Blazor.Services.TokenProvider _tokenProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _nav { get; set; }
    }
}
#pragma warning restore 1591
