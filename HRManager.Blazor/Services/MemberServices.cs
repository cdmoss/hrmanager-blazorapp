using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using HRManager.Common;
using HRManager.Common.Dtos;
using IdentityModel.Client;

namespace HRManager.Blazor.Services
{
    public interface IMemberService
    {
        Task<ApiResult<List<AdminMemberDto>>> GetFullMembers();
        ApiResult<List<MemberMinimalDto>> GetMinimalMembers();
        Task<ApiResult<List<AdminMemberDto>>> UpdateMember(AdminMemberDto dto);
    }

    public class HttpMemberService : IMemberService
    {
        private readonly HttpClient _http;

        public HttpMemberService(IHttpClientFactory httpFactory, TokenProvider tokenProvider)
        {
            _http = httpFactory.CreateClient("ApiClient");
            _http.SetBearerToken(tokenProvider.AccessToken);
        }

        public async Task<ApiResult<List<AdminMemberDto>>> GetFullMembers()
        {
            return await _http.GetFromJsonAsync<ApiResult<List<AdminMemberDto>>>("members/all/full");
        }

        public ApiResult<List<MemberMinimalDto>> GetMinimalMembers()
        {
            return _http.GetFromJsonAsync<ApiResult<List<MemberMinimalDto>>>("members/all/minimal").Result;
        }

        public async Task<ApiResult<List<AdminMemberDto>>> UpdateMember(AdminMemberDto dto)
        {
            var response = await _http.PostAsJsonAsync("members/update-member", dto);
            return await response.Content.ReadFromJsonAsync<ApiResult<List<AdminMemberDto>>>();
        }
    }
}
