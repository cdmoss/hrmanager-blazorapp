using HRManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRManager.Blazor.Services
{
    public class PositionsService
    {
        private readonly HttpClient _http;

        public PositionsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Position>> GetPositions()
        {
            return await _http.GetFromJsonAsync<List<Position>>("positions/all");
        }
    }
}
