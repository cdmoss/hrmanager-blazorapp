#pragma checksum "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "374be1a744073aeb594e45fc619e3ca20f950fb4"
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
#line 1 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
    public partial class Qualifications : RegisterSectionBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h5 b-lin6usk1ol>What kind of similar things have you done before? (Optional)</h5>\r\n<br b-lin6usk1ol>\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 28 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                 qualData

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 28 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                          GoToNextSection

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(5);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "id", "general-experience");
                __builder2.AddAttribute(9, "b-lin6usk1ol");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "id", "education");
                __builder2.AddAttribute(12, "class", "form-group");
                __builder2.AddAttribute(13, "b-lin6usk1ol");
                __builder2.AddMarkupContent(14, "<label b-lin6usk1ol>Education and Training</label>\r\n            ");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(15);
                __builder2.AddAttribute(16, "Multiline", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 33 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(17, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                                     qualData.EducationTraining

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.EducationTraining = __value, qualData.EducationTraining))));
                __builder2.AddAttribute(19, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => qualData.EducationTraining));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_0(__builder2, 21, 22, 
#nullable restore
#line 34 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.EducationTraining

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n        ");
                __builder2.OpenElement(24, "div");
                __builder2.AddAttribute(25, "id", "skills");
                __builder2.AddAttribute(26, "class", "form-group");
                __builder2.AddAttribute(27, "b-lin6usk1ol");
                __builder2.AddMarkupContent(28, "<label b-lin6usk1ol>Skills, Interests and Hobbies</label>\r\n            ");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(29);
                __builder2.AddAttribute(30, "Multiline", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 38 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(31, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 38 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                                     qualData.SkillsInterestsHobbies

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(32, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.SkillsInterestsHobbies = __value, qualData.SkillsInterestsHobbies))));
                __builder2.AddAttribute(33, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => qualData.SkillsInterestsHobbies));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(34, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_1(__builder2, 35, 36, 
#nullable restore
#line 39 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.SkillsInterestsHobbies

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n        ");
                __builder2.OpenElement(38, "div");
                __builder2.AddAttribute(39, "id", "experience");
                __builder2.AddAttribute(40, "class", "form-group");
                __builder2.AddAttribute(41, "b-lin6usk1ol");
                __builder2.AddMarkupContent(42, "<label b-lin6usk1ol>Volunteer Experience</label>\r\n            ");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(43);
                __builder2.AddAttribute(44, "Multiline", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 43 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(45, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 43 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                                     qualData.Experience

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(46, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.Experience = __value, qualData.Experience))));
                __builder2.AddAttribute(47, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => qualData.Experience));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(48, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_2(__builder2, 49, 50, 
#nullable restore
#line 44 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.Experience

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(51, "\r\n        ");
                __builder2.OpenElement(52, "div");
                __builder2.AddAttribute(53, "id", "boards");
                __builder2.AddAttribute(54, "class", "form-group");
                __builder2.AddAttribute(55, "b-lin6usk1ol");
                __builder2.AddMarkupContent(56, "<label b-lin6usk1ol>Volunteer Boards</label>\r\n            ");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(57);
                __builder2.AddAttribute(58, "Multiline", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 48 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(59, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 48 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                                     qualData.OtherBoards

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(60, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.OtherBoards = __value, qualData.OtherBoards))));
                __builder2.AddAttribute(61, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => qualData.OtherBoards));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(62, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_3(__builder2, 63, 64, 
#nullable restore
#line 49 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.OtherBoards

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n    ");
                __builder2.AddMarkupContent(66, "<h5 b-lin6usk1ol>Last or Current Job (If none then leave blank)</h5>\r\n    <br b-lin6usk1ol>\r\n    ");
                __builder2.OpenElement(67, "div");
                __builder2.AddAttribute(68, "id", "work-experience");
                __builder2.AddAttribute(69, "b-lin6usk1ol");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "id", "employer-name");
                __builder2.AddAttribute(72, "class", "form-group");
                __builder2.AddAttribute(73, "b-lin6usk1ol");
                __builder2.AddMarkupContent(74, "<label b-lin6usk1ol>Place of Work</label>\r\n            ");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(75);
                __builder2.AddAttribute(76, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 57 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                    qualData.WorkExperiences.FirstOrDefault().EmployerName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(77, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.WorkExperiences.FirstOrDefault().EmployerName = __value, qualData.WorkExperiences.FirstOrDefault().EmployerName))));
                __builder2.AddAttribute(78, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => qualData.WorkExperiences.FirstOrDefault().EmployerName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(79, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_4(__builder2, 80, 81, 
#nullable restore
#line 58 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.WorkExperiences.FirstOrDefault().EmployerName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(82, "\r\n        ");
                __builder2.OpenElement(83, "div");
                __builder2.AddAttribute(84, "id", "employer-address");
                __builder2.AddAttribute(85, "class", "form-group");
                __builder2.AddAttribute(86, "b-lin6usk1ol");
                __builder2.AddMarkupContent(87, "<label b-lin6usk1ol>Address</label>\r\n            ");
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(88);
                __builder2.AddAttribute(89, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 62 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                    qualData.WorkExperiences.FirstOrDefault().EmployerAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(90, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.WorkExperiences.FirstOrDefault().EmployerAddress = __value, qualData.WorkExperiences.FirstOrDefault().EmployerAddress))));
                __builder2.AddAttribute(91, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => qualData.WorkExperiences.FirstOrDefault().EmployerAddress));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(92, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_5(__builder2, 93, 94, 
#nullable restore
#line 63 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.WorkExperiences.FirstOrDefault().EmployerAddress

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(95, "\r\n        ");
                __builder2.OpenElement(96, "div");
                __builder2.AddAttribute(97, "id", "start");
                __builder2.AddAttribute(98, "class", "form-group");
                __builder2.AddAttribute(99, "b-lin6usk1ol");
                __builder2.AddMarkupContent(100, "<label b-lin6usk1ol>Start Date</label>\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateSfDatePicker_6(__builder2, 101, 102, 
#nullable restore
#line 67 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                       qualData.WorkExperiences.FirstOrDefault().StartDate

#line default
#line hidden
#nullable disable
                , 103, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.WorkExperiences.FirstOrDefault().StartDate = __value, qualData.WorkExperiences.FirstOrDefault().StartDate)), 104, () => qualData.WorkExperiences.FirstOrDefault().StartDate);
                __builder2.AddMarkupContent(105, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_7(__builder2, 106, 107, 
#nullable restore
#line 68 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.WorkExperiences.FirstOrDefault().StartDate

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 70 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
         if (!qualData.WorkExperiences.FirstOrDefault().CurrentJob)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(108, "div");
                __builder2.AddAttribute(109, "id", "end");
                __builder2.AddAttribute(110, "class", "form-group");
                __builder2.AddAttribute(111, "b-lin6usk1ol");
                __builder2.AddMarkupContent(112, "<label b-lin6usk1ol>End Date</label>\r\n                ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateSfDatePicker_8(__builder2, 113, 114, 
#nullable restore
#line 74 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                           qualData.WorkExperiences.FirstOrDefault().EndDate

#line default
#line hidden
#nullable disable
                , 115, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.WorkExperiences.FirstOrDefault().EndDate = __value, qualData.WorkExperiences.FirstOrDefault().EndDate)), 116, () => qualData.WorkExperiences.FirstOrDefault().EndDate);
                __builder2.AddMarkupContent(117, "\r\n                ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_9(__builder2, 118, 119, 
#nullable restore
#line 75 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                          () => qualData.WorkExperiences.FirstOrDefault().EndDate

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 77 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
        }

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(120, "div");
                __builder2.AddAttribute(121, "id", "current");
                __builder2.AddAttribute(122, "class", "form-group");
                __builder2.AddAttribute(123, "b-lin6usk1ol");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateSfCheckBox_10(__builder2, 124, 125, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 79 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                                                                                        HandleCurrentJobCheckChanged

#line default
#line hidden
#nullable disable
                ), 126, 
#nullable restore
#line 79 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                       qualData.WorkExperiences.FirstOrDefault().CurrentJob

#line default
#line hidden
#nullable disable
                , 127, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => qualData.WorkExperiences.FirstOrDefault().CurrentJob = __value, qualData.WorkExperiences.FirstOrDefault().CurrentJob)), 128, () => qualData.WorkExperiences.FirstOrDefault().CurrentJob);
                __builder2.AddMarkupContent(129, "\r\n            ");
                __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications.TypeInference.CreateValidationMessage_11(__builder2, 130, 131, 
#nullable restore
#line 80 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
                                      () => qualData.WorkExperiences.FirstOrDefault().CurrentJob

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(132, "\r\n            ");
                __builder2.AddMarkupContent(133, "<label b-lin6usk1ol>Current Job?</label>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(134, "\r\n    ");
                __builder2.OpenComponent<HRManager.Blazor.Pages.Auth.Registration.RegisterSectionButtonContainer>(135);
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "C:\Users\Chase\Desktop\Programming\HRManager\HRManager.Blazor\Pages\Auth\Registration\Qualifications.razor"
       
    private QualificationsData qualData { get; set; } = new QualificationsData();

    protected override void OnInitialized()
    {
        qualData.WorkExperiences.Add(new WorkExperienceDto());
    }

    protected override async Task GoToNextSection()
    {
        data = qualData;
        await base.GoToNextSection();
    }

    private void HandleCurrentJobCheckChanged()
    {
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
    }
}
namespace __Blazor.HRManager.Blazor.Pages.Auth.Registration.Qualifications
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
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateSfDatePicker_6<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg2)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Calendars.SfDatePicker<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ValueChanged", __arg1);
        __builder.AddAttribute(__seq2, "ValueExpression", __arg2);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_7<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateSfDatePicker_8<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg2)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Calendars.SfDatePicker<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ValueChanged", __arg1);
        __builder.AddAttribute(__seq2, "ValueExpression", __arg2);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_9<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateSfCheckBox_10<TChecked>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Object __arg0, int __seq1, TChecked __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TChecked> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TChecked>> __arg3)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Buttons.SfCheckBox<TChecked>>(seq);
        __builder.AddAttribute(__seq0, "onchange", __arg0);
        __builder.AddAttribute(__seq1, "Checked", __arg1);
        __builder.AddAttribute(__seq2, "CheckedChanged", __arg2);
        __builder.AddAttribute(__seq3, "CheckedExpression", __arg3);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_11<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
