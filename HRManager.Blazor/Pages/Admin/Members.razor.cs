using Microsoft.AspNetCore.Components;
using HRManager.Common.Dtos;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using HRManager.Blazor.Services;

namespace HRManager.Blazor.Pages.Admin
{
    public partial class Members
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        private IUserService _userService { get; set; }
        private List<MemberAdminReadEditDto> members;

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                members = await _userService.GetMembers();
            }
        }
    }
}
