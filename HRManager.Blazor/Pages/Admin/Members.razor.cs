using Microsoft.AspNetCore.Components;
using HRManager.Common.Dtos;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using HRManager.Blazor.Services;
using Syncfusion.Blazor;
using System;
using HRManager.Common;
using Syncfusion.Blazor.Grids;

namespace HRManager.Blazor.Pages.Admin
{
    public partial class Members
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        private IUserService _userService { get; set; }
        [Inject]
        private IPositionService _posService { get; set; }
        private List<MemberAdminReadEditDto> members;
        private List<Position> positions;
        private GridEditTemplate editTemplate = new GridEditTemplate();
        string error;
        

        Dictionary<int, string> selectedTabs = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var memberResult = await _userService.GetMembers<MemberAdminReadEditDto>();
                if (memberResult.Successful)
                {
                    members = memberResult.Dto;

                    var positionResult = await _posService.GetPositions();
                    if (positionResult.Successful)
                    {
                        positions = positionResult.Dto;

                        foreach (var member in members)
                        {
                            selectedTabs.Add(member.Id, "personal," + member.Id);
                        }
                    }
                }
                else
                {
                    error = memberResult.Error;
                }
            }
        }

        private async Task BeginActionHandler(ActionEventArgs<MemberAdminReadEditDto> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                await editTemplate.UpdatePositions();

                var result = await _userService.UpdateMember(args.Data);
                if (result.Successful)
                {
                    members = result.Dto;
                }
                else
                {
                    error = result.Error;
                }
            }
        }

        private void OnTabChanged(string name)
        {
            int id = Convert.ToInt32(name.Split(',')[1]);
            selectedTabs[id] = name;
        }
    }
}
