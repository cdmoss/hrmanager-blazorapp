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
    public interface IMemberService
    {
        Task<ApiResult<List<TDto>>> GetMembers<TDto>() where TDto : IMemberDto;
        Task<ApiResult<TDto>> GetMember<TDto>(int id) where TDto : IMemberDto;
        Task<ApiResult<object>> AddMember(MemberRegisterDto dto);
        Task<ApiResult<List<AdminMemberDto>>> UpdateMemberForAdmin(AdminMemberDto dto);
        Task<ApiResult<NonAdminMemberDto>> UpdateMemberForMember(NonAdminMemberDto dto);
    }
    public class EFMemberService : IMemberService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EFMemberService> _logger;

        public EFMemberService(MainContext context, ILogger<EFMemberService> logger, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResult<List<TDto>>> GetMembers<TDto>() where TDto : IMemberDto
        {
            try
            {
                var members = await _context.Members
                .Include(p => p.Availabilities)
                .Include(p => p.Positions).ThenInclude(p => p.Position)
                .Include(p => p.WorkExperiences).ToListAsync();

                return new ApiResult<List<TDto>>
                {
                    Dto = _mapper.Map<List<TDto>>(members),
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to fetch member information:\n\n" + ex.Message + "\n\nStack Trace: \n" + ex.StackTrace);

                return new ApiResult<List<TDto>>
                {
                    Successful = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<ApiResult<TDto>> GetMember<TDto>(int id) where TDto : IMemberDto
        {
            try
            {
                var member = await _context.Members
                .Include(p => p.Availabilities)
                .Include(p => p.Positions).ThenInclude(p => p.Position)
                .Include(p => p.WorkExperiences)
                .FirstOrDefaultAsync(m => m.Id == id);

                return new ApiResult<TDto>
                {
                    Dto = _mapper.Map<TDto>(member),
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to fetch member information:\n\n" + ex.Message + "\n\nStack Trace: \n" + ex.StackTrace);

                return new ApiResult<TDto>
                {
                    Successful = false,
                    Error = ex.Message
                };
            }
        }

        public async Task<ApiResult<object>> AddMember(MemberRegisterDto dto)
        {
            try
            {
                var member = CreateMemberProfileFromRegisterDto(dto);
                _context.Add(member);
                await _context.SaveChangesAsync();

                _logger.LogError($"New member profile for {dto.Personal.FirstName} {dto.Personal.LastName} was successfully created");
                return new ApiResult<object>
                {
                    Successful = true,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An issue occured when trying to add a member: \n" + ex.Message + "\n\nStack Trace: \n" + ex.StackTrace);
                return new ApiResult<object>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to load the members. Please try to reload the page."
                };
            }

        }

        public async Task<ApiResult<List<AdminMemberDto>>> UpdateMemberForAdmin(AdminMemberDto dto) 
        {
            try
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == dto.Id);

                UpdateMemberPropertiesForAdmin(dto, member);

                // detach all positions to prevent duplicate entity tracking error when saving
                foreach (var position in dto.Positions)
                {
                    _context.Entry(position).State = EntityState.Detached;
                }

                await _context.SaveChangesAsync();

                var result = await GetMembers<AdminMemberDto>();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An issue occured when trying to update a member: \n" + ex.Message + "\n\nStack Trace: \n" + ex.StackTrace);
                return new ApiResult<List<AdminMemberDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to load the members. Please try to reload the page."
                };
            }
            
        }

        public async Task<ApiResult<NonAdminMemberDto>> UpdateMemberForMember(NonAdminMemberDto dto)
        {
            try
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == dto.Id);

                UpdateMemberPropertiesForMember(dto, member);

                // detach all positions to prevent duplicate entity tracking error when saving
                foreach (var position in dto.Positions)
                {
                    _context.Entry(position).State = EntityState.Detached;
                }

                await _context.SaveChangesAsync();

                var result = await GetMember<NonAdminMemberDto>(member.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An issue occured when trying to update a member: \n" + ex.Message + "\n\nStack Trace: \n" + ex.StackTrace);
                return new ApiResult<NonAdminMemberDto>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to load the members. Please try to reload the page."
                };
            }

        }

        private void UpdateMemberPropertiesForAdmin(AdminMemberDto dto, MemberProfile member) 
        {
            var tempMember = _mapper.Map<MemberProfile>(member);

            member.Email = dto.Email;
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

        private void UpdateMemberPropertiesForMember(NonAdminMemberDto dto, MemberProfile member)
        {
            var tempMember = _mapper.Map<MemberProfile>(member);

            member.Email = dto.Email;
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
            member.VolunteerConfidentiality = tempMember.VolunteerConfidentiality;
            member.VolunteerEthics = tempMember.VolunteerEthics;
            member.CriminalRecordCheck = tempMember.CriminalRecordCheck;
            member.DrivingAbstract = tempMember.DrivingAbstract;
            member.ConfirmationOfProfessionalDesignation = tempMember.ConfirmationOfProfessionalDesignation;
            member.ChildWelfareCheck = tempMember.ChildWelfareCheck;
            member.Positions = tempMember.Positions;
        }

        public MemberProfile CreateMemberProfileFromRegisterDto(MemberRegisterDto dto)
        {
            var member = new MemberProfile();
            var tempMember = 

            member.Email = dto.Account.Email;
            member.FirstName = dto.Personal.FirstName;
            member.LastName = dto.Personal.LastName;
            member.Address = dto.Personal.Address;
            member.City = dto.Personal.City;
            member.PostalCode = dto.Personal.PostalCode;
            member.MainPhone = dto.Personal.MainPhone;
            member.AlternatePhone1 = dto.Personal.AlternatePhone1;
            member.AlternatePhone2 = dto.Personal.AlternatePhone2;
            member.Birthdate = dto.Personal.Birthdate;
            member.EmergencyFullName = dto.Personal.EmergencyFullName;
            member.EmergencyPhone1 = dto.Personal.EmergencyPhone1;
            member.EmergencyPhone2 = dto.Personal.EmergencyPhone2;
            member.EmergencyRelationship = dto.Personal.EmergencyRelationship;
            member.FoodSafe = dto.Certificates.FoodSafe;
            member.FoodSafeExpiry = dto.Certificates.FoodSafeExpiry;
            member.FirstAidCprLevel = dto.Certificates.FirstAidCprLevel;
            member.FirstAidCpr = dto.Certificates.FirstAidCpr;
            member.FirstAidCprExpiry = dto.Certificates.FirstAidCprExpiry;
            member.OtherCertificates = dto.Certificates.OtherCertificates;
            member.EducationTraining = dto.Qualifications.EducationTraining;
            member.SkillsInterestsHobbies = dto.Qualifications.SkillsInterestsHobbies;
            member.Experience = dto.Qualifications.Experience;
            member.OtherBoards = dto.Qualifications.OtherBoards;
            // TODO: add mandatory checks to registration process
            //member.VolunteerConfidentiality = dto.qu.VolunteerConfidentiality;
            //member.VolunteerEthics = dto.VolunteerEthics;
            //member.CriminalRecordCheck = dto.CriminalRecordCheck;
            //member.DrivingAbstract = dto.DrivingAbstract;
            //member.ConfirmationOfProfessionalDesignation = dto.ConfirmationOfProfessionalDesignation;
            //member.ChildWelfareCheck = dto.ChildWelfareCheck;
            member.WorkExperiences = _mapper.Map<List<WorkExperience>>(dto.Qualifications.WorkExperiences);
            member.ApprovalStatus = ApprovalStatus.Pending;
            member.Availabilities = ConvertAvailabilitiesRegisteredToDomain(dto.Availabilities);
            member.Positions = ConvertRegisteredPositionsToMemberPositions(dto.Positions, member);

            return member;
        }

        private List<Availability> ConvertAvailabilitiesRegisteredToDomain(Dictionary<DayOfWeek, List<AvailabilityDto>> registeredAvailabilities)
        {
            var availabilities = new List<Availability>();

            foreach (var dayAvailabilities in registeredAvailabilities)
            {
                var domainAvailabilities = _mapper.Map<List<Availability>>(dayAvailabilities.Value);
                availabilities.AddRange(domainAvailabilities);
            }

            return availabilities;
        }

        private List<MemberPosition> ConvertRegisteredPositionsToMemberPositions(Dictionary<int, PositionSelection> registeredPositions, MemberProfile member)
        {
            var positions = new List<MemberPosition>();

            foreach (var position in registeredPositions)
            {
                if (position.Value.PositionWasSelected)
                {
                    positions.Add(new MemberPosition
                    {
                        Association = AssociationType.Preferred,
                        Position = _context.Positions.FirstOrDefault(p => p.Id == position.Key),
                        Member = member
                    });
                }
            }

            return positions;
        }
    }
}
