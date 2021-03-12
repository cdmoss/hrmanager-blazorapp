using HRManager.Blazor.Pages.Admin;
using HRManager.Blazor.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class TeamsBase : ComponentBase
    {
        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        protected IMemberService _memberService { get; set; }
        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }
        [Inject]
        protected IPositionService _posService { get; set; }
        protected List<AdminMemberDto> members;
        protected List<Position> positions;
        protected MemberGridEditTemplate editTemplate = new MemberGridEditTemplate();
        protected List<string> errors = new List<string>();


        Dictionary<int, string> selectedTabs = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var memberResult = await _memberService.GetFullMembers();
                if (memberResult.Successful)
                {
                    members = memberResult.Data;

                    var positionResult = _posService.GetPositions();
                    if (positionResult.Successful)
                    {
                        positions = positionResult.Data;

                        foreach (var member in members)
                        {
                            selectedTabs.Add(member.Id, "personal," + member.Id);
                        }
                    }
                    else
                    {
                        errors.Add(positionResult.Error);
                    }
                }
                else
                {
                    errors.Add(memberResult.Error);
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await _jsRuntime.InvokeVoidAsync("teamSwitch");
        }

        protected async Task BeginActionHandler(ActionEventArgs<AdminMemberDto> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                await editTemplate.UpdatePositions();

                var result = await _memberService.UpdateMember(args.Data);
                if (result.Successful)
                {
                    members = result.Data;
                }
                else
                {
                    errors.Add(result.Error);
                }
            }
        }

        protected void OnTabChanged(string name)
        {
            int id = Convert.ToInt32(name.Split(',')[1]);
            selectedTabs[id] = name;
        }
    }
}
