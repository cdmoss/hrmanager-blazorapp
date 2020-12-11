using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HRManager.Common.Dtos;

namespace HRManager.Blazor.Services
{
    public interface IUserService
    {
        Task<List<MemberAdminReadEditDto>> GetMembers();
    }

    public class HttpUserService : IUserService
    {
        private readonly HttpClient _http;

        public HttpUserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MemberAdminReadEditDto>> GetMembers()
        {
            return await _http.GetFromJsonAsync<List<MemberAdminReadEditDto>>("users/members");
        }

        
    }
}
