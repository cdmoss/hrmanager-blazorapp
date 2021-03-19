using AutoMapper;
using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface IAlertService
    {
        ApiResult<List<AdminAlertListDto>> GetAdminAlerts();
        Task<ApiResult<List<AdminAlertListDto>>> UpdateAlert(AdminAlertListDto dto);
    }
    public class EFAlertService : IAlertService
    {
        private readonly MainContext _context;
        private readonly ILogger<EFAlertService> _logger;
        private readonly IMapper _mapper;

        public EFAlertService(MainContext context, ILogger<EFAlertService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public ApiResult<List<AdminAlertListDto>> GetAdminAlerts()
        {
            try
            {
                var alertDtos = _mapper.Map<List<AdminAlertListDto>>(_context.ApplicationAlerts.ToList());
                return new ApiResult<List<AdminAlertListDto>>
                {
                    Data = alertDtos,
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to retrieve alerts from the database:\n" + ex.Message);
                return new ApiResult<List<AdminAlertListDto>>
                {
                    Successful = false,
                    Error = "An error occured when trying to retrieve alerts from the database."
                };
            }
        }

        public Task<ApiResult<List<AdminAlertListDto>>> UpdateAlert(AdminAlertListDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
