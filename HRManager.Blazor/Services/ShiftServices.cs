using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Blazor;
using HRManager.Common.Dtos;
using HRManager.Common;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRManager.Blazor.Services
{
    public interface IShiftService
    {
        Task<ApiResult<List<ShiftReadEditDto>>> GetShifts();
        Task<ApiResult<List<ShiftReadEditDto>>> AddShifts(List<ShiftReadEditDto> dto);
        Task<ApiResult<List<ShiftReadEditDto>>> UpdateShifts(List<ShiftReadEditDto> dto);
        Task<ApiResult<List<ShiftReadEditDto>>> DeleteShifts(List<int> ids);
    }

    public class HttpShiftService : IShiftService
    {
        private readonly HttpClient _http;

        public HttpShiftService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> GetShifts()
        {
            return await _http.GetFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>("shifts/all");
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> AddShifts(List<ShiftReadEditDto> dto)
        {
            var response = await _http.PostAsJsonAsync("shifts/add", dto);
            return await response.Content.ReadFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>();
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> UpdateShifts(List<ShiftReadEditDto> dto)
        {
            var response = await _http.PostAsJsonAsync("shifts/update", dto);
            return await response.Content.ReadFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>();
        }

        public async Task<ApiResult<List<ShiftReadEditDto>>> DeleteShifts(List<int> ids)
        {
            var response = await _http.PostAsJsonAsync("shifts/delete", ids);
            return await response.Content.ReadFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>();
        }
    }
}
