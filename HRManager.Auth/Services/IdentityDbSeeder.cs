using HRManager.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Auth.Services
{
    public class IdentityDbSeeder : IDbSeeder
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<UserProfile> _userManager;

        public IdentityDbSeeder(RoleManager<IdentityRole<int>> roleManager, UserManager<UserProfile> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public bool Seed(bool isDev)
        {
            bool result = true;

            if (isDev)
            {
                result &= SeedRoles();
                result &= SeedAdmin();
                result &= SeedStaff();
            }

            return result;
        }

        private bool SeedAdmin()
        {
            if (!UserExists(Constants.UserNames.Admin))
            {
                bool userCreatedAndRoleWasSet = CreateUser(Constants.UserNames.Admin, Constants.RoleNames.Admin);

                if (!userCreatedAndRoleWasSet)
                    return false;
            }
            return true;
        }

        private bool SeedStaff()
        {
            if (!UserExists(Constants.UserNames.Staff))
            {
                bool userCreatedAndRoleWasSet = CreateUser(Constants.UserNames.Staff, Constants.RoleNames.Staff);

                if (!userCreatedAndRoleWasSet)
                    return false;
            }
            return true;
        }

        private bool SeedRoles()
        {
            if (!RoleExists(Constants.RoleNames.Admin))
            {
                IdentityResult adminResult = CreateRole(Constants.RoleNames.Admin);

                if (!adminResult.Succeeded)
                {
                    return false;
                }
            }
            if (!RoleExists(Constants.RoleNames.Staff))
            {
                IdentityResult staffResult = CreateRole(Constants.RoleNames.Staff);

                if (!staffResult.Succeeded)
                {
                    return false;
                }
            }
            if (!RoleExists(Constants.RoleNames.Volunteer))
            {
                IdentityResult volunteerResult = CreateRole(Constants.RoleNames.Volunteer);

                if (!volunteerResult.Succeeded)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CreateUser(string userName, string userRole)
        {
            var user = new UserProfile()
            {
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                EmailConfirmed = true
            };

            IdentityResult result = _userManager.CreateAsync(user, "P@$$W0rd").Result;

            if (result.Succeeded)
                SetUserToRole(user, userRole);
            else
                return false;

            return true;
        }

        private IdentityResult CreateRole(string roleName)
        {
            var role = new IdentityRole<int>(roleName)
            {
                NormalizedName = roleName.ToUpper()
            };

            return _roleManager.CreateAsync(role).Result;
        }

        private void SetUserToRole(UserProfile user, string userRole)
        {
            _userManager.AddToRoleAsync(user, userRole).Wait();
        }

        private bool RoleExists(string roleName)
        {
            return _roleManager.FindByNameAsync(roleName).Result != null;
        }

        private bool UserExists(string userName)
        {
            return _userManager.FindByNameAsync(userName).Result != null;
        }
    }
}
