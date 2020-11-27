using System;
using System.Collections.Generic;
using System.Text;

namespace HRManager.Common
{
    public class Constants
    {
        public class Regex
        {
            public const string postalCode = @"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$";
            public const string phone = @"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$";
            public const string password = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
        }
        public class RoleNames
        {
            public const string Admin = "Admin";
            public const string Staff = "Staff";
            public const string Volunteer = "Volunteer";
        }
        public class UserNames
        {
            public const string Admin = "fbadmin";
            public const string Staff = "staff";
            public const string Volunteer = "testvol";
        }
    }
}
