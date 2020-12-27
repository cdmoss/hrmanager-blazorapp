using HRManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HRManager.Blazor.Services
{
    public interface IPositionService
    {
        Task<ApiResult<List<Position>>> GetPositions();
    }

    public class HttpPositionService : IPositionService
    {
        private readonly HttpClient _http;

        public HttpPositionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ApiResult<List<Position>>> GetPositions()
        {
            return await _http.GetFromJsonAsync<ApiResult<List<Position>>>("positions/all", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
