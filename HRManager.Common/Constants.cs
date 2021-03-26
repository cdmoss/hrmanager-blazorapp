using System;
using System.Collections.Generic;
using System.Text;

namespace HRManager.Common
{
    public class Constants
    {
        public class Regex
        {
            public const string PostalCode = @"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$";
            public const string Phone = @"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$";
            public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        }
        public class RoleNames
        {
            public const string SuperAdmin = "SuperAdmin";
            public const string Admin = "Admin";
            public const string Member = "Member";
        }
        public class UserNames
        {
            public const string SuperAdmin = "super@email.com";
            public const string Admin = "admin@email.com";
            public const string Member = "test@gmail.com";
        }

        public class ControllerEndpoints
        {
            public const string Delete = "delete";
            public const string UpdateMember = "update/admin";
            public const string UpdateAdmin = "update/team";
            public const string Update = "update";
            public const string Register = "register";
            public const string FullTeam = "all/full";
            public const string MinimalTeam = "all/minimal";
            public const string Seed = "seed";
            public const string AlertsAdmin = "admin";
            public const string All = "all";
            public const string Add = "add";
            public const string Punch = "punch";
            public const string AddFullEntry = "add-full-entry";
            public const string GetCurrent = "get-current";
            public const string GetArchived = "get-archived";
            public const string UpdateUsername = "update-username";
            public const string AlertsAdminUpdate = "admin-update";
            public const string DeleteMultiple = "delete-multiple";
        }

        public class HttpClients
        {
            public const string ApiClient = "ApiClient";
            public const string IdpClient = "IdpClient";
        }

        public class ControllerNames
        {
            public const string Alerts = "alerts";
            public const string Positions = "positions";
            public const string Schedule = "schedule";
            public const string Shifts = "shifts";
            public const string Teams = "teams";
            public const string Timesheet = "timesheet";
            public const string User = "users";
        }
    }
}
