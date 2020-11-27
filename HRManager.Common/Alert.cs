using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common
{
    [Serializable]
    public abstract class Alert
    {
        public int Id { get; set; }
        public VolunteerProfile Volunteer { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
        public bool Deleted { get; set; }
        public string AlertType { get; set; }

        protected virtual string GetDescription()
        {
            return null;
        }
    }
}
