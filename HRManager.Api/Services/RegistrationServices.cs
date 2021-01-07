using AutoMapper;
using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Auth;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface IRegistrationService
    {
        Task<RegisterResult> RegisterUser(MemberRegisterDto dto);
        Task<string> ValidateUsername(string username);
    }

    public class EFIdentityService : IRegistrationService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EFIdentityService> _logger;

        public EFIdentityService(MainContext context, IMapper mapper, ILogger<EFIdentityService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RegisterResult> RegisterUser(MemberRegisterDto dto)
        {
            var memberProfile = CreateMemberProfile(dto);
            await _context.SaveChangesAsync();

            return new RegisterResult { Successful = true };
        }

        private MemberProfile CreateMemberProfile(MemberRegisterDto dto)
        {
            var availabilityDtos = new List<AvailabilityDto>();
            foreach (var availabilityList in dto.Availabilities)
            {
                availabilityDtos.AddRange(availabilityList.Value);
            }

            var availabilities = _mapper.Map<List<Availability>>(availabilityDtos);

            var workExperiences = _mapper.Map<List<WorkExperience>>(dto.Qualifications.WorkExperiences);

            var member = new MemberProfile
            {
                FirstName = dto.Personal.FirstName,
                LastName = dto.Personal.LastName,
                Address = dto.Personal.Address,
                City = dto.Personal.City,
                MainPhone = dto.Personal.MainPhone,
                Birthdate = dto.Personal.Birthdate,
                AlternatePhone1 = dto.Personal.AlternatePhone1,
                AlternatePhone2 = dto.Personal.AlternatePhone2,
                EmergencyPhone1 = dto.Personal.EmergencyPhone1,
                EmergencyPhone2 = dto.Personal.EmergencyPhone2,
                EmergencyFullName = dto.Personal.EmergencyFullName,
                EmergencyRelationship = dto.Personal.EmergencyRelationship,
                Availabilities = availabilities,
                EducationTraining = dto.Qualifications.EducationTraining,
                Experience = dto.Qualifications.Experience,
                OtherBoards = dto.Qualifications.OtherBoards,
                FirstAidCpr = dto.Certificates.FirstAidCpr,
                FirstAidCprExpiry = dto.Certificates.FirstAidCprExpiry,
                FirstAidCprLevel = dto.Certificates.FirstAidCprLevel,
                FoodSafe = dto.Certificates.FoodSafe,
                FoodSafeExpiry = dto.Certificates.FoodSafeExpiry,
                OtherCertificates = dto.Certificates.OtherCertificates,
                PostalCode = dto.Personal.PostalCode,
                SkillsInterestsHobbies = dto.Qualifications.SkillsInterestsHobbies,
                WorkExperiences = workExperiences
            };

            var positions = new List<MemberPosition>();

            foreach (var position in dto.Positions)
            {
                if (position.Value.PositionWasSelected)
                {
                    var p = _context.Positions.FirstOrDefault(p => p.Id == position.Key);
                    positions.Add(new MemberPosition() { Position = p, Member = member });
                }
            }

            member.Positions = positions;

            return member;
        }


        public async Task<string> ValidateUsername(string username)
        {
            //if (string.IsNullOrEmpty(username))
            //{
            //    return "null";
            //}

            //if (user != null)
            //{
            //    return "duplicate";
            //}

            return "valid";
        }
    }
}
