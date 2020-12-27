using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRManager.Api.Services
{
    public interface IShiftService
    {
        Task<ApiResult<List<ShiftReadEditDto>>> GetShifts();
        Task<ApiResult<List<ShiftReadEditDto>>> AddShifts(List<ShiftReadEditDto> dto);
        Task<ApiResult<List<ShiftReadEditDto>>> UpdateShifts(List<ShiftReadEditDto> dto);
        Task<ApiResult<List<ShiftReadEditDto>>> DeleteShifts(List<int> id);
    }

    public class EFShiftService : IShiftService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EFShiftService> _logger;

        public EFShiftService(MainContext context, IMapper mapper, ILogger<EFShiftService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> GetShifts()
        {
            try
            {
                var shifts = await _context.Shifts.Include(s => s.Member)
                .Include(s => s.Position).ToListAsync();
                var shiftDtos = _mapper.Map<List<ShiftReadEditDto>>(shifts);

                return new ApiResult<List<ShiftReadEditDto>>
                {
                    Dto = shiftDtos,
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to fetch member information:\n\n" + ex.Message);

                return new ApiResult<List<ShiftReadEditDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to load the shifts. Please try to reload the page."
                };
            }
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> AddShifts(List<ShiftReadEditDto> dtos)
        {
            try
            {
                var shifts = _mapper.Map<List<Shift>>(dtos);
                _context.AddRange(shifts);

                shifts.ForEach(async s =>
                {
                    var position = await _context.Positions.FirstOrDefaultAsync(p => p.Id == s.PositionId);
                    var member = _context.Members.FirstOrDefault(m => m.Id == s.MemberProfileId);
                    s.Subject = position.Name + " - " + member.FirstName + " " + member.LastName;
                    s.Position = position;
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to add a new shift:\n" + ex.Message + "\n\nStack Trace: " + ex.StackTrace);

                return new ApiResult<List<ShiftReadEditDto>>
                {
                    Successful = false,
                    Error = "An error occurred when trying to add a new shift, please try again."
                };
            }

            return await GetShifts();
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> UpdateShifts(List<ShiftReadEditDto> dtos)
        {
            try
            {
                Dictionary<Shift, ShiftReadEditDto> shiftPairs = new Dictionary<Shift, ShiftReadEditDto>();
                foreach (var dto in dtos)
                {
                    // load subject and position into each dto
                    var position = await _context.Positions.FirstOrDefaultAsync(p => p.Id == dto.PositionId);
                    var member = _context.Members.FirstOrDefault(m => m.Id == dto.MemberProfileId);
                    dto.Subject = position.Name + " - " + member.FirstName + " " + member.LastName;
                    dto.Position = position;

                    shiftPairs.Add(await _context.Shifts.FirstOrDefaultAsync(s => s.Id == dto.Id), dto);
                }

                foreach (var pair in shiftPairs)
                {
                    UpdateShftProperties(pair.Key, pair.Value);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred when trying to update a shift:\n" + ex.Message + "\n\n" + ex.StackTrace);

                return new ApiResult<List<ShiftReadEditDto>>
                {
                    Successful = false,
                    Error = "An error occurred when trying to update a shift, please try again."
                };
            }

            return await GetShifts();
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> DeleteShifts(List<int> ids)
        {
            try
            {
                var deletedShifts = await _context.Shifts.Where(s => ids.Contains(s.Id)).ToListAsync();
                _context.RemoveRange(deletedShifts);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred when trying to delete a shift:\n" + ex.Message + "\n\n" + ex.StackTrace);

                return new ApiResult<List<ShiftReadEditDto>>
                {
                    Successful = false,
                    Error = "An error occurred when trying to delete a shift, please try again."
                };
            }

            return await GetShifts();
        }

        private void UpdateShftProperties(Shift shift, ShiftReadEditDto dto)
        {
            shift.StartTime = dto.StartTime;
            shift.EndTime = dto.EndTime;
            shift.MemberProfileId = dto.MemberProfileId;
            shift.PositionId = dto.PositionId;
            shift.IsRecurrence = dto.IsRecurrence;
            shift.RecurrenceID = dto.RecurrenceID;
            shift.RecurrenceException = dto.RecurrenceException;
            shift.RecurrenceRule = dto.RecurrenceRule;
            shift.Subject = dto.Subject;
            shift.Description = dto.Description;
            shift.IsAllDay = dto.IsAllDay;
            shift.IsBlock = dto.IsBlock;
        }
    }
}
