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
    public interface ITeamService
    {
        Task<ApiResult<List<TDto>>> GetMembers<TDto>() where TDto : IMemberDto;
        Task<ApiResult<TDto>> GetMember<TDto>(int id) where TDto : IMemberDto;
        Task<ApiResult<int>> AddMember(MemberRegisterDto dto);
        Task<ApiResult<List<AdminMemberDto>>> UpdateMemberForAdmin(AdminMemberDto dto);
        Task<ApiResult<NonAdminMemberDto>> UpdateMemberForMember(NonAdminMemberDto dto);
        Task<ApiResult<object>> DeleteMember(int id);
    }

    public class EFTeamService : ITeamService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EFTeamService> _logger;

        public EFTeamService(MainContext context, ILogger<EFTeamService> logger, IMapper mapper)
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

                if (!members.Any())
                {
                    return new ApiResult<List<TDto>>
                    {
                        Successful = true,
                        Data = new List<TDto>()
                    };
                }

                var result = new ApiResult<List<TDto>>
                {
                    Data = _mapper.Map<List<TDto>>(members),
                    Successful = true
                };

                return result;
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
                    Data = _mapper.Map<TDto>(member),
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

        public async Task<ApiResult<int>> AddMember(MemberRegisterDto dto)
        {
            try
            {
                if (dto == null)
                {
                    _logger.LogWarning("User attemped registeration with null data.");
                    return new ApiResult<int>
                    {
                        Successful = false,
                        Error = "No registration was sent to the server."
                    };
                }

                var member = CreateMemberProfile(dto);
                _context.Add(member);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"New member profile for {dto.Personal.FirstName} {dto.Personal.LastName} was successfully created");
                return new ApiResult<int>
                {
                    Data = member.Id,
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An issue occured when trying to add a member: \n" + ex.Message + "\n\nStack Trace: \n" + ex.StackTrace);
                return new ApiResult<int>
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
                // TODO: update identity account username before updating the rest of member information
                await UpdateMemberPropertiesForAdmin(dto, member);

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
                    Error = "An issue occured when trying to update a member."
                };
            }
            
        }

        public async Task<ApiResult<NonAdminMemberDto>> UpdateMemberForMember(NonAdminMemberDto dto)
        {
            try
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == dto.Id);
                // TODO: update identity account username before updating the rest of member information
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
                    Error = "An issue occured when trying to update a member."
                };
            }

        }

        private async Task UpdateMemberPropertiesForAdmin(AdminMemberDto dto, MemberProfile member) 
        {
            var tempMember = _mapper.Map<MemberProfile>(dto);

            member.Email = tempMember.Email;
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
            if (member.ApprovalStatus == ApprovalStatus.Pending)
            {
                var appAlert = await _context.ApplicationAlerts.FirstOrDefaultAsync(m => m.Member == member);
                appAlert.AddressedBy = "";
                member.ApprovalStatus = tempMember.ApprovalStatus;
            }
            member.Availabilities = tempMember.Availabilities;
            member.Positions = tempMember.Positions;
        }

        private void UpdateMemberPropertiesForMember(NonAdminMemberDto dto, MemberProfile member)
        {
            var tempMember = _mapper.Map<MemberProfile>(dto);

            member.Email = tempMember.Email;
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
                IsStaff = dto.Account.IsStaff,
                Email = dto.Account.Email,
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
                WorkExperiences = workExperiences,
                // TODO: add mandatory checks to registration process
                // VolunteerConfidentiality = dto.qu.VolunteerConfidentiality;
                // VolunteerEthics = dto.VolunteerEthics;
                // CriminalRecordCheck = dto.CriminalRecordCheck;
                // DrivingAbstract = dto.DrivingAbstract;
                // ConfirmationOfProfessionalDesignation = dto.ConfirmationOfProfessionalDesignation;
                // ChildWelfareCheck = dto.ChildWelfareCheck;
             };

            if (member.IsStaff)
            {
                member.ApprovalStatus = ApprovalStatus.Approved;
            }
            else
            {
                member.ApprovalStatus = ApprovalStatus.Pending;
            }

            member.Alerts = new List<Alert>() { new ApplicationAlert() { Member = member, Date = DateTime.Now  } };

            var positions = new List<MemberPosition>();

            if (!string.IsNullOrEmpty(dto.Positions))
            {
                var positionIdArray = dto.Positions.Split(',');
                int currentId;
                foreach (var positionId in positionIdArray)
                {
                    if (int.TryParse(positionId, out currentId))
                    {
                        var selectedPosition = _context.Positions.FirstOrDefault(p => p.Id == currentId);
                        positions.Add(new MemberPosition { Member = member, Position = selectedPosition });
                    }
                }
            }

            member.Positions = positions;

            return member;
        }

        public async Task<ApiResult<object>> DeleteMember(int id)
        {
            try
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);

                _context.Remove(member);
                _context.SaveChanges();

                return new ApiResult<object>()
                {
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                string errorString = $"An error occurred when deleting member {id}:\n{ex.Message}";
                _logger.LogError(errorString);

                return new ApiResult<object>()
                {
                    Successful = false,
                    Error = errorString
                };
            }
        }
    }
}
