using AutoMapper;
using HRManager.Common;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.MapperProfiles
{
    public class MemberProfileMapperProfile : Profile
    {
        public MemberProfileMapperProfile()
        {
            // source --> target
            CreateMap<MemberProfile, MemberAdminReadEditDto>()
                .ForMember(dest => dest.Availabilities, opt => opt.MapFrom<MemberDomainToDtoAvailResolver>())
                .ForPath(dest => dest.Email, opt => opt.MapFrom(s => s.User.Email))
                .ReverseMap()
                .ForMember(dest => dest.Availabilities, opt => opt.MapFrom<MemberDtoToDomainAvailResolver>())
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(s => s.Email));
            CreateMap<MemberProfile, MemberMinimalDto>().ReverseMap();

            CreateMap<MemberRegisterDto, MemberProfile>()
                .ForMember(p => p.Availabilities, opt => opt.Ignore())
                .ForMember(p => p.Positions, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(p => p.Availabilities, opt => opt.Ignore())
                .ForMember(p => p.Positions, opt => opt.Ignore());

            CreateMap<MemberProfile, AccountData>().ReverseMap();
            CreateMap<MemberProfile, PersonalAndContactData>().ReverseMap();
            CreateMap<MemberProfile, QualificationsData>().ReverseMap();
            CreateMap<MemberProfile, CertificatesData>().ReverseMap();
        }
    }

    public class MemberDomainToDtoAvailResolver : IValueResolver<MemberProfile, MemberAdminReadEditDto, Dictionary<DayOfWeek, List<AvailabilityDto>>>
    {
        public Dictionary<DayOfWeek, List<AvailabilityDto>> Resolve(MemberProfile domain, MemberAdminReadEditDto dto, Dictionary<DayOfWeek, List<AvailabilityDto>> destMember, ResolutionContext context)
        {
            var availabilities = new Dictionary<DayOfWeek, List<AvailabilityDto>>();
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
            {
                availabilities.Add((DayOfWeek)day, new List<AvailabilityDto>());
            }

            foreach (var availbility in domain.Availabilities)
            {
                var availDto = new AvailabilityDto
                {
                    AvailableDay = availbility.AvailableDay,
                    StartTime = availbility.StartTime,
                    EndTime = availbility.EndTime,
                    IsModified = true
                };

                availabilities[availbility.AvailableDay].Add(availDto);
            }

            return availabilities;
        }
    }

    public class MemberDtoToDomainAvailResolver : IValueResolver<MemberAdminReadEditDto, MemberProfile, List<Availability>>
    {
        private readonly IMapper _mapper;

        public MemberDtoToDomainAvailResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Availability> Resolve(MemberAdminReadEditDto dto, MemberProfile domain, List<Availability> destMember, ResolutionContext context)
        {
            var availabilities = new List<Availability>();

            foreach (var dayAvailabilities in dto.Availabilities)
            {
                var domainAvailabilities = _mapper.Map<List<Availability>>(dayAvailabilities.Value);
                availabilities.AddRange(domainAvailabilities);
            }

            return availabilities;
        }
    }

    public class MemberDomainToDtoEmailResolver : IValueResolver<MemberProfile, MemberAdminReadEditDto, string>
    {
        public string Resolve(MemberProfile domain, MemberAdminReadEditDto dto, string destMember, ResolutionContext context)
        {
            return domain.User.Email;
        }
    }

    public class MemberDtoToDomainEmailResolver : IValueResolver<MemberAdminReadEditDto, MemberProfile, string>
    {
        public string Resolve(MemberAdminReadEditDto dto, MemberProfile domain, string destMember, ResolutionContext context)
        {
            return dto.Email;
        }
    }
}
