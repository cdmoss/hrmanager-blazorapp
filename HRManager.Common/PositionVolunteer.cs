using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common
{
    [Serializable]
    public class PositionVolunteer
    {
        public enum AssociationType
        {
            Preferred,
            Assigned,
            PreferredAndAssigned
        }

        public int Id { get; set; }
        public VolunteerProfile Volunteer { get; set; }
        public Position Position { get; set; }
        public AssociationType Association { get; set; }
    }
}
