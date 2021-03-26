using HRManager.Common;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRManager.Blazor.Services
{
    public interface ITimesheetService
    {
        Task<ApiResult<List<TimeEntryReadEditDto>>> GetArchivedTimeEntries();
        Task<ApiResult<List<TimeEntryReadEditDto>>> GetCurrentTimeEntries();
        Task<ApiResult<List<TimeEntryReadEditDto>>> PunchClock(TimeEntryCreateDto timeEntry);
        Task<ApiResult<List<TimeEntryReadEditDto>>> AddTimeEntry(TimeEntryCreateDto timeEntry);
        Task<ApiResult<List<TimeEntryReadEditDto>>> UpdateTimeEntry(TimeEntryReadEditDto timeEntry);
        Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteTimeEntry(int timeEntryId);
        Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteTimeEntries(List<int> timeEntryId);
    }
    public class HttpTimesheetService : ITimesheetService
    {
        private readonly HttpClient _http;

        public HttpTimesheetService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient(Constants.HttpClients.ApiClient);
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> AddTimeEntry(TimeEntryCreateDto dto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.AddFullEntry}", dto);
                return response.Content.ReadFromJsonAsync<ApiResult<List<TimeEntryReadEditDto>>>().Result;
            }
            catch (Exception ex)
            {
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to add a time entry:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteTimeEntries(List<int> timeEntryIds)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.DeleteMultiple}", timeEntryIds);
                return response.Content.ReadFromJsonAsync<ApiResult<List<TimeEntryReadEditDto>>>().Result;
            }
            catch (Exception ex)
            {
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to delete time entries:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> DeleteTimeEntry(int timeEntryId)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.Delete}", timeEntryId);
                return response.Content.ReadFromJsonAsync<ApiResult<List<TimeEntryReadEditDto>>>().Result;
            }
            catch (Exception ex)
            {
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to delete a time entry:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> GetArchivedTimeEntries()
        {
            try
            {
                return await _http.GetFromJsonAsync<ApiResult<List<TimeEntryReadEditDto>>>($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.GetArchived}");
            }
            catch (Exception ex)
            {
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to get archived time entries:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> GetCurrentTimeEntries()
        {
            try
            {
                return await _http.GetFromJsonAsync<ApiResult<List<TimeEntryReadEditDto>>>($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.GetCurrent}");
            }
            catch (Exception ex)
            {
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to get current time entries:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> PunchClock(TimeEntryCreateDto timeEntry)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.Punch}", timeEntry);
                return response.Content.ReadFromJsonAsync<ApiResult<List<TimeEntryReadEditDto>>>().Result;
            }
            catch (Exception ex)
            {
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to punch the time clock:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }

        public async Task<ApiResult<List<TimeEntryReadEditDto>>> UpdateTimeEntry(TimeEntryReadEditDto timeEntry)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.Update}", timeEntry);
                return response.Content.ReadFromJsonAsync<ApiResult<List<TimeEntryReadEditDto>>>().Result;
            }
            catch (Exception ex)
            {
                return new ApiResult<List<TimeEntryReadEditDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to update a time entry:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }
    }
}
