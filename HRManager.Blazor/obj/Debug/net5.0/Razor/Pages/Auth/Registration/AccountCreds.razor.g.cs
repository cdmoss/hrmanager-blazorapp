#pragma checksum "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f94f2ed6fb7376dc0e9b333131652523a9836ea"
// <auto-generated/>
#pragma warning disable 1591
namespace HRManager.Blazor.Pages.Auth.Registration
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
#line 15 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
using Blazor.Services;

#line default
#line hidden
#nullable disable
    public partial class AccountCreds : RegisterSectionBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h5>What email and password would you like to use?</h5>\r\n<br>\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "id", "1");
            __builder.AddAttribute(3, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 68 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                        AccountData

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 68 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                                     GoToNextSection

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenComponent<HRManager.Blazor.Pages.Auth.Registration.UsernameValidator>(8);
                __builder2.AddComponentReferenceCapture(9, (__value) => {
#nullable restore
#line 70 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                             usernameValidator = (HRManager.Blazor.Pages.Auth.Registration.UsernameValidator)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(10, "\r\n    ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "form-group");
                __builder2.AddMarkupContent(13, "<label for=\"email\" class=\"form-label\">Email:</label>\r\n        ");
                __builder2.OpenElement(14, "div");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(15);
                __builder2.AddAttribute(16, "ID", "email");
                __builder2.AddAttribute(17, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 74 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                               AccountData.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => AccountData.Email = __value, AccountData.Email))));
                __builder2.AddAttribute(19, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => AccountData.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.AccountCreds.TypeInference.CreateValidationMessage_0(__builder2, 21, 22, 
#nullable restore
#line 75 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                      () =>AccountData.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n    ");
                __builder2.OpenElement(24, "div");
                __builder2.AddAttribute(25, "class", "form-group");
                __builder2.AddMarkupContent(26, "<label for=\"password\" class=\"form-label\">Password:</label>\r\n        ");
                __builder2.OpenElement(27, "div");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(28);
                __builder2.AddAttribute(29, "ID", "password");
                __builder2.AddAttribute(30, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Inputs.InputType>(
#nullable restore
#line 81 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                           InputType.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(31, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 81 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                                                            AccountData.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(32, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => AccountData.Password = __value, AccountData.Password))));
                __builder2.AddAttribute(33, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => AccountData.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(34, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.AccountCreds.TypeInference.CreateValidationMessage_1(__builder2, 35, 36, 
#nullable restore
#line 82 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                      () => AccountData.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n    ");
                __builder2.OpenElement(38, "div");
                __builder2.AddAttribute(39, "class", "form-group");
                __builder2.AddMarkupContent(40, "<label for=\"confirm-password\" class=\"form-label\">Confirm Password:</label>\r\n        ");
                __builder2.OpenElement(41, "div");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(42);
                __builder2.AddAttribute(43, "ID", "confirm-password");
                __builder2.AddAttribute(44, "Type", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Inputs.InputType>(
#nullable restore
#line 88 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                                   InputType.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(45, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 88 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                                                                    AccountData.ConfirmPassword

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(46, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => AccountData.ConfirmPassword = __value, AccountData.ConfirmPassword))));
                __builder2.AddAttribute(47, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => AccountData.ConfirmPassword));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(48, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.AccountCreds.TypeInference.CreateValidationMessage_2(__builder2, 49, 50, 
#nullable restore
#line 89 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
                                      () => AccountData.ConfirmPassword

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\AccountCreds.razor"
       
    private UsernameValidator usernameValidator;

    [Parameter]
    public EventCallback<AccountRegisterData> AccountDataChanged { get; set; }
    [Parameter]
    public AccountRegisterData AccountData { get; set; }

    //private async Task HandleValidSubmit(EditContext editContext)
    //{
    //    usernameValidator.ClearErrors();

    //    var errors = new Dictionary<string, List<string>>();
    //    errors.Add("UsernameValidation", new List<string>());

    //    try
    //    {
    //        var validationResult = await _authService.ValidateUsername(AccountData.Email);
    //        if (validationResult == "duplicate")
    //        {
    //            errors["UsernameValidation"].Add("That email is already in use.");
    //            usernameValidator.DisplayErrors(errors);
    //        }
    //        else if (validationResult == "null")
    //        {
    //            errors["UsernameValidation"].Add("There was an error in validating the entered email.");
    //            usernameValidator.DisplayErrors(errors);
    //        }
    //        else
    //        {
    //            await GoToNextSection();
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        errors["UsernameValidation"].Add("There was an error in validating the entered email.");
    //        usernameValidator.DisplayErrors(errors);
    //        throw;
    //    }
    //}

    protected override async Task GoToNextSection()
    {
        await AccountDataChanged.InvokeAsync(AccountData);
        await base.GoToNextSection();
    }

    protected override async Task HandlePreviousSectionRequested()
    {
        await AccountDataChanged.InvokeAsync(AccountData);
        await base.HandlePreviousSectionRequested();
    }

    protected override async Task HandleDifferentSectionRequested()
    {
        await AccountDataChanged.InvokeAsync(AccountData);
        await base.HandlePreviousSectionRequested();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthService _authService { get; set; }
    }
}
namespace __Blazor.HRManager.Blazor.Pages.Auth.Registration.AccountCreds
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
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
