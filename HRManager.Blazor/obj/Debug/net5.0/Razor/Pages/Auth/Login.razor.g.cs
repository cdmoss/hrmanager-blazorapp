#pragma checksum "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c141456daf23803381f190fe1f65efc7b5e6aa73"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages.Auth
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
#line 14 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
using HRManager.Common.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
using HRManager.Blazor.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(AuthLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/auth/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "login-form");
            __builder.AddAttribute(2, "class", "card bg-light p-5");
            __builder.AddAttribute(3, "b-xgczc5qief");
            __builder.AddMarkupContent(4, "<div id=\"img-container\" b-xgczc5qief><img src=\"/MHFB.png\" alt=\"MHFB Logo\" b-xgczc5qief></div>\r\n    ");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "id", "form-container");
            __builder.AddAttribute(7, "b-xgczc5qief");
            __builder.AddMarkupContent(8, "<h2 b-xgczc5qief>Member Sign In</h2>\r\n        <br b-xgczc5qief>\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(9);
            __builder.AddAttribute(10, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 60 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                         loginDto

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 60 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                                   LoginUser

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(13);
                __builder2.CloseComponent();
#nullable restore
#line 62 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
              
                if (invalidCreds)
                {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(14, @"<div class=""alert alert-danger alert-dismissible"" role=""alert"" b-xgczc5qief><button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"" b-xgczc5qief><span aria-hidden=""true"" b-xgczc5qief>&times;</span></button>
                        Invalid username or password. Please try again.
                    </div>");
#nullable restore
#line 69 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                }
            

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "form-group");
                __builder2.AddAttribute(17, "b-xgczc5qief");
                __builder2.AddMarkupContent(18, "<label class=\"form-label\" b-xgczc5qief>Email:</label>\r\n                ");
                __builder2.OpenElement(19, "div");
                __builder2.AddAttribute(20, "b-xgczc5qief");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(21);
                __builder2.AddAttribute(22, "ID", "email");
                __builder2.AddAttribute(23, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Inputs.InputType>(
#nullable restore
#line 74 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                                InputType.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 74 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                                                              loginDto.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginDto.Email = __value, loginDto.Email))));
                __builder2.AddAttribute(26, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => loginDto.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(27, "\r\n                    ");
                __Blazor.HRManager.Blazor.Pages.Auth.Login.TypeInference.CreateValidationMessage_0(__builder2, 28, 29, 
#nullable restore
#line 75 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                              () => loginDto.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n            ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "form-group mb-0");
                __builder2.AddAttribute(33, "b-xgczc5qief");
                __builder2.AddMarkupContent(34, "<label class=\"form-label\" b-xgczc5qief>Password:</label>\r\n                ");
                __builder2.OpenElement(35, "div");
                __builder2.AddAttribute(36, "b-xgczc5qief");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(37);
                __builder2.AddAttribute(38, "ID", "password");
                __builder2.AddAttribute(39, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Inputs.InputType>(
#nullable restore
#line 81 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                                   InputType.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "class", "form-control");
                __builder2.AddAttribute(41, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 81 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                                                                                         loginDto.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(42, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginDto.Password = __value, loginDto.Password))));
                __builder2.AddAttribute(43, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => loginDto.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(44, "\r\n                    ");
                __Blazor.HRManager.Blazor.Pages.Auth.Login.TypeInference.CreateValidationMessage_1(__builder2, 45, 46, 
#nullable restore
#line 82 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                              () => loginDto.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(47, "\r\n            ");
                __builder2.OpenElement(48, "div");
                __builder2.AddAttribute(49, "b-xgczc5qief");
                __builder2.AddMarkupContent(50, "<a id=\"forgot-link\" href=\"#\" b-xgczc5qief>Click here if you forgot your password</a>\r\n                ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "id", "btn-container");
                __builder2.AddAttribute(53, "class", "mt-5");
                __builder2.AddAttribute(54, "b-xgczc5qief");
                __builder2.AddMarkupContent(55, "<button type=\"submit\" id=\"login-btn\" class=\"btn btn-primary\" b-xgczc5qief>Login</button>\r\n                    ");
                __builder2.OpenElement(56, "button");
                __builder2.AddAttribute(57, "type", "button");
                __builder2.AddAttribute(58, "id", "register-btn");
                __builder2.AddAttribute(59, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 89 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
                                                                      GoToRegistration

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(60, "class", "btn btn-outline-primary");
                __builder2.AddAttribute(61, "b-xgczc5qief");
                __builder2.AddContent(62, "Become A Volunteer");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Login.razor"
       
    // TODO: Add redirect URI

    // must create instance of model to be bound*******
    private LoginDto loginDto = new LoginDto();

    [CascadingParameter]
    private Task<AuthenticationState> authState { get; set; }
    private bool invalidCreds = false;

    protected override async Task OnInitializedAsync()
    {
        await _authService.Logout();
    }

    private async Task LoginUser()
    {
        var loginResult = await _authService.Login(loginDto);
        if (loginResult.Successful)
        {
            var user = (await authState).User;

            if (user.IsInRole("Admin") || user.IsInRole("SuperAdmin"))
            {
                _nav.NavigateTo("/admin/members");
            }
            else
            {
                _nav.NavigateTo("/member/calendar");
            }
        }
        else
        {
            invalidCreds = true;
        }
    }

    private void GoToRegistration()
    {
        _nav.NavigateTo("/auth/register");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthService _authService { get; set; }
    }
}
namespace __Blazor.HRManager.Blazor.Pages.Auth.Login
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
