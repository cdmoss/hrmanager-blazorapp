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
            CreateMap<MemberProfile, MemberAdminReadEditDto>().ForMember(p => p.Availabilities, opt => opt.Ignore())
                .ReverseMap().ForMember(p => p.Availabilities, opt => opt.Ignore());
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
}
