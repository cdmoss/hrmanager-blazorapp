#pragma checksum "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36383114f340db7c709ebf837ec19e223c063d54"
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
#line 2 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using HRManager.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
           [Authorize(Roles = "SuperAdmin, Admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/members")]
    public partial class Members : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Grids.SfGrid<MemberAdminReadEditDto>>(2);
                __builder2.AddAttribute(3, "DataSource", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<MemberAdminReadEditDto>>(
#nullable restore
#line 15 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                            members

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(4, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 16 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(5, "AllowGrouping", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 17 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                               true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(6, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 18 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                             true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(7, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                              true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(8, "AllowExcelExport", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 20 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "AllowMultiSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 21 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                   true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "AllowSelection", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(11, "AllowPdfExport", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 23 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridTemplates>(13);
                    __builder3.AddAttribute(14, "DetailTemplate", (Microsoft.AspNetCore.Components.RenderFragment<System.Object>)((detailContext) => (__builder4) => {
#nullable restore
#line 26 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                      
                        var member = (detailContext as MemberAdminReadEditDto);
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
                        __builder4.OpenComponent<Blazorise.Tabs>(15);
                        __builder4.AddAttribute(16, "SelectedTab", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 38 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                        selectedTabs[member.Id]

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(17, "SelectedTabChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, 
#nullable restore
#line 38 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                                                                      OnTabChanged

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddAttribute(18, "Items", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<Blazorise.Tab>(19);
                            __builder5.AddAttribute(20, "Name", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                        tabNames[0]

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(22, "Personal and Contact");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(23, "\r\n                            ");
                            __builder5.OpenComponent<Blazorise.Tab>(24);
                            __builder5.AddAttribute(25, "Name", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                        tabNames[1]

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(27, "Availabilities");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(28, "\r\n                            ");
                            __builder5.OpenComponent<Blazorise.Tab>(29);
                            __builder5.AddAttribute(30, "Name", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 42 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                        tabNames[2]

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(31, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(32, "Positions");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(33, "\r\n                            ");
                            __builder5.OpenComponent<Blazorise.Tab>(34);
                            __builder5.AddAttribute(35, "Name", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 43 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                        tabNames[3]

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(36, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(37, "Qualifications");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(38, "\r\n                            ");
                            __builder5.OpenComponent<Blazorise.Tab>(39);
                            __builder5.AddAttribute(40, "Name", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 44 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                        tabNames[4]

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(41, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(42, "Certifications");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(43, "\r\n                            ");
                            __builder5.OpenComponent<Blazorise.Tab>(44);
                            __builder5.AddAttribute(45, "Name", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 45 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                        tabNames[5]

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(46, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(47, "Checks");
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.AddAttribute(48, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<Blazorise.TabPanel>(49);
                            __builder5.AddAttribute(50, "Name", "personal");
                            __builder5.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenElement(52, "div");
                                __builder6.AddAttribute(53, "class", "personal-container");
                                __builder6.AddAttribute(54, "b-zz367dz00p");
                                __builder6.OpenElement(55, "dl");
                                __builder6.AddAttribute(56, "b-zz367dz00p");
                                __builder6.AddMarkupContent(57, "<dt b-zz367dz00p>Birth Date:</dt>\r\n                                        ");
                                __builder6.OpenElement(58, "dd");
                                __builder6.AddAttribute(59, "b-zz367dz00p");
                                __builder6.AddContent(60, 
#nullable restore
#line 52 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.Birthdate

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(61, "\r\n                                        ");
                                __builder6.AddMarkupContent(62, "<dt b-zz367dz00p>Alternate Phone 1:</dt>\r\n                                        ");
                                __builder6.OpenElement(63, "dd");
                                __builder6.AddAttribute(64, "b-zz367dz00p");
                                __builder6.AddContent(65, 
#nullable restore
#line 54 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.AlternatePhone1

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(66, "\r\n                                        ");
                                __builder6.AddMarkupContent(67, "<dt b-zz367dz00p>Alternate Phone 2:</dt>\r\n                                        ");
                                __builder6.OpenElement(68, "dd");
                                __builder6.AddAttribute(69, "b-zz367dz00p");
                                __builder6.AddContent(70, 
#nullable restore
#line 56 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.AlternatePhone2

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(71, "\r\n                                    ");
                                __builder6.OpenElement(72, "dl");
                                __builder6.AddAttribute(73, "b-zz367dz00p");
                                __builder6.AddMarkupContent(74, "<dt b-zz367dz00p>Address:</dt>\r\n                                        ");
                                __builder6.OpenElement(75, "dd");
                                __builder6.AddAttribute(76, "b-zz367dz00p");
                                __builder6.AddContent(77, 
#nullable restore
#line 60 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.Address

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(78, "\r\n                                        ");
                                __builder6.AddMarkupContent(79, "<dt b-zz367dz00p>City:</dt>\r\n                                        ");
                                __builder6.OpenElement(80, "dd");
                                __builder6.AddAttribute(81, "b-zz367dz00p");
                                __builder6.AddContent(82, 
#nullable restore
#line 62 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.City

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(83, "\r\n                                        ");
                                __builder6.AddMarkupContent(84, "<dt b-zz367dz00p>Postal Code:</dt>\r\n                                        ");
                                __builder6.OpenElement(85, "dd");
                                __builder6.AddAttribute(86, "b-zz367dz00p");
                                __builder6.AddContent(87, 
#nullable restore
#line 64 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.PostalCode

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(88, "\r\n                                    ");
                                __builder6.OpenElement(89, "dl");
                                __builder6.AddAttribute(90, "b-zz367dz00p");
                                __builder6.AddMarkupContent(91, "<dt b-zz367dz00p>Emergency Contact:</dt>\r\n                                        ");
                                __builder6.OpenElement(92, "dd");
                                __builder6.AddAttribute(93, "b-zz367dz00p");
                                __builder6.AddContent(94, 
#nullable restore
#line 68 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.EmergencyFullName

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(95, "\r\n                                        ");
                                __builder6.AddMarkupContent(96, "<dt b-zz367dz00p>Relationship to Emergency Contect:</dt>\r\n                                        ");
                                __builder6.OpenElement(97, "dd");
                                __builder6.AddAttribute(98, "b-zz367dz00p");
                                __builder6.AddContent(99, 
#nullable restore
#line 70 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.EmergencyRelationship

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(100, "\r\n                                    ");
                                __builder6.OpenElement(101, "dl");
                                __builder6.AddAttribute(102, "b-zz367dz00p");
                                __builder6.AddMarkupContent(103, "<dt b-zz367dz00p>Emergency Contact Phone 1:</dt>\r\n                                        ");
                                __builder6.OpenElement(104, "dd");
                                __builder6.AddAttribute(105, "b-zz367dz00p");
                                __builder6.AddContent(106, 
#nullable restore
#line 74 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.EmergencyPhone1

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(107, "\r\n                                        ");
                                __builder6.AddMarkupContent(108, "<dt b-zz367dz00p>Emergency Contact Phone 2:</dt>\r\n                                        ");
                                __builder6.OpenElement(109, "dd");
                                __builder6.AddAttribute(110, "b-zz367dz00p");
                                __builder6.AddContent(111, 
#nullable restore
#line 76 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                             member.EmergencyPhone2

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(112, "\r\n                                        ");
                                __builder6.AddMarkupContent(113, "<dt b-zz367dz00p>Emergency Contact Phone 2:</dt>");
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(114, "\r\n                            ");
                            __builder5.OpenComponent<Blazorise.TabPanel>(115);
                            __builder5.AddAttribute(116, "Name", "avail");
                            __builder5.AddAttribute(117, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenElement(118, "div");
                                __builder6.AddAttribute(119, "class", "availability-container");
                                __builder6.AddAttribute(120, "b-zz367dz00p");
                                __builder6.OpenComponent<HRManager.Blazor.Shared.AvailabilityEditor>(121);
                                __builder6.AddAttribute(122, "IsReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 83 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                                                                                                      true

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(123, "AvailabilitiesData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.Dictionary<System.DayOfWeek, System.Collections.Generic.List<HRManager.Common.Dtos.AvailabilityDto>>>(
#nullable restore
#line 83 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                                                                   member.Availabilities

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(124, "AvailabilitiesDataChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.Dictionary<System.DayOfWeek, System.Collections.Generic.List<HRManager.Common.Dtos.AvailabilityDto>>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.Dictionary<System.DayOfWeek, System.Collections.Generic.List<HRManager.Common.Dtos.AvailabilityDto>>>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => member.Availabilities = __value, member.Availabilities))));
                                __builder6.CloseComponent();
                                __builder6.CloseElement();
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(125, "\r\n            ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumns>(126);
                    __builder3.AddAttribute(127, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(128);
                        __builder4.AddAttribute(129, "Field", "FirstName");
                        __builder4.AddAttribute(130, "HeaderText", "First Name");
                        __builder4.AddAttribute(131, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 91 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                                                                 TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(132, "\r\n                ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(133);
                        __builder4.AddAttribute(134, "Field", "LastName");
                        __builder4.AddAttribute(135, "HeaderText", "Last Name");
                        __builder4.AddAttribute(136, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 92 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                                                               TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(137, "\r\n                ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(138);
                        __builder4.AddAttribute(139, "Field", "Email");
                        __builder4.AddAttribute(140, "HeaderText", "Email");
                        __builder4.AddAttribute(141, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 93 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                                                        TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(142, "\r\n                ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(143);
                        __builder4.AddAttribute(144, "Field", "MainPhone");
                        __builder4.AddAttribute(145, "HeaderText", "Phone");
                        __builder4.AddAttribute(146, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 94 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
                                                                            TextAlign.Center

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(147, "\r\n                ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(148);
                        __builder4.AddAttribute(149, "Field", "ApprovalStatus");
                        __builder4.AddAttribute(150, "HeaderText", "Status");
                        __builder4.AddAttribute(151, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 95 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Admin\Members.razor"
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
            }
            ));
            __builder.AddAttribute(152, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
