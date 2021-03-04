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
        public EventCallback<string> PositionSelectionChanged { get; set; }
        [Parameter]
        public string PositionSelection { get; set; } = "";

        protected List<Position> positions = new List<Position>();
        protected Dictionary<int, PositionSelection> internalPositionsData;

        protected override void OnInitialized()
        {
            var positionsResult = _posService.GetPositions();

            if (positionsResult.Successful)
            {
                positions = positionsResult.Data;
            }

            internalPositionsData = new Dictionary<int, PositionSelection>();

            foreach (var position in positions)
            {
                internalPositionsData.Add(position.Id, new PositionSelection { PositionWasSelected = false });
            }

            if (!string.IsNullOrEmpty(PositionSelection))
            {
                var positionIds = PositionSelection.Split(',');

                foreach (var id in positionIds)
                {
                    internalPositionsData[Convert.ToInt32(id)].PositionWasSelected = true;
                }

                PositionSelection = null;
            }
        }
    }
}
