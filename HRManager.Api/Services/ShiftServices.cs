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
        ApiResult<List<ShiftReadEditDto>> GetShifts();
        ApiResult<List<ShiftReadEditDto>> AddShifts(List<ShiftReadEditDto> dto);
        ApiResult<List<ShiftReadEditDto>> UpdateShifts(List<ShiftReadEditDto> dto);
        ApiResult<List<ShiftReadEditDto>> DeleteShifts(List<int> id);
    }

    public class EntityShiftService : IShiftService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EntityShiftService> _logger;

        public EntityShiftService(MainContext context, IMapper mapper, ILogger<EntityShiftService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ApiResult<List<ShiftReadEditDto>> GetShifts()
        {
            try
            {
                var shifts = _context.Shifts.Include(s => s.Member)
                .Include(s => s.Position).ToList();
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

        public ApiResult<List<ShiftReadEditDto>> AddShifts(List<ShiftReadEditDto> dto)
        {
            try
            {
                var member = _mapper.Map<List<Shift>>(dto);
                _context.AddRange(member);
                _context.SaveChanges();
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

            return GetShifts();
        }

        public ApiResult<List<ShiftReadEditDto>> UpdateShifts(List<ShiftReadEditDto> dtos)
        {
            try
            {
                Dictionary<Shift, ShiftReadEditDto> shiftPairs = new Dictionary<Shift, ShiftReadEditDto>();
                foreach (var dto in dtos)
                {
                    shiftPairs.Add(_context.Shifts.FirstOrDefault(s => s.Id == dto.Id), dto);
                }

                foreach (var pair in shiftPairs)
                {
                    UpdateShftProperties(pair.Key, pair.Value);
                }

                _context.SaveChanges();
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

            return GetShifts();
        }

        public ApiResult<List<ShiftReadEditDto>> DeleteShifts(List<int> ids)
        {
            try
            {
                var deletedShifts = _context.Shifts.Where(s => ids.Contains(s.Id)).ToList();
                _context.RemoveRange(deletedShifts);
                _context.SaveChanges();
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

            return GetShifts();
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
