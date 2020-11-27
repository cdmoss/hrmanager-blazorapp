using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common
{
    [Serializable]
    public class Availability
    {
        public int Id { get; set; }
        public VolunteerProfile Volunteer { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string AvailableDay { get; set; }

        public override string ToString()
        {
            string s = StartTime.ToString().TrimEnd(".00".ToCharArray()).TrimEnd(':') + " to " + EndTime.ToString().TrimEnd(".00".ToCharArray()).TrimEnd(':');
            return s;
        }
    }
}
