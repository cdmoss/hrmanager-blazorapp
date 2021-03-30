#pragma checksum "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\PostLoginRedirector.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab6cf7e5216cb68340417b7c413c2e22f0ddbc0b"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages.Account
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
#line 3 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\PostLoginRedirector.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\PostLoginRedirector.razor"
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\PostLoginRedirector.razor"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(AuthLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/account/post-login")]
    public partial class PostLoginRedirector : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\PostLoginRedirector.razor"
       
    [CascadingParameter]
    private Task<AuthenticationState> authState { get; set; }
    private string message;
    protected override async Task OnInitializedAsync()
    {
        var user = (await authState).User;

        if (!user.Identity.IsAuthenticated)
        {
            _nav.NavigateTo($"/account/login?redirectUri={_nav.Uri}", true);
        }
        else
        {
            // get destination query paramater
            var uri = _nav.ToAbsoluteUri(_nav.Uri);
            var query = QueryHelpers.ParseQuery(uri.Query);
            StringValues destinationQuery = "";
            query.TryGetValue("destination", out destinationQuery);
            string destination = destinationQuery.ToString();

            // get user role
            string userRole = user.Claims.FirstOrDefault(c => c.Type == "role").Value.ToLower();
            userRole = userRole == "superadmin" ? "admin" : userRole;

            // navigate to destination if user has an appropriate role
            if (destination.Contains(userRole))
            {
                _nav.NavigateTo(destination);
            }
            else
            {
                if (userRole == "admin")
                {
                    _nav.NavigateTo("/admin/members");
                }
                else if (userRole == "member")
                {
                    _nav.NavigateTo("/member/information");
                }
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _nav { get; set; }
    }
}
#pragma warning restore 1591
