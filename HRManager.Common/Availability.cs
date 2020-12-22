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
        public MemberProfile Member { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek AvailableDay { get; set; }
    }
}
