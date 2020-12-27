using HRManager.Api.Data;
using HRManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface IPositionService
    {
        Task<ApiResult<List<Position>>> GetPositions();
    }
    public class EFPositionService : IPositionService
    {
        private readonly MainContext _context;
        private readonly ILogger<EFPositionService> _logger;

        public EFPositionService(MainContext context, ILogger<EFPositionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ApiResult<List<Position>>> GetPositions()
        {
            try
            {
                var positions = await _context.Positions.Where(p => p.Name != "All").ToListAsync();
                return new ApiResult<List<Position>> { Dto = positions, Successful = true };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred when trying to fetch positions:\n" + ex.Message, "\n\nStack Trace: " + ex.StackTrace);
                return new ApiResult<List<Position>> { Successful = false, Error = "An error occurred when trying to fetch positions, please try reloading the page." };
            }
        }
    }
}
