using System;

namespace HRManager.Common.Dtos
{
    public class ClockedTimeReadDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Position Position { get; set; }
        public VolunteerMinimalDto Volunteer { get; set; }
    }

    public class ClockedTimeCreateDto
    {
        public int Position { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
