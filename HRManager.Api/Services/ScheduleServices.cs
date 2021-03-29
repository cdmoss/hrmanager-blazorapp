//using HRManager.Common.Dtos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HRManager.Api.Services
//{
//    public interface IScheduleService
//    {
//        Task<ScheduleDto> GetScheduleData();
//    }

//    public class EFScheduleService : IScheduleService
//    {
//        private readonly IShiftService _shiftService;
//        private readonly ITeamService _userService;
//        private readonly IPositionService _positionService;

//        public EFScheduleService(IShiftService shiftService, ITeamService userService, IPositionService positionService)
//        {
//            _shiftService = shiftService;
//            _userService = userService;
//            _positionService = positionService;
//        }

//        public async Task<ScheduleDto> GetScheduleData()
//        {
//            var data = new ScheduleDto
//            {
//                ShiftResult = await _shiftService.GetShifts(),
//                MemberResult = await _userService.GetMembers<MemberMinimalDto>(),
//                PositionResult = await _positionService.GetPositions()
//            };

//            return data;
//        }
//    }
//}
