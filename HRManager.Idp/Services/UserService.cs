using HRManager.Common;
using HRManager.Common.Dtos;
using HRManager.Idp.Data;
using HRManager.Idp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRManager.Idp.Services
{
    public interface IUserService
    {
        Task<ApiResult<object>> RegisterUser(MemberRegisterDto dto);
        Task<ApiResult<object>> RemoveUser(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly IdentityContext _context;
        private readonly HttpClient _http;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ILogger<UserService> _logger;
        public UserService(
            IdentityContext context, 
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IHttpClientFactory httpFactory,
            ILogger<UserService> logger)
        {
            _context = context;
            _http = httpFactory.CreateClient("ApiClient");
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<ApiResult<object>> RegisterUser(MemberRegisterDto dto)
        {
            if (dto != null)
            {
                var user = new AppUser
                {
                    Email = dto.Account.Email,
                    // TODO: Add email confirmation
                    EmailConfirmed = true,
                    UserName = dto.Account.Email
                };

                var identityResult = await _userManager.CreateAsync(user, dto.Account.Password);

                if (identityResult.Succeeded)
                {
                    _logger.LogInformation($"New user {dto.Personal.FirstName} {dto.Personal.LastName} was successfully created");

                    dto.Account.Password = null;
                    var response = await _http.PostAsJsonAsync("members/register", dto);

                    if (response.IsSuccessStatusCode)
                    {
                        var memberResult = await response.Content.ReadFromJsonAsync<ApiResult<object>>();
                        if (memberResult.Successful)
                        {
                            _logger.LogInformation($"New member profile created for {dto.Personal.FirstName} {dto.Personal.LastName}");
                            return memberResult;
                        }
                        else
                        {
                            _logger.LogError($"An error occurred when creating a member profile for {dto.Personal.FirstName} {dto.Personal.LastName}:");
                            _logger.LogError($"{memberResult.Error}");
                            return memberResult;
                        }
                    }
                    else
                    {
                        _logger.LogError($"Api return unsuccessful status code {response.StatusCode} when creating member profile {dto.Personal.FirstName} {dto.Personal.LastName}");
                        return new ApiResult<object>
                        {
                            Error = "Api return unsuccessful status code {response.StatusCode} when creating member profile {dto.Personal.FirstName} {dto.Personal.LastName}",
                            Successful = false
                        };
                    }
                }
                else
                {
                    _logger.LogError($"An error occured when creating new user {dto.Personal.FirstName} {dto.Personal.LastName}:");
                    string errorString = "An error occured when creating new user {dto.Personal.FirstName} {dto.Personal.LastName}:\n\n";
                    foreach (var error in identityResult.Errors)
                    {
                        _logger.LogError($"{error.Code}: {error.Description}");
                        errorString += error + ".\n";
                    }


                    return new ApiResult<object>
                    {
                        Error = errorString,
                        Successful = false
                    };
                }
            }
            else
            {
                return new ApiResult<object>
                {
                    Error = "Invalid registration data",
                    Successful = false
                };
            }
        }

        public Task<ApiResult<object>> RemoveUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
