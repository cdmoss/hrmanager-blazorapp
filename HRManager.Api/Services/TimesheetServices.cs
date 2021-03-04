using AutoMapper;
using HRManager.Api.Data;
using HRManager.Common;
using HRManager.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Api.Services
{
    public interface ITimesheetService
    {
        Task<ApiResult<List<TimeEntryReadEditDto>>> GetArchivedTimeEntries();
        Task<ApiResult<List<TimeEntryReadEditDto>>> GetCurrentTimeEntries();
        Task<ApiResult<List<TimeEntryReadEditDto>>> PunchClock(TimeEntryCreateDto dto);
        Task<ApiResult<List<TimeEntryReadEditDto>>> AddFullEntry(TimeEntryCreateDto dto);
        Task<ApiResult<List<TimeEntryReadEditDto>>> UpdateEntry(TimeEntryReadEditDto dto);
        Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteEntry(int id);
        Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteEntries(IEnumerable<int> ids);
    }
    public class EFTimeSheetService : ITimesheetService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EFTimeSheetService> _logger;

        public EFTimeSheetService(MainContext context, IMapper mapper, ILogger<EFTimeSheetService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> PunchClock(TimeEntryCreateDto dto)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == dto.MemberId);

            try
            {
                if (dto.EndTime != null)
                {
                    _logger.LogWarning($"An invalid clock in for {member.FirstName} {member.LastName} was blocked from being added to the database.");

                    return new ApiResult<List<TimeEntryReadEditDto>>
                    {
                        Successful = false,
                        Error = "Punch clock entries must not have an end time"
                    };
                }

                var existingEntry = await
                        _context.TimeEntries.FirstOrDefaultAsync(t => t.MemberId == dto.MemberId && t.EndTime == null);

                // if an entry with no end time is found for this member, they must be clocked out
                if (existingEntry != null)
                {
                    existingEntry.EndTime = DateTime.Now;
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"{member.FirstName} {member.LastName} was successfully clocked out.");
                    return await GetCurrentTimeEntries();
                }

                // clock the member in by adding a new entry
                var newEntry = _mapper.Map<TimeEntry>(dto);

                _context.Add(newEntry);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"{member.FirstName} {member.LastName} was successfully clocked in.");
                return await GetCurrentTimeEntries();
            }
            catch (Exception ex)
            {
                //TODO: add inner exceptions to all other catch statements
                _logger.LogError($"Something went wrong when trying to punch clock {member.FirstName} {member.LastName}.\n");
                _logger.LogError($"Error: {ex.Message}");
                _logger.LogError($"Inner Exception: {ex.InnerException}");
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to punch clock {member.FirstName} {member.LastName}.\n"
                };
            }
        }


        public async Task<ApiResult<List<TimeEntryReadEditDto>>> AddFullEntry(TimeEntryCreateDto dto)
        {
            try
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == dto.MemberId);

                // TODO: make sure end time is not null
                if (dto.EndTime == null)
                {
                    _logger.LogWarning($"An invalid time entry for {member.FirstName} {member.LastName} was blocked from being added to the database due to a null end time value");
                    return new ApiResult<List<TimeEntryReadEditDto>>
                    {
                        Successful = false,
                        Error = "The given time entry is missing an end time."
                    };
                }

                var dbEntries = await _context.TimeEntries.ToListAsync();

                var clockedInEntry = dbEntries.FirstOrDefault(t => t.MemberId == dto.MemberId && t.EndTime == null);
                if (clockedInEntry != null)
                {
                    if (dto.EndTime.Value <= clockedInEntry.StartTime)
                    {
                        _logger.LogWarning($"The given time entry for {member.FirstName} {member.LastName} overlapped their current clocked in entry.");
                        return new ApiResult<List<TimeEntryReadEditDto>>
                        {
                            Successful = false,
                            Error = $"The time entry given overlapped {member.FirstName} {member.LastName}'s current clock in"
                        };
                    }
                }

                var position = await _context.Positions.FirstOrDefaultAsync(p => p.Id == dto.PositionId);

                bool overlappingEntry = false;
                foreach (var time in dbEntries.Where(t => t.EndTime != null).OrderByDescending(t => t.Id).ToList())
                {
                    overlappingEntry = CheckIfEntriesOverlap(
                            dto.StartTime,
                            dto.EndTime.Value,
                            time.StartTime,
                            time.EndTime.Value) && dto.MemberId == time.MemberId;

                    if (overlappingEntry)
                    {
                        return new ApiResult<List<TimeEntryReadEditDto>>
                        {
                            Successful = false,
                            Error = "This member already has a time entry clocked for that time range."
                        };
                    }
                }

                var timeEntry = new TimeEntry
                {
                    Position = position,
                    Member = member,
                    StartTime = dto.StartTime,
                    EndTime = dto.EndTime
                };

                _context.Add(timeEntry);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to add a new time entry:\n" + ex.Message + "\n\nStack Trace: " + ex.StackTrace);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = "An error occurred when trying to add a new time entry, please try again."
                };
            }

            if (dto.EndTime == null)
            {
                return await GetCurrentTimeEntries();
            }
            else
            {
                return await GetArchivedTimeEntries();
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> UpdateEntry(TimeEntryReadEditDto dto)
        {
            try
            {
                var entryToUpdate = await _context.TimeEntries.FirstOrDefaultAsync(t => t.Id == dto.Id);

                entryToUpdate.MemberId = dto.MemberId;
                entryToUpdate.PositionId = dto.PositionId;
                entryToUpdate.StartTime = dto.StartTime;
                entryToUpdate.EndTime = dto.EndTime;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to update a time entry:\n\n" + ex.Message);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to update the time entry. Please try to reload the page."
                };
            }

            if (dto.EndTime == null)
            {
                return await GetCurrentTimeEntries();
            }
            else
            {
                return await GetArchivedTimeEntries();
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> GetArchivedTimeEntries()
        {
            try
            {
                var timeEntries = await _context.TimeEntries.Include(s => s.Member)
                .Include(s => s.Position)
                .Where(t => t.EndTime != null).ToListAsync();

                var timeEntryDtos = _mapper.Map<List<TimeEntryReadEditDto>>(timeEntries);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Data = timeEntryDtos,
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to fetch time entries:\n\n" + ex.Message);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to load the time entries. Please try again."
                };
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> GetCurrentTimeEntries()
        {
            try
            {
                var timeEntries = await _context.TimeEntries.Include(s => s.Member)
                    .Include(s => s.Position)
                    .Where(t => t.EndTime == null).ToListAsync();

                var timeEntryDtos = _mapper.Map<List<TimeEntryReadEditDto>>(timeEntries);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Data = timeEntryDtos,
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to fetch time entries:\n\n" + ex.Message);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to load the time entries. Please try again."
                };
            }
        }

        private bool CheckIfEntriesOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            if (start1 <= start2 && end1 <= end2 && end1 >= start2)
            {
                // first timespan begins before second timespan but ends during it
                return true;
            }
            if (start1 <= start2 && end1 >= end2)
            {
                // first timespan full contains second timespan
                return true;
            }
            if (start1 >= start2 && end1 <= end2)
            {
                // first timespan is fully contained by second timespan
                return true;
            }
            if (start1 >= start2 && end1 >= end2 && start1 <= end2)
            {
                // first timespan begins during second timespan
                return true;
            }

            return false;
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteEntry(int id)
        {
            TimeEntry entryToDelete;
            try
            {
                entryToDelete = await _context.TimeEntries.FirstOrDefaultAsync(t => t.Id == id);
                _context.Remove(entryToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to delete a time entry:\n\n" + ex.Message);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to delete the time entry. Please try again."
                };
            }

            if (entryToDelete != null)
            {
                if (entryToDelete.EndTime != null)
                {
                    return await GetArchivedTimeEntries();
                }
            }
            return await GetCurrentTimeEntries();
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteEntries(IEnumerable<int> ids)
        {
            var entriesToDelete = new List<TimeEntry>();

            try
            {
                foreach (var id in ids)
                {
                     entriesToDelete.Add(await _context.TimeEntries.FirstOrDefaultAsync(t => t.Id == id));
                }

                _context.RemoveRange(entriesToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when trying to delete a group of time entries:\n\n" + ex.Message);

                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to delete the time entries. Please try again."
                };
            }
            if (entriesToDelete.Any())
            {
                if (entriesToDelete.FirstOrDefault().EndTime != null)
                {
                    return await GetArchivedTimeEntries();
                }
            }

            return await GetArchivedTimeEntries();
        }
    }
}