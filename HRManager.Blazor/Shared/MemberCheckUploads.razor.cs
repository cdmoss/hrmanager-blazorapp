using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Shared
{
    public partial class MemberCheckUploads<TMemberDto> : ComponentBase where TMemberDto : MemberEditDto
    {
        [Parameter]
        public TMemberDto Member { get; set; }
        [Parameter]
        public EventCallback<TMemberDto> MemberChanged { get; set; }

        public async Task OnChangeConfidentiality(UploadChangeEventArgs args)
        {
            using (args.Files[0].Stream)
            {
                Member.VolunteerConfidentialityData = args.Files[0].Stream.ToArray();
            }

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnChangeEthics(UploadChangeEventArgs args)
        {
            using (args.Files[0].Stream)
            {
                Member.VolunteerEthicsData = args.Files[0].Stream.ToArray();
            }

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnChangeCriminal(UploadChangeEventArgs args)
        {
            using (args.Files[0].Stream)
            {
                Member.CriminalRecordCheckData = args.Files[0].Stream.ToArray();
            }

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnChangeDriving(UploadChangeEventArgs args)
        {
            using (args.Files[0].Stream)
            {
                Member.DrivingAbstractData = args.Files[0].Stream.ToArray();
            }

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnChangeDesignation(UploadChangeEventArgs args)
        {
            using (args.Files[0].Stream)
            {
                Member.ConfirmationOfProfessionalDesignationData = args.Files[0].Stream.ToArray();
            }

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnChangeWelfare(UploadChangeEventArgs args)
        {
            using (args.Files[0].Stream)
            {
                Member.ChildWelfareCheckData = args.Files[0].Stream.ToArray();
            }

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnRemoveConfidentiality()
        {
            Member.VolunteerConfidentialityData = null;

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnRemoveEthics()
        {
            Member.VolunteerEthicsData = null;

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnRemoveCriminal()
        {
            Member.CriminalRecordCheckData = null;

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnRemoveDriving()
        {
            Member.DrivingAbstractData = null;

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnRemoveDesignation()
        {
            Member.ConfirmationOfProfessionalDesignationData = null;

            await MemberChanged.InvokeAsync(Member);
        }

        public async Task OnRemoveWelfare()
        {
            Member.ChildWelfareCheckData = null;

            await MemberChanged.InvokeAsync(Member);
        }
    }
}
