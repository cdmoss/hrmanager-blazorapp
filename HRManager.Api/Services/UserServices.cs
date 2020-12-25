using AutoMapper;
using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface IUserService
    {
        ApiResult<List<MemberAdminReadEditDto>> GetMembers();
        ApiResult<List<MemberAdminReadEditDto>> UpdateMember(MemberAdminReadEditDto dto);
    }
    public class EntityUserService : IUserService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EntityUserService> _logger;

        public EntityUserService(MainContext context, ILogger<EntityUserService> logger, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ApiResult<List<MemberAdminReadEditDto>> GetMembers()
        {
            try
            {
                var members = _context.Members.Include(p => p.User)
                .Include(p => p.Availabilities)
                .Include(p => p.Positions).ThenInclude(p => p.Position)
                .Include(p => p.WorkExperiences).ToList();

                return new ApiResult<List<MemberAdminReadEditDto>>
                {
                    Dto = _mapper.Map<List<MemberAdminReadEditDto>>(members),
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to fetch member information:\n\n" + ex.Message);

                return new ApiResult<List<MemberAdminReadEditDto>>
                {
                    Successful = false,
                    Error = ex.Message
                };
            }
        }

        public ApiResult<List<MemberAdminReadEditDto>> UpdateMember(MemberAdminReadEditDto dto)
        {
            try
            {
                var member = _context.Members.Include(m => m.User).FirstOrDefault(m => m.Id == dto.Id);

                UpdateMemberProperties(dto, member);

                // detach all positions to prevent duplicate entity tracking error when saving
                foreach (var position in dto.Positions)
                {
                    _context.Entry(position.Position).State = EntityState.Detached;
                }

                _context.SaveChanges();

                var result = GetMembers();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An issue occured when trying to update a member: \n" + ex.Message + "\n\nStack Trace: \n" + ex.StackTrace);
                return new ApiResult<List<MemberAdminReadEditDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to load the members. Please try to reload the page."
                };
            }
            
        }

        private List<Availability> MemberAvailabilitiesDtoToDomain(Dictionary<DayOfWeek, List<AvailabilityDto>> dtos)
        {
            var availabilities = new List<Availability>();

            foreach (var dayAvailabilities in dtos)
            {
                var domainAvailabilities = _mapper.Map<List<Availability>>(dayAvailabilities.Value);
                availabilities.AddRange(domainAvailabilities);
            }

            return availabilities;
        }

        private Dictionary<DayOfWeek, List<AvailabilityDto>> MemberAvailabilitiesDomainToDto(MemberProfile domain)
        {
            var availabilities = new Dictionary<DayOfWeek, List<AvailabilityDto>>();
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
            {
                availabilities.Add((DayOfWeek)day, new List<AvailabilityDto>());
            }

            foreach (var availbility in domain.Availabilities)
            {
                var availDto = _mapper.Map<AvailabilityDto>(availbility);
                availDto.IsModified = true;
                availabilities[availbility.AvailableDay].Add(availDto);
            }

            return availabilities;
        }

        private void UpdateMemberProperties(MemberAdminReadEditDto dto, MemberProfile member)
        {
            var tempMember = _mapper.Map<MemberProfile>(member);

            member.User.Email = dto.Email;
            member.FirstName = tempMember.FirstName;
            member.LastName = tempMember.LastName;
            member.Address = tempMember.Address;
            member.City = tempMember.City;
            member.PostalCode = tempMember.PostalCode;
            member.MainPhone = tempMember.MainPhone;
            member.AlternatePhone1 = tempMember.AlternatePhone1;
            member.AlternatePhone2 = tempMember.AlternatePhone2;
            member.Birthdate = tempMember.Birthdate;
            member.EmergencyFullName = tempMember.EmergencyFullName;
            member.EmergencyPhone1 = tempMember.EmergencyPhone1;
            member.EmergencyPhone2 = tempMember.EmergencyPhone2;
            member.EmergencyRelationship = tempMember.EmergencyRelationship;
            member.FoodSafe = tempMember.FoodSafe;
            member.FoodSafeExpiry = tempMember.FoodSafeExpiry;
            member.FirstAidCprLevel = tempMember.FirstAidCprLevel;
            member.FirstAidCpr = tempMember.FirstAidCpr;
            member.FirstAidCprExpiry = tempMember.FirstAidCprExpiry;
            member.OtherCertificates = tempMember.OtherCertificates;
            member.EducationTraining = tempMember.EducationTraining;
            member.SkillsInterestsHobbies = tempMember.SkillsInterestsHobbies;
            member.Experience = tempMember.Experience;
            member.OtherBoards = tempMember.OtherBoards;
            member.VolunteerConfidentiality = tempMember.VolunteerConfidentiality;
            member.VolunteerEthics = tempMember.VolunteerEthics;
            member.CriminalRecordCheck = tempMember.CriminalRecordCheck;
            member.DrivingAbstract = tempMember.DrivingAbstract;
            member.ConfirmationOfProfessionalDesignation = tempMember.ConfirmationOfProfessionalDesignation;
            member.ChildWelfareCheck = tempMember.ChildWelfareCheck;
            member.WorkExperiences = tempMember.WorkExperiences;
            member.ApprovalStatus = tempMember.ApprovalStatus;
            member.Availabilities = tempMember.Availabilities;
            member.Positions = tempMember.Positions;
        }
    }
}
