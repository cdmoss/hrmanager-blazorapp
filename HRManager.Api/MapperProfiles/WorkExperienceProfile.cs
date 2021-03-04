using AutoMapper;
using HRManager.Common;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.MapperProfiles
{
    public class WorkExperienceProfile : Profile
    {
        public WorkExperienceProfile()
        {
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
        }
    }
}
