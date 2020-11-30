using System;
using System.Collections.Generic;
using System.Text;
using HRManager.Common;

namespace HRManager.Common
{
    public class ClockedTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Position Position { get; set; }
        public MemberProfile Member { get; set; }
    }
}
