#pragma checksum "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7afa4ab9854b7ee9a0d0b53f8478c211915531db"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages.Admin
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
#line 2 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/alerts")]
    public partial class Alerts : AlertsBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
#nullable restore
#line 12 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
         if (errors.Any())
        {
            foreach (string error in errors)
            {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(2, "p");
                __builder2.AddContent(3, 
#nullable restore
#line 16 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                    error

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 17 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<Syncfusion.Blazor.Grids.SfGrid<AdminAlertListDto>>(4);
                __builder2.AddAttribute(5, "DataSource", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<AdminAlertListDto>>(
#nullable restore
#line 22 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                alerts

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(6, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 23 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(7, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 24 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(8, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 25 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "AllowExcelExport", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 26 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                      true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "AllowMultiSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 27 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                       true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(11, "AllowSelection", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(12, "AllowPdfExport", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 29 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridFilterSettings>(14);
                    __builder3.AddAttribute(15, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.FilterType>(
#nullable restore
#line 30 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                          Syncfusion.Blazor.Grids.FilterType.Menu

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(16, "\r\n\r\n                ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumns>(17);
                    __builder3.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(19);
                        __builder4.AddAttribute(20, "Field", "Member.FullName");
                        __builder4.AddAttribute(21, "HeaderText", "Member");
                        __builder4.AddAttribute(22, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 41 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                                                                       TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(23, "\r\n                    ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(24);
                        __builder4.AddAttribute(25, "Field", "Date");
                        __builder4.AddAttribute(26, "HeaderText", "Alert Date");
                        __builder4.AddAttribute(27, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 42 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                                                                TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(28, "\r\n                    ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(29);
                        __builder4.AddAttribute(30, "Field", "AlertType");
                        __builder4.AddAttribute(31, "HeaderText", "Alert Type");
                        __builder4.AddAttribute(32, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 43 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                                                                     TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(33, "\r\n                    ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(34);
                        __builder4.AddAttribute(35, "Field", "AddressedBy");
                        __builder4.AddAttribute(36, "HeaderText", "Addressed By");
                        __builder4.AddAttribute(37, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 44 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
                                                                                         TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 48 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Alerts.razor"
        }

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.AddAttribute(38, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
