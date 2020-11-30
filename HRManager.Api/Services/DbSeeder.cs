using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using HRManager.Api.Data;
using HRManager.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace HRManager.Api.Services
{
    public class DbSeeder : IDbSeeder
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<UserProfile> _userManager;
        private readonly MainContext _context;

        public DbSeeder(RoleManager<IdentityRole<int>> roleManager, UserManager<UserProfile> userManager, MainContext MainContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = MainContext;
        }

        public bool TestSeed()
        {
            bool result = true;

            result &= SeedRoles();

            result &= SeedTestMember();
            result &= SeedAdmin();

            result &= SeedSuperAdmin();
            result &= SeedPositions();

            return result;
        }

        public bool Seed(bool isDev)
        {
            bool result = true;

            result &= SeedRoles();

            if (isDev)
            {
                result &= SeedTestMember();
                result &= SeedAdmin();
            }

            result &= SeedSuperAdmin();
            result &= SeedPositions();

            return result;
        }

        private bool RoleExists(string roleName)
        {
            return _roleManager.FindByNameAsync(roleName).Result != null;
        }

        private bool UserExists(string userName)
        {
            return _userManager.FindByNameAsync(userName).Result != null;
        }

        private IdentityResult CreateRole(string roleName)
        {
            var role = new IdentityRole<int>(roleName)
            {
                NormalizedName = roleName.ToUpper()
            };

            return _roleManager.CreateAsync(role).Result;
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

        private bool CreateMember(string userName, string userRole)
        {
            var user = new UserProfile()
            {
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                EmailConfirmed = true,
                Email = "cdmossing@gmail.com"
            };

            MemberProfile mem = new MemberProfile()
            {
                FirstName = "testfirst",
                LastName = "testlast",
                Address = "testAddress",
                City = "testcity",
                PostalCode = "T1R1L9",
                MainPhone = "5555555555",
                AlternatePhone1 = "5555555555",
                AlternatePhone2 = "5555555555",
                ApprovalStatus = ApprovalStatus.Pending,
                Birthdate = DateTime.Now,
                EmergencyFullName = "testemergency",
                EmergencyPhone1 = "5555555555",
                EmergencyPhone2 = "5555555555",
                EmergencyRelationship = "testrelationship",
                FoodSafe = false,
                FirstAidCpr = false,
                OtherCertificates = "TestOther",
                EducationTraining = "testeducation",
                SkillsInterestsHobbies = "testskills",
                Experience = "testexperience",
                OtherBoards = "otherboards",
            };

            Reference reference = new Reference()
            {
                Name = "Steve",
                Member = mem,
                Phone = "4034056785",
                Relationship = "Instructor",
                Occupation = "Professor"
            };

            WorkExperience workExp = new WorkExperience()
            {
                EmployerName = "testemployer",
                EmployerAddress = "testaddress",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(20),
                EmployerPhone = "5555555555",
                ContactPerson = "testcontact",
                PositionWorked = "testposition"
            };

            List<Reference> references = new List<Reference>();
            references.Add(reference);
            List<WorkExperience> workExperiences = new List<WorkExperience>();
            workExperiences.Add(workExp);

            mem.References = references;
            mem.WorkExperiences = workExperiences;
            user.Member = mem;

            IdentityResult result = _userManager.CreateAsync(user, "P@$$W0rd").Result;

            if (result.Succeeded)
                SetUserToRole(user, userRole);
            else
                return false;

            return true;
        }

        private void SetUserToRole(UserProfile user, string userRole)
        {
            _userManager.AddToRoleAsync(user, userRole).Wait();
        }

        private bool SeedSuperAdmin()
        {
            if (!UserExists(Constants.UserNames.SuperAdmin))
            {
                bool userCreatedAndRoleWasSet = CreateUser(Constants.UserNames.SuperAdmin, Constants.RoleNames.SuperAdmin);

                if (!userCreatedAndRoleWasSet)
                    return false;
            }
            return true;
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

        private bool SeedTestMember()
        {
            if (!UserExists(Constants.UserNames.Member))
            {
                bool memberCreated = CreateMember(Constants.UserNames.Member, Constants.RoleNames.Member);

                if (!memberCreated)
                    return false;
            }
            return true;
        }

        private bool SeedRoles()
        {
            if (!RoleExists(Constants.RoleNames.SuperAdmin))
            {
                IdentityResult superAdminResult = CreateRole(Constants.RoleNames.SuperAdmin);

                if (!superAdminResult.Succeeded)
                {
                    return false;
                }
            }
            if (!RoleExists(Constants.RoleNames.Admin))
            {
                IdentityResult adminResult = CreateRole(Constants.RoleNames.Admin);

                if (!adminResult.Succeeded)
                {
                    return false;
                }
            }
            if (!RoleExists(Constants.RoleNames.Member))
            {
                IdentityResult memberResult = CreateRole(Constants.RoleNames.Member);

                if (!memberResult.Succeeded)
                {
                    return false;
                }
            }
            return true;
        }

        private bool SeedPositions()
        {
            if (_context.Positions.Count() == 0)
            {
                try
                {
                    Position all = new Position() { Name = "All" };
                    Position warehouse = new Position() { Name = "Warehouse", Color = "#009933" };
                    Position frontstock = new Position() { Name = "Front Stock", Color = "#0066ff" };
                    Position janitorial = new Position() { Name = "Janitorial", Color = "#009999" };
                    Position generalmaintenance = new Position() { Name = "General Maintenance", Color = "#32383d" };
                    Position specialevents = new Position() { Name = "Special Events", Color = "#cc0099" };
                    Position communityrelations = new Position() { Name = "Community Relations", Color = "#ff6600" };

                    _context.Add(all);
                    _context.Add(warehouse);
                    _context.Add(frontstock);
                    _context.Add(janitorial);
                    _context.Add(generalmaintenance);
                    _context.Add(specialevents);
                    _context.Add(communityrelations);

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

    }
}
