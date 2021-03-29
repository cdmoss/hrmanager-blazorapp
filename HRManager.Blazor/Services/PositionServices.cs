using HRManager.Common;
using IdentityModel.Client;
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
        ApiResult<List<Position>> GetPositions();
    }

    public class HttpPositionService : IPositionService
    {
        private readonly HttpClient _http;

        public HttpPositionService(IHttpClientFactory httpFactory, TokenProvider tokenProvider)
        {
            _http = httpFactory.CreateClient(Constants.HttpClients.ApiClient);
            _http.SetBearerToken(tokenProvider.AccessToken);
        }

        public ApiResult<List<Position>> GetPositions()
        {
            return _http.GetFromJsonAsync<ApiResult<List<Position>>>($"{Constants.ControllerNames.Positions}/{Constants.ControllerEndpoints.All}", new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).Result;
        }
    }
}
