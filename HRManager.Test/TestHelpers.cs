using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Dtos;
using HRManager.Idp.Data;
using HRManager.Idp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Test
{
    public static class TestHelpers
    {
        public static class Data
        {
            public static MemberRegisterDto GenerateRegisterDto()
            {
                var dto = new MemberRegisterDto
                {
                    Account = new AccountCredsData
                    {
                        Email = "test@email.com",
                        Password = "P@$$W0rd",
                        ConfirmPassword = "P@$$W0rd"
                    },
                    Personal = new PersonalAndContactData
                    {
                        FirstName = $"testfirst",
                        LastName = $"testlast",
                        Address = "testAddress",
                        City = "testcity",
                        PostalCode = "T1R1L9",
                        MainPhone = "5555555555",
                        AlternatePhone1 = "5555555555",
                        AlternatePhone2 = "5555555555",
                        Birthdate = DateTime.Now,
                        EmergencyFullName = "testemergency",
                        EmergencyPhone1 = "5555555555",
                        EmergencyPhone2 = "5555555555",
                        EmergencyRelationship = "testrelationship",
                    },
                    Certificates = new CertificatesData
                    {
                        FoodSafe = false,
                        FirstAidCpr = false,
                        OtherCertificates = "TestOther",
                    },
                    Qualifications = new QualificationsData
                    {
                        EducationTraining = "testeducation",
                        SkillsInterestsHobbies = "testskills",
                        Experience = "testexperience",
                        OtherBoards = "otherboards",
                    },
                };
                    
                return dto;
            }

            public static AdminMemberDto GenerateAdminMemberDto(int id)
            {
                var dto = new AdminMemberDto
                {
                    Id = id,
                    Email = $"testupdated@email.com",
                    FirstName = $"testfirstupdated",
                    LastName = $"testlastupdated",
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
                    References = new List<ReferenceDto>() { new ReferenceDto()
                        {
                            Name = "Steve",
                            Phone = "4034056785",
                            Relationship = "Instructor",
                            Occupation = "Professor"
                        }},
                    WorkExperiences = new List<WorkExperienceDto>() {new WorkExperienceDto()
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

                return dto;
            }

            public static MemberEditDto GenerateNonAdminMemberDto(int id)
            {
                var dto = new MemberEditDto
                {
                    Id = id,
                    Email = $"testupdated@email.com",
                    Address = "testAddress",
                    City = "testcity",
                    PostalCode = "T1R1L9",
                    MainPhone = "5555555555",
                    AlternatePhone1 = "5555555555",
                    AlternatePhone2 = "5555555555",
                    EmergencyFullName = "testemergency",
                    EmergencyPhone1 = "5555555555",
                    EmergencyPhone2 = "5555555555",
                    EmergencyRelationship = "testrelationship",
                };

                return dto;
            }

            public static List<MemberProfile> GenerateMemberProfiles()
            {
                var testMembers = new List<MemberProfile>();

                for (int i = 1; i <= 10; i++)
                {
                    testMembers.Add(new MemberProfile()
                    {
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
                    });
                }

                return testMembers;
            }

            public static ShiftReadEditDto GenerateShiftDtoForUpdate(MainContext context)
            {
                var dto = new ShiftReadEditDto()
                {
                    Id = context.Shifts.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = new DateTime(1, 1, 1, 5, 0, 0),
                    EndTime = new DateTime(1, 1, 1, 15, 0, 0),
                    Subject = "Updated Test Shift",
                };

                return dto;
            }

            public static List<ShiftReadEditDto> GenerateShiftDto(MainContext context)
            {
                var testShifts = new List<ShiftReadEditDto>();

                for (int i = 1; i <= 5; i++)
                {
                    testShifts.Add(new ShiftReadEditDto()
                    {
                        PositionId = context.Positions.FirstOrDefault().Id,
                        StartTime = new DateTime(1, 1, 1, 8, 0, 0),
                        EndTime = new DateTime(1, 1, 1, 14, 0, 0),
                        Subject = "Test Shift",
                    });
                }

                return testShifts;
            }
        }

        public class Identity
        {
            public static UserManager<AppUser> CreateUserManager(IdentityContext context)
            {
                var userStore = new UserStore<AppUser, IdentityRole<Guid>, IdentityContext, Guid>(context);
                var hasher = new PasswordHasher<AppUser>();
                var validators = new List<UserValidator<AppUser>>() { new UserValidator<AppUser>() };
                return new UserManager<AppUser>(userStore, null, hasher, validators, null, null, null, null, new NullLogger<UserManager<AppUser>>());
            }

            public static RoleManager<IdentityRole<Guid>> CreateRoleManager(IdentityContext context)
            {
                var roleStore = new RoleStore<IdentityRole<Guid>, IdentityContext, Guid>(context);
                var roleValidators = new List<RoleValidator<IdentityRole<Guid>>> { new RoleValidator<IdentityRole<Guid>>() };
                return new RoleManager<IdentityRole<Guid>>(roleStore, roleValidators, null, null, new NullLogger<RoleManager<IdentityRole<Guid>>>());
            }
        }
    }
}
