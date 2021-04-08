using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HRManager.Common;
using HRManager.Common.Dtos;
using IdentityModel.Client;

namespace HRManager.Blazor.Services
{
    public interface ITeamService
    {
        Task<ApiResult<List<AdminMemberDto>>> GetFullMembers();
        ApiResult<List<MemberMinimalDto>> GetMinimalMembers();
        Task<ApiResult<List<AdminMemberDto>>> UpdateMember(AdminMemberDto dto);
        Task<ApiResult<MemberEditDto>> GetMember(int id);
    }

    public class HttpTeamService : ITeamService
    {
        private readonly HttpClient _apiClient;
        private readonly HttpClient _idpClient;

        public HttpTeamService(IHttpClientFactory httpFactory, TokenProvider tokenProvider)
        {
            _apiClient = httpFactory.CreateClient(Constants.HttpClients.ApiClient);
            _idpClient = httpFactory.CreateClient(Constants.HttpClients.IdpClient);
            _apiClient.SetBearerToken(tokenProvider.AccessToken);
        }

        public async Task<ApiResult<List<AdminMemberDto>>> GetFullMembers()
        {
            try
            {
                var apiResult = await _apiClient.GetFromJsonAsync<ApiResult<List<AdminMemberDto>>>($"{Constants.ControllerNames.Teams}/{Constants.Routes.FullTeam}");

                return apiResult;
            }
            catch (Exception ex)
            {
                return new ApiResult<List<AdminMemberDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to retrieve member information:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }
        }

        public ApiResult<List<MemberMinimalDto>> GetMinimalMembers()
        {
            try
            {
                var apiResult = _apiClient.GetFromJsonAsync<ApiResult<List<MemberMinimalDto>>>($"{Constants.ControllerNames.Teams}/{Constants.Routes.MinimalTeam}").Result;
                return apiResult;
            }
            catch (Exception ex)
            {
                return new ApiResult<List<MemberMinimalDto>>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to retrieve member information:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }

        }

        public async Task<ApiResult<MemberEditDto>> GetMember(int id)
        {
            try
            {
                var apiResult = await _apiClient.GetFromJsonAsync<ApiResult<MemberEditDto>>($"{Constants.ControllerNames.Teams}/{id}");
                return apiResult;
            }
            catch (Exception ex)
            {
                return new ApiResult<MemberEditDto>
                {
                    Successful = false,
                    Error = $"Something went wrong when trying to retrieve member information:\n\n{ex.Message}\n{ex.StackTrace}"
                };
            }

            
        }

        public async Task<ApiResult<List<AdminMemberDto>>> UpdateMember(AdminMemberDto dto)
        {
            var response = await _idpClient.PostAsJsonAsync($"{Constants.ControllerNames.Teams}/{Constants.Routes.Update}", dto);

            response = await _apiClient.PostAsJsonAsync($"{Constants.ControllerNames.Teams}/{Constants.Routes.Update}", dto);
            return await response.Content.ReadFromJsonAsync<ApiResult<List<AdminMemberDto>>>();
        }
    }
}
