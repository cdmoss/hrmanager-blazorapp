using Microsoft.AspNetCore.Components;
using HRManager.Common.Dtos;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using HRManager.Blazor.Services;
using System;

namespace HRManager.Blazor.Pages.Admin
{
    public partial class Members
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        private IUserService _userService { get; set; }
        private List<MemberAdminReadEditDto> members;
        

        Dictionary<int, string> selectedTabs = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                members = await _userService.GetMembers();

                foreach (var member in members)
                {
                    selectedTabs.Add(member.Id, "personal");
                }
            }
        }

        private void OnTabChanged(string name)
        {
            string[] splitName = name.Split(',');
            int id = Convert.ToInt32(splitName[1]);
            selectedTabs[id] = splitName[0];
        }
    }
}
