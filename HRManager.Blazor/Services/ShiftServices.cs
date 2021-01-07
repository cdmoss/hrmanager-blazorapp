using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Blazor;
using HRManager.Common.Dtos;
using HRManager.Common;
using System.Net.Http;
using System.Net.Http.Json;
using IdentityModel.Client;

namespace HRManager.Blazor.Services
{
    public interface IShiftService
    {
        ApiResult<List<ShiftReadEditDto>> GetShifts();
        ApiResult<List<ShiftReadEditDto>> AddShifts(List<ShiftReadEditDto> dto);
        ApiResult<List<ShiftReadEditDto>> UpdateShifts(List<ShiftReadEditDto> dto);
        ApiResult<List<ShiftReadEditDto>> DeleteShifts(List<int> ids);
    }

    public class HttpShiftService : IShiftService
    {
        private readonly HttpClient _http;

        public HttpShiftService(IHttpClientFactory httpFactory, TokenProvider tokenProvider)
        {
            _http = httpFactory.CreateClient("ApiClient");
            _http.SetBearerToken(tokenProvider.AccessToken);
        }

        public ApiResult<List<ShiftReadEditDto>> GetShifts()
        {
            return _http.GetFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>("shifts/all").Result;
        }

        public ApiResult<List<ShiftReadEditDto>> AddShifts(List<ShiftReadEditDto> dto)
        {
            var response = _http.PostAsJsonAsync("shifts/add", dto).Result;
            return response.Content.ReadFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>().Result;
        }

        public ApiResult<List<ShiftReadEditDto>> UpdateShifts(List<ShiftReadEditDto> dto)
        {
            var response = _http.PostAsJsonAsync("shifts/update", dto).Result;
            return response.Content.ReadFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>().Result;
        }

        public ApiResult<List<ShiftReadEditDto>> DeleteShifts(List<int> ids)
        {
            var response = _http.PostAsJsonAsync("shifts/delete", ids).Result;
            return response.Content.ReadFromJsonAsync<ApiResult<List<ShiftReadEditDto>>>().Result;
        }
    }
}
