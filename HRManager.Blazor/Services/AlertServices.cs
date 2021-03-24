using HRManager.Common;
using HRManager.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace HRManager.Blazor.Services
{
    public interface IAlertService
    {
        Task<ApiResult<List<AdminAlertListDto>>> GetAdminAlerts();
        Task<ApiResult<List<AdminAlertListDto>>> UpdateAlert(AdminAlertListDto dto);
    }

    public class HttpAlertService : IAlertService
    {
        private readonly HttpClient _http;

        public HttpAlertService(IHttpClientFactory factory, TokenProvider tokenProvider)
        {
            _http = factory.CreateClient("ApiClient");
            _http.SetBearerToken(tokenProvider.AccessToken);
        }

        public async Task<ApiResult<List<AdminAlertListDto>>> GetAdminAlerts()
        {
            try
            {
                return await _http.GetFromJsonAsync<ApiResult<List<AdminAlertListDto>>>("alerts/admin");
            }
            catch (Exception ex)
            {
                return new ApiResult<List<AdminAlertListDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to communicate with the server."
                };
            }
        }

        public async Task<ApiResult<List<AdminAlertListDto>>> UpdateAlert(AdminAlertListDto dto)
        {
            var response = await _http.PostAsJsonAsync("alerts/admin-update", dto);
            if (!response.IsSuccessStatusCode)
            {
                return new ApiResult<List<AdminAlertListDto>>
                {
                    Successful = false,
                    Error = "Something went wrong when trying to communicate with the server."
                };
            }

            return await response.Content.ReadFromJsonAsync<ApiResult<List<AdminAlertListDto>>>();
        }
    }
}
