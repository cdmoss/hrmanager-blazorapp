using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using HRManager.Common;
using HRManager.Common.Dtos;

namespace HRManager.Blazor.Services
{
    public interface IUserService
    {
        Task<ApiResult<List<TDto>>> GetMembers<TDto>() where TDto : MemberDto;
        Task<ApiResult<List<MemberAdminReadEditDto>>> UpdateMember(MemberAdminReadEditDto dto);
    }

    public class HttpUserService : IUserService
    {
        private readonly HttpClient _http;

        public HttpUserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ApiResult<List<TDto>>> GetMembers<TDto>() where TDto : MemberDto
        {
            return await _http.GetFromJsonAsync<ApiResult<List<TDto>>>("users/members");
        }

        public async Task<ApiResult<List<MemberAdminReadEditDto>>> UpdateMember(MemberAdminReadEditDto dto)
        {
            var response = await _http.PostAsJsonAsync("users/update-member", dto);
            return await response.Content.ReadFromJsonAsync<ApiResult<List<MemberAdminReadEditDto>>>();
        }
    }
}
