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
        private readonly MainContext _context;

        public DbSeeder(MainContext MainContext)
        {
            _context = MainContext;
        }

        public bool TestSeed()
        {
            bool result = true;

            result &= SeedTestMember();

            result &= SeedPositions();

            return result;
        }

        public bool Seed(bool isDev)
        {
            bool result = true;

            if (isDev)
            {
                result &= SeedTestMember();
            }

            result &= SeedPositions();

            return result;
        }

        private bool CreateMember()
        {
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

            return true;
        }
        private bool SeedTestMember()
        {
            bool memberCreated = CreateMember();

            return memberCreated;
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
