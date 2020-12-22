using HRManager.Common;
using HRManager.Common.Dtos;
using AutoMapper;

namespace HRManager.Api.MapperProfiles
{
    public class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<Availability, AvailabilityDto>().ReverseMap();
        }
    }
}
