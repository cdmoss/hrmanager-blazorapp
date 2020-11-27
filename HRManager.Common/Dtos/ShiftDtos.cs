using System;
using HRManager.Common.Services;

namespace HRManager.Common.Dtos
{
    public class ShiftReadEditDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        [DateLessThan("EndTime")]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? PositionId { get; set; }
        public int? VolunteerProfileId { get; set; }
        public Position PositionWorked { get; set; }
        public VolunteerMinimalDto Volunteer { get; set; }
        public string Description { get; set; }
        public bool IsRecurrence { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public int? RecurrenceID { get; set; }
        public bool IsBlock { get; set; }
    }
}
