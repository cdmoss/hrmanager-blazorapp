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

namespace HRManager.Blazor.Services
{

    public interface IRegistrationService
    {
        Task<RegisterResult> Register(MemberRegisterDto dto);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly IHttpClientFactory _httpFactory;

        public RegistrationService(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<RegisterResult> Register(MemberRegisterDto dto)
        {
            string avail = JsonSerializer.Serialize(dto.Availabilities, new JsonSerializerOptions() { WriteIndented = true});
            string dtoString = JsonSerializer.Serialize(dto, new JsonSerializerOptions() { WriteIndented = true });

            var idpClient = _httpFactory.CreateClient("IdpClient");

            var response = await idpClient.PostAsJsonAsync("auth/register", dto, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });



            return await response.Content.ReadFromJsonAsync<RegisterResult>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
