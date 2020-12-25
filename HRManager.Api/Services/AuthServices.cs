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
    public interface IAuthService
    {
        Task<LoginResult> LoginUser(LoginDto dto);
        Task<RegisterResult> RegisterUser(MemberRegisterDto dto);
        Task<bool> IsValidLoginCredentials(LoginDto dto);
        Task<string> ValidateUsername(string username);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<UserProfile> _userManager;
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<UserProfile> userManager, MainContext context, IMapper mapper, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RegisterResult> RegisterUser(MemberRegisterDto dto)
        {
            var user = new UserProfile { UserName = dto.Account.Email, Email = dto.Account.Email };
            var creationResult = await _userManager.CreateAsync(user, dto.Account.Password);
            if (!creationResult.Succeeded)
            {
                string errorString = "";
                foreach (var error in creationResult.Errors)
                {
                    errorString = $"{error.Code}: {error.Description}\n";
                }
                _logger.LogWarning($"An error occured when trying to create a new member:\n{errorString}");
                var errors = creationResult.Errors.Select(e => e.Description);
                return new RegisterResult { Errors = errors, Successful = false };
            }

            var memberProfile = CreateMemberProfile(dto);
            user.Member = memberProfile;
            await _context.SaveChangesAsync();

            await _userManager.AddToRoleAsync(user, Constants.RoleNames.Member);

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

            // TODO: Clean this up
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

        public async Task<LoginResult> LoginUser(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Email);

            var claims = GetClaims(user);

            var token = GenerateToken(claims);

            var result = new LoginResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Successful = true
            };

            return result;
        }

        private JwtSecurityToken GenerateToken(List<Claim> claims)
        {

            var token = new JwtSecurityToken(
                new JwtHeader(
                    // TODO: store key in azure key vault or alternative
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretdsfdsfsfsdfsfsdfsfsfsfsfgghdgfhdf")),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims)
            );

            return token;
        }

        private List<Claim> GetClaims(UserProfile user)
        {
            var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new { ur.UserId, ur.RoleId, r.Name };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToString()),
                // TODO: Add refresh tokens
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return claims;
        }

        public async Task<bool> IsValidLoginCredentials(LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return false;
            }

            var user = await _userManager.FindByNameAsync(dto.Email);

            if (user == null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(user, dto.Password);
        }

        public async Task<string> ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "null";
            }

            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                return "duplicate";
            }

            return "valid";
        }
    }
}
