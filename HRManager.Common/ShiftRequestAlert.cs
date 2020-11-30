using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common
{
    public class ShiftRequestAlert : Alert
    {
        public enum RequestStatus
        {
            Pending,
            Accepted,
            Declined
        }

        // necessary when OriginalShift is a recurring shift
        public Shift OriginalShift { get; set; }
        public Shift RequestedShift { get; set; }
        public string Reason { get; set; }
        public RequestStatus Status { get; set; }
        // the alert will persist in the database until both of the below properties == true
        public bool DismissedByAdmin { get; set; }
        public bool DismissedByMember { get; set; }
        public string AddressedBy { get; set; }

        public ShiftRequestAlert()
        {
            AlertType = "shift";
        }

        protected override string GetDescription()
        {
            // include information about the change they want to make?
            return $"{Member.FirstName} {Member.LastName} requested a shift change.";
        }
    }
}
