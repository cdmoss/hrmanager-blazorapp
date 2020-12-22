using HRManager.Common.Auth;
using HRManager.Common.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace HRManager.Blazor.Services
{

    public interface IAuthService
    {
        Task<RegisterResult> Register(MemberRegisterDto dto);
        Task<LoginResult> Login(LoginDto dto);
        Task Logout();
        Task<string> ValidateUsername(string username);
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResult> Login(LoginDto dto)
        {  
            var response = await _http.PostAsJsonAsync("auth/login", dto);
            var stringContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResult>(stringContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return result;
            }

            await _localStorage.SetItemAsync("authToken", result.Token);
            ((TokenAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(result.Token);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

            return result;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((TokenAuthenticationStateProvider)_authStateProvider).NotifyUserLogout();
            _http.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResult> Register(MemberRegisterDto dto)
        {
            string avail = JsonSerializer.Serialize(dto.Availabilities, new JsonSerializerOptions() { WriteIndented = true});
            string dtoString = JsonSerializer.Serialize(dto, new JsonSerializerOptions() { WriteIndented = true });
            

            var response = await _http.PostAsJsonAsync("auth/register", dto, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return await response.Content.ReadFromJsonAsync<RegisterResult>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<string> ValidateUsername(string username) 
        {
            var response = await _http.GetAsync($"auth/validate-username/{username}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
