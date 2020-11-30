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
            public const string SuperAdmin = "SuperAdmin";
            public const string Admin = "Admin";
            public const string Member = "Member";
        }
        public class UserNames
        {
            public const string SuperAdmin = "super";
            public const string Admin = "admin";
            public const string Member = "test@gmail.com";
        }
    }
}
