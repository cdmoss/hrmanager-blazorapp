using System;

namespace HRManager.Common.Dtos
{
    public class AvailabilityDto
    {
        public int Id { get; set; }
        public int MemberAdminReadDtoId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek AvailableDay { get; set; }
        public bool IsModified { get; set; }
    }
}
