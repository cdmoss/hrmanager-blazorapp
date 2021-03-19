using HRManager.Blazor.Services;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Account.Registration
{
    public class PreferredPositionsBase : RegisterSectionBase
    {
        [Inject]
        IPositionService _posService { get; set; }
        [Parameter]
        public Dictionary<int, PositionSelection> PositionSelection { get; set; }
        [Parameter]
        public EventCallback<Dictionary<int, PositionSelection>> PositionSelectionChanged { get; set; }

        protected List<Position> positions = new List<Position>();

        protected override void OnInitialized()
        {
            var positionsResult = _posService.GetPositions();

            if (positionsResult.Successful)
            {
                positions = positionsResult.Data;
            }

            if (PositionSelection.Count() == 0)
            {
                foreach (var position in positions)
                {
                    PositionSelection.Add(position.Id, new PositionSelection { PositionWasSelected = false });
                }
            }
        }

        protected async override Task HandlePreviousSectionRequested()
        {
            await base.HandlePreviousSectionRequested();
        }

        protected async override Task GoToNextSection()
        {
            await base.GoToNextSection();
        }

        protected async override Task HandleDifferentSectionRequested()
        {
            await base.HandleDifferentSectionRequested();
        }
    }
}
