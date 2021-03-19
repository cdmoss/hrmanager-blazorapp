using AutoMapper;
using HRManager.Common;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.MapperProfiles
{
    public class AlertsProfile : Profile
    {
        public AlertsProfile()
        {
            CreateMap<Alert, AdminAlertListDto>().ReverseMap(); 
            CreateMap<ApplicationAlert, AdminAlertListDto>().ReverseMap();
            CreateMap<ShiftRequestAlert, AdminAlertListDto>().ReverseMap();
        }
    }
}
