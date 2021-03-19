using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using HRManager.Api.Data;
using HRManager.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HRManager.Api.Services
{
    public interface IDbSeeder
    {
        ApiResult<List<int>> SeedMembers();
        ApiResult<object> SeedPositions();
        ApiResult<object> SeedShifts();
        ApiResult<object> SeedTimeEntries();
        ApiResult<object> ClearDatabase();
    }

    public class DbSeeder : IDbSeeder
    {
        private readonly MainContext _context;
        private readonly ILogger<DbSeeder> _logger;

        public DbSeeder(MainContext MainContext, ILogger<DbSeeder> logger)
        {
            _context = MainContext;
            _logger = logger;

            _context.Database.EnsureCreated();
        }

        public ApiResult<object> ClearDatabase()
        {
            _context.RemoveRange(_context.Members.ToList());
            _context.RemoveRange(_context.Positions.ToList());
            _context.RemoveRange(_context.Shifts.ToList());
            _context.RemoveRange(_context.Alerts.ToList());
            _context.SaveChangesAsync();

            return null;
        }

        public ApiResult<List<int>> SeedMembers()
        {
            try
            {
                if (_context.Members.Any())
                {
                    return new ApiResult<List<int>>() { Successful = true };
                }

                var testMembers = new List<MemberProfile>();
                var testAlerts = new List<ApplicationAlert>();

                for (int i = 1; i <= 10; i++)
                {
                    var member = new MemberProfile()
                    {
                        Email = $"test{i}@email.com",
                        FirstName = $"testfirst{i}",
                        LastName = $"testlast{i}",
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
                        References = new List<Reference>() { new Reference()
                        {
                            Name = "Steve",
                            Phone = "4034056785",
                            Relationship = "Instructor",
                            Occupation = "Professor"
                        }},
                        WorkExperiences = new List<WorkExperience>() {new WorkExperience()
                        {
                            EmployerName = "testemployer",
                            EmployerAddress = "testaddress",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(20),
                            EmployerPhone = "5555555555",
                            ContactPerson = "testcontact",
                            PositionWorked = "testposition"
                        }}
                    };

                    testMembers.Add(member);

                    testAlerts.Add(new ApplicationAlert
                    {
                        Member = member,
                        Date = DateTime.Now
                    });
                }

                _context.AddRange(testMembers);
                _context.AddRange(testAlerts);
                _context.SaveChanges();

                return new ApiResult<List<int>>() { Data = testMembers.Select(m => m.Id).ToList(), Successful = true };
            }
            catch (Exception ex)
            {
                string errorString = $"Something went wrong when trying to seed members in the database:\nError:{ex.Message}";
                if (ex.Message.ToLower().Contains("inner exception"))
                {
                    errorString += $"\nInner Exception: {ex.InnerException}";
                }
                errorString += $"\nInner Exception: {ex.StackTrace}";

                _logger.LogError(errorString);
                return new ApiResult<List<int>>() { Error = "Something went wrong when trying to seed members in the database.", Successful = false };
            }
        }

        public ApiResult<object> SeedShifts()
        {
            try
            {
                if (_context.Shifts.Any())
                {
                    return new ApiResult<object>() { Successful = true };
                }

                bool membersSeeded = _context.Members.Any();
                bool positionsSeeded = _context.Positions.Any();

                if (!(membersSeeded && positionsSeeded))
                {
                    return new ApiResult<object>() { Successful = false, Error = "Members and positions must be seeded before shifts." };
                }

                var members = _context.Members.ToList();

                var shifts = new List<Shift>();

                int dayOfMonth = 1;
                foreach (var member in members)
                {


                    shifts.Add(new Shift()
                    {
                        Member = member,
                        Position = _context.Positions.FirstOrDefault(),
                        StartTime = new DateTime(1, 1, dayOfMonth, 8, 0, 0),
                        EndTime = new DateTime(1, 1, dayOfMonth, 14, 0, 0),
                        Subject = "Test Shift",
                    });

                    dayOfMonth++;
                }

                _context.AddRange(shifts);
                _context.SaveChanges();

                return new ApiResult<object>() { Successful = true };
            }
            catch (Exception ex)
            {
                string errorString = $"Something went wrong when trying to seed shifts in the database:\nError:{ex.Message}";
                if (ex.Message.ToLower().Contains("inner exception"))
                {
                    errorString += $"\nInner Exception: {ex.InnerException}";
                }
                errorString += $"\nInner Exception: {ex.StackTrace}";

                _logger.LogError(errorString);
                return new ApiResult<object>() { Error = "Something went wrong when trying to seed shifts in the database.", Successful = false };
            }
        }


        public ApiResult<object> SeedPositions()
        {
            if (_context.Positions.Any())
            {
                return new ApiResult<object>() { Successful = true };
            }

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
                    _logger.LogError($"An error occurred when seeding positions:\n\n{ex.Message}\n{ex.StackTrace}");
                    return new ApiResult<object> { Successful = false, Error = "Something went wrong when seeding the positions." };
                }
            }
            return new ApiResult<object> { Successful = true };
        }

        public ApiResult<object> SeedTimeEntries()
        {
            try
            {
                if (_context.TimeEntries.Any())
                {
                    return new ApiResult<object>() { Successful = true };
                }

                bool membersSeeded = _context.Members.Any();
                bool positionsSeeded = _context.Positions.Any();

                if (!(membersSeeded && positionsSeeded))
                {
                    return new ApiResult<object>() { Successful = false, Error = "Members and positions must be seeded before shifts." };
                }

                var members = _context.Members.ToList();

                var timeEntries = new List<TimeEntry>();
                foreach (var member in members)
                {
                    timeEntries.Add(new TimeEntry()
                    {
                        Member = member,
                        Position = _context.Positions.FirstOrDefault(),
                        StartTime = new DateTime(1, 1, 1, 8, 0, 0),
                        EndTime = new DateTime?(new DateTime(1, 1, 1, 4, 0, 0))
                    });

                    timeEntries.Add(new TimeEntry()
                    {
                        Member = member,
                        Position = _context.Positions.FirstOrDefault(),
                        StartTime = DateTime.Now,
                        EndTime = null
                    });
                }

                _context.AddRange(timeEntries);
                _context.SaveChanges();

                return new ApiResult<object>() { Successful = true };
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when seeding time entries:\n\n{ex.Message}\n{ex.StackTrace}");
                return new ApiResult<object> { Successful = false, Error = "Something went wrong when seeding the time entries." };
            }
        }
    }
}
