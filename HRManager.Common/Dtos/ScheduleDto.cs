using System;
using System.Collections.Generic;
using System.Text;

namespace HRManager.Common.Dtos
{
    public class ScheduleDto
    {
        public ApiResult<List<Position>> PositionResult { get; set; }
        public ApiResult<List<ShiftReadEditDto>> ShiftResult { get; set; }
        public ApiResult<List<MemberMinimalDto>> MemberResult { get; set; }
    }
}
