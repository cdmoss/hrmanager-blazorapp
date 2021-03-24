using HRManager.Idp.Data;
using HRManager.Idp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Idp.Services
{
    public interface IDbSeeder
    {
        Task<bool> SeedUsers(Dictionary<int, string> users);
    }

    public class DbSeeder : IDbSeeder
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ILogger<DbSeeder> _logger;

        public DbSeeder(IdentityContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, ILogger<DbSeeder> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;

            context.Database.EnsureCreated();
        }

        public async Task<bool> SeedUsers(Dictionary<int, string> users)
        {
            // create roles
            if (!_roleManager.Roles.Any())
            {
                if (!await SeedRoles())
                {
                    await ClearDatabase();
                    return false;
                }
            }

            // create user accounts 
            if (!_userManager.Users.Any())
            {
                foreach (var user in users)
                {
                    if(!await CreateUserAccount(user.Key, user.Value))
                    {
                        await ClearDatabase();
                        return false;
                    }
                }
            }

            return true;
        }

        private async Task<bool> CreateUserAccount(int id, string roleName) 
        {
            if (roleName == "SuperAdmin" || roleName == "Admin")
            {
                var superAdmin = new AppUser
                {
                    UserName = $"sadmin@email.com",
                    NormalizedUserName = $"SADMIN@EMAIL.COM",
                    EmailConfirmed = true,
                    MemberId = id
                };

                var sadminResult = await _userManager.CreateAsync(superAdmin, "P@$$W0rd");
                if (!sadminResult.Succeeded)
                {
                    await ClearDatabase();
                    LogIdentityErrors(sadminResult, $"Something went wrong when seeding the super admin account:\n\n");
                    return false;
                }

                sadminResult = await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");

                if (!sadminResult.Succeeded)
                {
                    await ClearDatabase();
                    LogIdentityErrors(sadminResult, $"Something went wrong when adding the seeded super admin account to its role:\n\n");
                    return false;
                }

                var admin = new AppUser
                {
                    UserName = $"admin@email.com",
                    NormalizedUserName = $"ADMIN@EMAIL.COM",
                    EmailConfirmed = true,
                    MemberId = id
                };

                var adminResult = await _userManager.CreateAsync(admin, "P@$$W0rd");
                if (!adminResult.Succeeded)
                {
                    await ClearDatabase();
                    LogIdentityErrors(sadminResult, $"Something went wrong when seeding admin account:\n\n");
                    return false;
                }

                adminResult = await _userManager.AddToRoleAsync(admin, "Admin");

                if (!adminResult.Succeeded)
                {
                    await ClearDatabase();
                    LogIdentityErrors(sadminResult, $"Something went wrong when adding the seeded admin account to its role:\n\n");
                    return false;
                }
            }

            var user = new AppUser
            {
                UserName = $"test{id}@email.com",
                Email = $"test{id}@email.com",
                NormalizedUserName = $"TEST{id}@EMAIL.COM",
                EmailConfirmed = true,
                MemberId = id
            };

            var memberResult = await _userManager.CreateAsync(user, "P@$$W0rd");
            if (!memberResult.Succeeded)
            {
                await ClearDatabase();
                LogIdentityErrors(memberResult, $"Something went wrong when creating seeded identity account for id: {id}:\n\n");
                return false;
            }

            memberResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!memberResult.Succeeded)
            {
                await ClearDatabase();
                LogIdentityErrors(memberResult, $"Something went wrong when adding seeded identity account {id} to role:\n\n");
                return false;
            }

            return true;
        }

        private void LogIdentityErrors(IdentityResult result, string introString)
        {
            string errorString = $"{introString}:\n\n";
            foreach (var error in result.Errors)
            {
                errorString += error.Description + "\n\n";
            }
            _logger.LogError(errorString);
        }

        private async Task ClearDatabase()
        {
            bool usersDeleted = true;

            foreach (var user in _userManager.Users)
            {
                usersDeleted &= (await _userManager.DeleteAsync(user)).Succeeded;
            }

            bool rolesDeleted = true;

            foreach (var role in _roleManager.Roles)
            {
                rolesDeleted &= (await _roleManager.DeleteAsync(role)).Succeeded;
            }

            if (!usersDeleted)
            {
                _logger.LogError("An error occurred when clearing users from the database after a failed seed.");
            }

            if (!rolesDeleted)
            {
                _logger.LogError("An error occurred when clearing roles from the database after a failed seed.");
            }
        }

        private async Task<bool> SeedRoles()
        {
            var memberRole = new IdentityRole<Guid>("Member");
            var adminRole = new IdentityRole<Guid>("Admin");
            var superAdminRole = new IdentityRole<Guid>("SuperAdmin");

            var memberRoleResult = await _roleManager.CreateAsync(memberRole);
            var adminRoleResult = await _roleManager.CreateAsync(adminRole);
            var superAdminRoleResult = await _roleManager.CreateAsync(superAdminRole);

            if (!memberRoleResult.Succeeded)
            {
                LogIdentityErrors(memberRoleResult, "Something went wrong when seeding the database:\n\n");
                return false;
            }

            if (!adminRoleResult.Succeeded)
            {
                LogIdentityErrors(memberRoleResult, "Something went wrong when seeding the database:\n\n");
                return false;
            }

            if (!superAdminRoleResult.Succeeded)
            {
                LogIdentityErrors(memberRoleResult, "Something went wrong when seeding the database:\n\n");
                return false;
            }

            return true;
        }
    }
}
