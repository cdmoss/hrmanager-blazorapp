using HRManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRManager.Blazor.Services
{
    public interface IDbSeeder
    {
        Task<string> Seed();
    }

    public class DbSeeder : IDbSeeder
    {
        private readonly IHttpClientFactory _httpFactory;

        public DbSeeder(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<string> Seed()
        {
            var apiClient = _httpFactory.CreateClient(Constants.HttpClients.ApiClient);
            var idpClient = _httpFactory.CreateClient(Constants.HttpClients.IdpClient);

            var positionsSeedResponse = await apiClient.GetFromJsonAsync<ApiResult<object>>($"{Constants.ControllerNames.Positions}/{Constants.ControllerEndpoints.Seed}");
            if (!positionsSeedResponse.Successful)
            {
                return "Something went wrong when trying to seed the positions.";
            }

            var membersSeedResponse = await apiClient.GetFromJsonAsync<ApiResult<Dictionary<int, string>>>($"{Constants.ControllerNames.Teams}/{Constants.ControllerEndpoints.Seed}");
            if (!membersSeedResponse.Successful)
            {
                return "Something went wrong when trying to seed the member profies.";
            }

            if (membersSeedResponse.Data != null)
            {
                var idpSeedResponse = await idpClient.PostAsJsonAsync($"{Constants.ControllerNames.User}/{Constants.ControllerEndpoints.Seed}", membersSeedResponse.Data);
                if (!idpSeedResponse.IsSuccessStatusCode)
                {
                    return "Something went wrong when trying to seed the identity accounts.";
                }
            }

            var tsSeedResponse = await apiClient.GetFromJsonAsync<ApiResult<object>>($"{Constants.ControllerNames.Timesheet}/{Constants.ControllerEndpoints.Seed}");
            if (!tsSeedResponse.Successful)
            {
                return "Something went wrong when trying to seed the time entries.";
            }

            return "Database successfully seeded.";
        }
    }
}
