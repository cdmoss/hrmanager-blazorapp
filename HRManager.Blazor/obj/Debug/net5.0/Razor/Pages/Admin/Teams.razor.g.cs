#pragma checksum "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "489850b250f6b6d57ae8bd236364b61ad5521609"
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
#line 2 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using HRManager.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
using HRManager.Blazor.Pages.Shared.PageMenus;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/members")]
    public partial class Teams : TeamsBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "div");
                __builder2.AddAttribute(3, "class", "menu");
                __builder2.AddAttribute(4, "b-k4virxzmzo");
                __builder2.OpenComponent<HRManager.Blazor.Pages.Shared.PageMenus.TeamsMenu>(5);
                __builder2.AddAttribute(6, "GetStaffClicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 18 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                 OnlyStaff

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(7, "GetMembersClicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 19 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                   OnlyMembers

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(8, "AddMemberClicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 20 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                  AddMember

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(9, "AddStaffClicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 21 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                 AddStaff

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.CloseElement();
#nullable restore
#line 23 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
         if (errors.Any())
        {
            foreach (string error in errors)
            {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(10, "p");
                __builder2.AddAttribute(11, "b-k4virxzmzo");
                __builder2.AddContent(12, 
#nullable restore
#line 27 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                    error

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 28 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<Syncfusion.Blazor.Grids.SfGrid<AdminMemberDto>>(13);
                __builder2.AddAttribute(14, "DataSource", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<AdminMemberDto>>(
#nullable restore
#line 33 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                filteredTeam

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 34 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 35 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(17, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 36 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "AllowExcelExport", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 37 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                      true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "AllowMultiSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 38 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                       true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "AllowSelection", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 39 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "AllowPdfExport", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 40 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridFilterSettings>(23);
                    __builder3.AddAttribute(24, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.FilterType>(
#nullable restore
#line 42 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                          Syncfusion.Blazor.Grids.FilterType.Menu

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(25, "\r\n                ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridEditSettings>(26);
                    __builder3.AddAttribute(27, "AllowEditing", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 43 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(28, "AllowAdding", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 43 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                   true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "Mode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.EditMode>(
#nullable restore
#line 43 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                               EditMode.Dialog

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(30, "Template", (Microsoft.AspNetCore.Components.RenderFragment<System.Object>)((editContext) => (__builder4) => {
#nullable restore
#line 45 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                          
                            var member = (editContext as AdminMemberDto);
                        

#line default
#line hidden
#nullable disable
                        __builder4.OpenComponent<HRManager.Blazor.Pages.Admin.MemberGridEditTemplate>(31);
                        __builder4.AddAttribute(32, "Positions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<HRManager.Common.Position>>(
#nullable restore
#line 48 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                                                             positions

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(33, "SelectedMember", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<HRManager.Common.Dtos.AdminMemberDto>(
#nullable restore
#line 48 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                                          member

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(34, "SelectedMemberChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.AdminMemberDto>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.AdminMemberDto>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => member = __value, member))));
                        __builder4.AddComponentReferenceCapture(35, (__value) => {
#nullable restore
#line 48 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                      editTemplate = (HRManager.Blazor.Pages.Admin.MemberGridEditTemplate)__value;

#line default
#line hidden
#nullable disable
                        }
                        );
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(36, "\r\n                ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridTemplates>(37);
                    __builder3.AddAttribute(38, "DetailTemplate", (Microsoft.AspNetCore.Components.RenderFragment<System.Object>)((detailContext) => (__builder4) => {
#nullable restore
#line 53 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                          
                            var member = (detailContext as AdminMemberDto);
                            var tabNames = new string[]
                            {
                            "personal," + member.Id,
                            "avail," + member.Id,
                            "positions," + member.Id,
                            "qual," + member.Id,
                            "cert," + member.Id,
                            "check," + member.Id,
                            };
                        

#line default
#line hidden
#nullable disable
                        __builder4.OpenComponent<HRManager.Blazor.Pages.Admin.MemberGridReadTemplate>(39);
                        __builder4.AddAttribute(40, "SelectedMember", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<HRManager.Common.Dtos.AdminMemberDto>(
#nullable restore
#line 65 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                member

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(41, "\r\n                ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumns>(42);
                    __builder3.AddAttribute(43, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(44);
                        __builder4.AddAttribute(45, "Field", "FirstName");
                        __builder4.AddAttribute(46, "HeaderText", "First Name");
                        __builder4.AddAttribute(47, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 69 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                                     TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(48, "\r\n                    ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(49);
                        __builder4.AddAttribute(50, "Field", "LastName");
                        __builder4.AddAttribute(51, "HeaderText", "Last Name");
                        __builder4.AddAttribute(52, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 70 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                                   TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(53, "\r\n                    ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(54);
                        __builder4.AddAttribute(55, "Field", "Email");
                        __builder4.AddAttribute(56, "HeaderText", "Email");
                        __builder4.AddAttribute(57, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 71 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                            TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(58, "\r\n                    ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(59);
                        __builder4.AddAttribute(60, "Field", "MainPhone");
                        __builder4.AddAttribute(61, "HeaderText", "Phone");
                        __builder4.AddAttribute(62, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 72 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                                TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(63, "\r\n                    ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(64);
                        __builder4.AddAttribute(65, "Field", "ApprovalStatus");
                        __builder4.AddAttribute(66, "HeaderText", "Status");
                        __builder4.AddAttribute(67, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 73 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                                      TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(68, "\r\n                ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridEvents<AdminMemberDto>>(69);
                    __builder3.AddAttribute(70, "OnActionBegin", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Grids.ActionEventArgs<AdminMemberDto>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Grids.ActionEventArgs<AdminMemberDto>>(this, 
#nullable restore
#line 75 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                                                                   BeginActionHandler

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(71, (__value) => {
#nullable restore
#line 41 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
                          grid = (Syncfusion.Blazor.Grids.SfGrid<AdminMemberDto>)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
#nullable restore
#line 77 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Admin\Teams.razor"
        }

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.AddAttribute(72, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
