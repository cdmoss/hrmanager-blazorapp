#pragma checksum "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cd07a4818adbcdfb46bb9091ed3a5305ed285c4"
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
#line 3 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
using HRManager.Common.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
using HRManager.Common.Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
using HRManager.Blazor.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
using HRManager.Blazor.Pages.Account.Registration;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(AuthLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/account/register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 63 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
 if (ShowErrors)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "alert alert-danger");
            __builder.AddAttribute(2, "role", "alert");
            __builder.AddAttribute(3, "b-pg4w4jd0hl");
#nullable restore
#line 66 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
         foreach (var error in Errors)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "p");
            __builder.AddAttribute(5, "b-pg4w4jd0hl");
            __builder.AddContent(6, 
#nullable restore
#line 68 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                error

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 69 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 71 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
 switch (currentSection)
{
    case 0:
        _nav.NavigateTo("/");
        break;
    case 1:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.AccountCreds>(7);
            __builder.AddAttribute(8, "SectionCompleted", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 79 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                            HandleSectionCompleted

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(9, "PreviousSectionRequested", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 79 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                                                              HandlePreviousSectionRequested

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(10, "AccountData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<HRManager.Common.Dtos.AccountRegisterData>(
#nullable restore
#line 79 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                         mainDto.Account

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "AccountDataChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.AccountRegisterData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.AccountRegisterData>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => mainDto.Account = __value, mainDto.Account))));
            __builder.CloseComponent();
#nullable restore
#line 80 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        break;
    case 2:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.PersonalAndContact>(12);
            __builder.AddAttribute(13, "SectionCompleted", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 82 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                    HandleSectionCompleted

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(14, "PreviousSectionRequested", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 82 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                                                                      HandlePreviousSectionRequested

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(15, "PersonalData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<HRManager.Common.Dtos.PersonalAndContactData>(
#nullable restore
#line 82 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                mainDto.Personal

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "PersonalDataChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.PersonalAndContactData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.PersonalAndContactData>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => mainDto.Personal = __value, mainDto.Personal))));
            __builder.CloseComponent();
#nullable restore
#line 83 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        break;
    case 3:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.PreferredPositions>(17);
            __builder.AddAttribute(18, "SectionCompleted", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 85 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                          HandleSectionCompleted

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(19, "PreviousSectionRequested", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 85 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                                                                            HandlePreviousSectionRequested

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(20, "PositionSelection", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 85 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                     mainDto.Positions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "PositionSelectionChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => mainDto.Positions = __value, mainDto.Positions))));
            __builder.CloseComponent();
#nullable restore
#line 86 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        break;
    case 4:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.Availability>(22);
            __builder.AddAttribute(23, "SectionCompleted", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 88 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                          HandleSectionCompleted

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(24, "PreviousSectionRequested", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 88 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                                                                            HandlePreviousSectionRequested

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(25, "AvailabilitiesData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.Dictionary<System.DayOfWeek, System.Collections.Generic.List<HRManager.Common.Dtos.AvailabilityDto>>>(
#nullable restore
#line 88 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                mainDto.Availabilities

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "AvailabilitiesDataChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.Dictionary<System.DayOfWeek, System.Collections.Generic.List<HRManager.Common.Dtos.AvailabilityDto>>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.Dictionary<System.DayOfWeek, System.Collections.Generic.List<HRManager.Common.Dtos.AvailabilityDto>>>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => mainDto.Availabilities = __value, mainDto.Availabilities))));
            __builder.CloseComponent();
#nullable restore
#line 89 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        break;
    case 5:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.Qualifications>(27);
            __builder.AddAttribute(28, "SectionCompleted", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 91 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                            HandleSectionCompleted

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(29, "PreviousSectionRequested", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 91 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                                                                              HandlePreviousSectionRequested

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(30, "QualificationsData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<HRManager.Common.Dtos.QualificationsData>(
#nullable restore
#line 91 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                  mainDto.Qualifications

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "QualificationsDataChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.QualificationsData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.QualificationsData>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => mainDto.Qualifications = __value, mainDto.Qualifications))));
            __builder.CloseComponent();
#nullable restore
#line 92 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        break;
    case 6:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.Certificates>(32);
            __builder.AddAttribute(33, "SectionCompleted", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 94 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                              SubmitRegistration

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(34, "PreviousSectionRequested", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.MemberSectionData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.MemberSectionData>(this, 
#nullable restore
#line 94 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                                                            HandlePreviousSectionRequested

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(35, "CertData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<HRManager.Common.Dtos.CertificatesData>(
#nullable restore
#line 94 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                      mainDto.Certificates

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(36, "CertDataChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<HRManager.Common.Dtos.CertificatesData>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<HRManager.Common.Dtos.CertificatesData>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => mainDto.Certificates = __value, mainDto.Certificates))));
            __builder.CloseComponent();
#nullable restore
#line 95 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        break;
    case 7:
        if (loadingSubmission)
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(37, "<p b-pg4w4jd0hl>Waiting for your application to be verified...</p>");
#nullable restore
#line 100 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.Result>(38);
            __builder.AddAttribute(39, "IsSuccessful", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 103 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                  isSuccessful

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
#nullable restore
#line 104 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
        }
        break;
}

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<HRManager.Blazor.Pages.Account.Registration.RegisterSectionButtonContainer>(40);
            __builder.AddAttribute(41, "PreviousSectionRequested", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, 
#nullable restore
#line 107 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                          HandlePreviousSectionRequested

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(42, "Progress", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 107 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                                                                                                     currentSection

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(43, "\r\n\r\n");
            __builder.OpenElement(44, "button");
            __builder.AddAttribute(45, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 109 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
                  TestRegistration

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(46, "b-pg4w4jd0hl");
            __builder.AddContent(47, "Test Registration");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Programming\hrmanager-blazorapp\HRManager.Blazor\Pages\Account\Register.razor"
       
    // must create instance of model to be bound*******
    private MemberRegisterDto mainDto = new MemberRegisterDto();
    private bool isSuccessful;
    private int currentSection = 1;
    private bool loadingSubmission = false;
    private bool ShowErrors;
    private int test;
    private IEnumerable<string> Errors;

    private async Task SubmitRegistration()
    {
        loadingSubmission = true;
        currentSection++;
        isSuccessful = await _regService.Register(mainDto);
        loadingSubmission = false;
    }

    private async Task TestRegistration()
    {
        mainDto.Account.Email = "test@email.com";
        mainDto.Account.Password = "P@$$W0rd";
        mainDto.Account.ConfirmPassword = "P@$$W0rd";
        mainDto.Personal.FirstName = "Test First";
        mainDto.Personal.LastName = "Test last";
        mainDto.Personal.Address = "test address";
        mainDto.Personal.City = "test city";
        mainDto.Personal.MainPhone = "5555555555";
        mainDto.Personal.Birthdate = DateTime.Now;
        mainDto.Personal.EmergencyPhone1 = "5555555555";
        mainDto.Personal.EmergencyRelationship = "test relationship";
        mainDto.Personal.EmergencyFullName = "test emerg name";
        mainDto.Personal.PostalCode = "t5t5t5";

        loadingSubmission = true;
        currentSection = 7;
        isSuccessful = await _regService.Register(mainDto);
        loadingSubmission = false;
    }

    private void HandleSectionCompleted()
    {
        currentSection++;
        StateHasChanged();
    }

    private void HandlePreviousSectionRequested()
    {
        currentSection--;
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRegistrationService _regService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _nav { get; set; }
    }
}
#pragma warning restore 1591
