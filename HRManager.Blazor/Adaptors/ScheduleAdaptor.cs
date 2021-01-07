using HRManager.Blazor.Services;
using HRManager.Common.Dtos;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Adaptors
{
    public class ScheduleAdaptor : DataAdaptor
    {
        private readonly IShiftService _shiftService;

        public ScheduleAdaptor(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        public override object Read(DataManagerRequest dataManagerRequest, string key = null)
        {
            return _shiftService.GetShifts().Dto;
        }

        public override object Insert(DataManager dataManager, object data, string key)
        {
            var result = _shiftService.AddShifts(new List<ShiftReadEditDto>()
            {
                data as ShiftReadEditDto
            });
            return data;
        }

        public override object Update(DataManager dataManager, object data, string keyField, string key)
        {
            var result = _shiftService.UpdateShifts(new List<ShiftReadEditDto>()
            {
                data as ShiftReadEditDto
            });
            return data;
        }

        public override object BatchUpdate(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
        {
            var addResult = _shiftService.AddShifts((List<ShiftReadEditDto>)addedRecords);
            var updateResult = _shiftService.UpdateShifts((List<ShiftReadEditDto>)changedRecords);

            var deletedShiftIds = ((List<ShiftReadEditDto>)deletedRecords).Select(s => s.Id).ToList();
            

            var deleteResult = _shiftService.DeleteShifts(deletedShiftIds);

            return null;
        }

        public override object Remove(DataManager dataManager, object data, string keyField, string key)
        {
            var result = _shiftService.DeleteShifts(new List<int>() { (int)data });
            return data;
        }
    }
}
