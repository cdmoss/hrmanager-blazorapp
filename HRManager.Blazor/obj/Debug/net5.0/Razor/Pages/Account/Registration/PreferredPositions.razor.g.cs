#pragma checksum "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0565dbd57fdff8f23f36ab768e3bd12c28a8a69c"
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
#line 1 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
using Services;

#line default
#line hidden
#nullable disable
    public partial class PreferredPositions : PreferredPositionsBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h5 b-i1m8hgt6ua>What volunteering positions interest you most?</h5>\r\n<br b-i1m8hgt6ua>\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "id", "3");
            __builder.AddAttribute(3, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 7 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
                        internalPositionsData

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 7 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
                                                              GoToNextSection

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "id", "positions-container");
                __builder2.AddAttribute(10, "class", "d-flex");
                __builder2.AddAttribute(11, "b-i1m8hgt6ua");
#nullable restore
#line 10 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
         if (positions.Any(p => p != null))
        {
            foreach (var position in positions)
            {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "position-container form-group col-4");
                __builder2.AddAttribute(14, "b-i1m8hgt6ua");
                __Blazor.HRManager.Blazor.Pages.Account.Registration.PreferredPositions.TypeInference.CreateSfCheckBox_0(__builder2, 15, 16, 
#nullable restore
#line 15 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
                                               internalPositionsData[position.Id].PositionWasSelected

#line default
#line hidden
#nullable disable
                , 17, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => internalPositionsData[position.Id].PositionWasSelected = __value, internalPositionsData[position.Id].PositionWasSelected)), 18, () => internalPositionsData[position.Id].PositionWasSelected);
                __builder2.AddMarkupContent(19, "\r\n                    ");
                __builder2.OpenElement(20, "label");
                __builder2.AddAttribute(21, "class", "form-check-label");
                __builder2.AddAttribute(22, "b-i1m8hgt6ua");
                __builder2.AddContent(23, 
#nullable restore
#line 16 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
                                                     position.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 18 "C:\Users\Brendan\Desktop\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Registration\PreferredPositions.razor"
            }
        }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.HRManager.Blazor.Pages.Account.Registration.PreferredPositions
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateSfCheckBox_0<TChecked>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TChecked __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TChecked> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TChecked>> __arg2)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Buttons.SfCheckBox<TChecked>>(seq);
        __builder.AddAttribute(__seq0, "Checked", __arg0);
        __builder.AddAttribute(__seq1, "CheckedChanged", __arg1);
        __builder.AddAttribute(__seq2, "CheckedExpression", __arg2);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
