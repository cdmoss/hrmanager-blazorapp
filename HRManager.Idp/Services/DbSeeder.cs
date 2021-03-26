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
            var user = new AppUser();

            if (roleName == "SuperAdmin")
            {
                user.UserName = $"sadmin@email.com";
                user.NormalizedUserName = $"SADMIN@EMAIL.COM";
            }
            else if (roleName == "Admin")
            {
                user.UserName = $"admin@email.com";
                user.NormalizedUserName = $"ADMIN@EMAIL.COM";
            }
            else
            {
                user.UserName = $"test{id}@email.com";
                user.NormalizedUserName = $"TEST{id}@EMAIL.COM";
                user.Email = $"test{id}@email.com";
            }

            user.EmailConfirmed = true;
            user.MemberId = id;

            var userResult = await _userManager.CreateAsync(user, "P@$$W0rd");
            if (!userResult.Succeeded)
            {
                await ClearDatabase();
                LogIdentityErrors(userResult, $"Something went wrong when creating seeded identity account for id: {id}:\n\n");
                return false;
            }

            userResult = await _userManager.AddToRoleAsync(user, roleName);

            if (!userResult.Succeeded)
            {
                await ClearDatabase();
                LogIdentityErrors(userResult, $"Something went wrong when adding seeded identity account {id} to role:\n\n");
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
