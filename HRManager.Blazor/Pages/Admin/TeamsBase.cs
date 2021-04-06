using HRManager.Blazor.Pages.Admin;
using HRManager.Blazor.Pages.Account;
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
using Blazored.Modal;
using Blazored.Modal.Services;

namespace HRManager.Blazor.Pages.Admin
{
    public class TeamsBase : ComponentBase
    {
        [CascadingParameter]
        protected Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        protected ITeamService _memberService { get; set; }
        //[Inject]
        //protected IJSRuntime _jsRuntime { get; set; }
        [Inject]
        protected IPositionService _posService { get; set; }
        [Inject]
        public IModalService _modalService { get; set; }
        protected List<AdminMemberDto> team = new List<AdminMemberDto>();
        protected List<AdminMemberDto> filteredTeam = new List<AdminMemberDto>();
        protected List<Position> positions = new List<Position>();
        protected SfGrid<AdminMemberDto> grid;
        protected MemberGridEditTemplate editTemplate = new MemberGridEditTemplate();
        protected List<string> errors = new List<string>();
        protected bool showStaff = false;

        protected override async Task OnInitializedAsync()
        {
            var memberResult = await _memberService.GetFullMembers();
            if (!memberResult.Successful)
            {
                errors.Add(memberResult.Error);
            }
            team = memberResult.Data;
            filteredTeam = team.Where(m => !m.IsStaff).ToList();

            var positionResult = _posService.GetPositions();
            if (!positionResult.Successful)
            {
                errors.Add(positionResult.Error);
            }
            positions = positionResult.Data;
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    //await _jsRuntime.InvokeVoidAsync("teamSwitch");
        //}

        protected async Task BeginActionHandler(ActionEventArgs<AdminMemberDto> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                await editTemplate.UpdatePositions();

                var result = await _memberService.UpdateMember(args.Data);
                if (result.Successful)
                {
                    team = result.Data;
                    filteredTeam = team.Where(m => !m.IsStaff).ToList();
                }
                else
                {
                    errors.Add(result.Error);
                }
            }
        }

        protected void OnlyStaff()
        {
            showStaff = true;
            filteredTeam = team.Where(m => m.IsStaff).ToList();
        }

        protected void OnlyMembers()
        {
            showStaff = false;
            filteredTeam = team.Where(m => !m.IsStaff).ToList();
        }

        protected async Task AddMember()
        {
            var parameters = new ModalParameters();
            parameters.Add("Type", Register.RegistrationType.MemberAdmin);
            var modal = _modalService.Show(typeof(RegisterModal), "Add new member", parameters);
            var modalResult = await modal.Result;
            var registerSuccessful = modalResult.Cancelled ? null : modalResult.Data as bool?;
            if (registerSuccessful == null)
            {
                modal.Close();
                return;
            }
            if (registerSuccessful.Value)
            {
                modal.Close();
                var memberResult = await _memberService.GetFullMembers();
                if (!memberResult.Successful)
                {
                    errors.Add(memberResult.Error);
                }
                team = memberResult.Data;
                filteredTeam = team.Where(m => !m.IsStaff).ToList();
                showStaff = false;
                //TODO: notify successful registration
            }
            else
            {
                modal.Close();
                errors.Add("Registration was unsuccessful, try again or contact the application support team.");
            }
        }

        protected async Task AddStaff()
        {
            var parameters = new ModalParameters();
            parameters.Add("Type", Register.RegistrationType.StaffAdmin);
            var modal = _modalService.Show(typeof(RegisterModal), "Add new staff", parameters);
            var modalResult = await modal.Result;
            var registerSuccessful = modalResult.Cancelled ? null : modalResult.Data as bool?;
            if (registerSuccessful == null)
            {
                modal.Close();
                return;
            }
            if (registerSuccessful.Value)
            {
                modal.Close();
                var memberResult = await _memberService.GetFullMembers();
                if (!memberResult.Successful)
                {
                    errors.Add(memberResult.Error);
                }
                team = memberResult.Data;
                filteredTeam = team.Where(m => m.IsStaff).ToList();
                showStaff = true;
                //TODO: notify successful registration
            }
            else
            {
                modal.Close();
                errors.Add("Registration was unsuccessful, try again or contact the application support team.");
            }
        }
    }
}
