#pragma checksum "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1e5402ccbc9d15cc93992f558fadf86c7c961d2"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages
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
using HRManager.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using HRManager.Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
using HRManager.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/team")]
    public partial class Team : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Team</h3>\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(1);
            __builder.AddAttribute(2, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
#nullable restore
#line 9 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
         if (users == null)
        {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(3, "<p><em>Loading...</em></p>");
#nullable restore
#line 12 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(4, "table");
                __builder2.AddAttribute(5, "class", "table");
                __builder2.AddMarkupContent(6, "<thead><tr><th>Date</th>\r\n                        <th>Temp. (C)</th>\r\n                        <th>Temp. (F)</th>\r\n                        <th>Summary</th></tr></thead>\r\n                ");
                __builder2.OpenElement(7, "tbody");
#nullable restore
#line 25 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
                     foreach (var user in users)
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(8, "tr");
                __builder2.OpenElement(9, "td");
                __builder2.AddContent(10, 
#nullable restore
#line 28 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
                                 user.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 30 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
                    }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 33 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
        }

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.AddAttribute(11, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(12, "\r\n        Sorry, you are not authorized to see this content... scrub.\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Team.razor"
       
    private UserProfile[] users;
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await authenticationStateTask;
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            users = await _http.GetFromJsonAsync<UserProfile[]>("test/users");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
