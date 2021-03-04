using System;
using System.ComponentModel.DataAnnotations;

namespace HRManager.Common.Dtos
{
    public class TimeEntryReadEditDto
    {
        [Required]
        public int Id { get; set; }
        // TODO: add validation to ensure start time is before end time
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        public Position Position { get; set; }
        [Required]
        public int PositionId { get; set; }
        public MemberMinimalDto Member { get; set; }
        [Required]
        public int MemberId { get; set; }
    }

    public class TimeEntryCreateDto
    {
        [Required]
        public int PositionId { get; set; }
        [Required]
        public int MemberId { get; set; }
        // TODO: add validation to ensure start time is before end time
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
