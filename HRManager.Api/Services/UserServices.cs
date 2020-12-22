using AutoMapper;
using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface IUserService
    {
        List<MemberAdminReadEditDto> GetMembers();
    }
    public class EntityUserService : IUserService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public EntityUserService(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MemberAdminReadEditDto> GetMembers()
        {
            var members = _context.Members.Include(p => p.User)
                .Include(p => p.Availabilities)
                .Include(p => p.Positions).ThenInclude(p => p.Position)
                .Include(p => p.WorkExperiences).ToList();
            var memberDtos = new List<MemberAdminReadEditDto>();

            foreach (var member in members)
            {
                var dto = DomainToAdminDto(member);
                dto.Email = member.User.Email;
                memberDtos.Add(dto);
            }

            return memberDtos;
        }

        private MemberAdminReadEditDto DomainToAdminDto(MemberProfile domain)
        {
            var workExperiences = _mapper.Map<List<WorkExperienceDto>>(domain.WorkExperiences);

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

            var dto = _mapper.Map<MemberAdminReadEditDto>(domain);

            dto.Availabilities = availabilities;

            return dto;
        }
    }
}
