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
            CreateMap<MemberProfile, AdminMemberDto>()
                .ForMember(dest => dest.Availabilities, opt => opt.MapFrom<MemberDomainToDtoAvailResolver<AdminMemberDto>>())
                .ReverseMap()
                .ForMember(dest => dest.Availabilities, opt => opt.MapFrom<MemberDtoToDomainAvailResolver<AdminMemberDto>>());
            // source --> target
            CreateMap<MemberProfile, MemberEditDto>()
                .ForMember(dest => dest.Availabilities, opt => opt.MapFrom<MemberDomainToDtoAvailResolver<MemberEditDto>>())
                .ReverseMap()
                .ForMember(dest => dest.Availabilities, opt => opt.MapFrom<MemberDtoToDomainAvailResolver<MemberEditDto>>());

            CreateMap<MemberProfile, MemberMinimalDto>().ReverseMap();

            CreateMap<MemberRegisterDto, MemberProfile>()
                .ForMember(p => p.Availabilities, opt => opt.Ignore())
                .ForMember(p => p.Positions, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(p => p.Availabilities, opt => opt.Ignore())
                .ForMember(p => p.Positions, opt => opt.Ignore());

            CreateMap<MemberProfile, AccountCredsData>().ReverseMap();
            CreateMap<MemberProfile, PersonalAndContactData>().ReverseMap();
            CreateMap<MemberProfile, QualificationsData>().ReverseMap();
            CreateMap<MemberProfile, CertificatesData>().ReverseMap();
        }
    }

    public class MemberDomainToDtoAvailResolver<TDto> : IValueResolver<MemberProfile, TDto, Dictionary<DayOfWeek, List<AvailabilityDto>>> where TDto : MemberEditDto
    {
        public Dictionary<DayOfWeek, List<AvailabilityDto>> Resolve(MemberProfile domain, TDto dto, Dictionary<DayOfWeek, List<AvailabilityDto>> destMember, ResolutionContext context)
        {
            var availabilities = new Dictionary<DayOfWeek, List<AvailabilityDto>>();
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
            {
                availabilities.Add((DayOfWeek)day, new List<AvailabilityDto>());
            }

            if (domain.Availabilities != null)
            {
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
            }

            return availabilities;
        }
    }

    public class MemberDtoToDomainAvailResolver<TDto> : IValueResolver<TDto, MemberProfile, List<Availability>> where TDto : MemberEditDto
    {
        private readonly IMapper _mapper;

        public MemberDtoToDomainAvailResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Availability> Resolve(TDto dto, MemberProfile domain, List<Availability> destMember, ResolutionContext context)
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
}
