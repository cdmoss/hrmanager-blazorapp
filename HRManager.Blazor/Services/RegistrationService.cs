using HRManager.Common.Auth;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using HRManager.Common;
using Microsoft.Extensions.Logging;

namespace HRManager.Blazor.Services
{

    public interface IRegistrationService
    {
        Task<bool> Register(MemberRegisterDto dto);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly ILogger<RegistrationService> _logger;

        public RegistrationService(IHttpClientFactory httpFactory, ILogger<RegistrationService> logger)
        {
            _httpFactory = httpFactory;
            _logger = logger;
        }

        public async Task<bool> Register(MemberRegisterDto dto)
        {
            var apiClient = _httpFactory.CreateClient(Constants.HttpClients.ApiClient);

            // send request to create member
            var memberResponse = await apiClient.PostAsJsonAsync($"{Constants.ControllerNames.Teams}/{Constants.ControllerEndpoints.Register}", dto, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // log error and return false if request returns bad statuscode
            if (!memberResponse.IsSuccessStatusCode)
            {
                var stringContent = await memberResponse.Content.ReadAsStringAsync();
                _logger.LogError(stringContent);
                return false;
            }

            var memberResult = await memberResponse.Content.ReadFromJsonAsync<ApiResult<int>>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // if member creation is successful, send returned member id, username and password to idp to request identity account creation
            if (memberResult.Successful)
            {
                var idpClient = _httpFactory.CreateClient(Constants.HttpClients.IdpClient);

                var identityDto = new IdentityDto { MemberId = memberResult.Data, Data = dto.Account };

                var idpResponse = await idpClient.PostAsJsonAsync($"{Constants.ControllerNames.User}/{Constants.ControllerEndpoints.Register}", identityDto, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // log error and return false if request returns bad statuscode
                if (!idpResponse.IsSuccessStatusCode)
                {
                    var stringContent = await idpResponse.Content.ReadAsStringAsync();
                    _logger.LogError(stringContent);

                    var successCodeDeleteResponse = await idpClient.PostAsJsonAsync($"{Constants.ControllerNames.Teams}/{Constants.ControllerEndpoints.Delete}", memberResult.Data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (!successCodeDeleteResponse.IsSuccessStatusCode)
                    {
                        stringContent = await memberResponse.Content.ReadAsStringAsync();
                        _logger.LogError(stringContent);
                        return false;
                    }

                    return false;
                }

                var idpResult = await idpResponse.Content.ReadFromJsonAsync<ApiResult<object>>();

                if (idpResult.Successful)
                {
                    return true;
                }

                // log error and return false if identity account creation wasn't successful
                _logger.LogError(idpResult.Error);
                var apiResultDeleteResponse = await idpClient.PostAsJsonAsync($"{Constants.ControllerNames.Teams}/{Constants.ControllerEndpoints.Delete}", memberResult.Data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (!apiResultDeleteResponse.IsSuccessStatusCode)
                {
                    var stringContent = await memberResponse.Content.ReadAsStringAsync();
                    _logger.LogError(stringContent);
                    return false;
                }

                return false;
            }

            // log error and return false if member profile creation wasn't successful
            _logger.LogError(memberResult.Error);
            return false;
        }
    }
}
