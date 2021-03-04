using HRManager.Common;
using HRManager.Common.Dtos;
using HRManager.Idp.Data;
using HRManager.Idp.Entities;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        Task<ApiResult<object>> RegisterUser(IdentityDto dto);
        Task<ApiResult<object>> UpdateUsername(string newUsername, Guid id);
        Task<ApiResult<object>> ChangePassword(ChangePasswordDto dto);
        Task<ApiResult<object>> RemoveUser(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<UserService> _logger;

        public UserService(
            UserManager<AppUser> userManager,
            ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<ApiResult<object>> ChangePassword(ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            if (dto.OldPassword == dto.NewPassword)
            {
                return new ApiResult<object>
                {
                    Successful = false,
                    Error = "Your new password must be different than your old password."
                };
            }

            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);

            if (result.Succeeded)
            {
                return new ApiResult<object>
                {
                    Successful = true
                };
            }
            else
            {
                string errorString = "";
                foreach (var error in result.Errors)
                {
                    errorString += error.Description;
                }

                _logger.LogError(errorString);

                return new ApiResult<object>
                {
                    Successful = false,
                    Error = errorString
                };
            }
        }

        public async Task<ApiResult<object>> RegisterUser(IdentityDto dto)
        {
            var result = new ApiResult<object>();

            if (dto != null)
            {
                // create user account
                var user = new AppUser
                {
                    Email = dto.Data.Email,
                    // TODO: Add email confirmation
                    EmailConfirmed = true,
                    UserName = dto.Data.Email,
                    MemberId = dto.MemberId
                };

                var identityResult = await _userManager.CreateAsync(user, dto.Data.Password);

                if (identityResult.Succeeded)
                {
                    _logger.LogInformation($"Registration: New user {dto.Data.Password} was successfully created");

                    // add member role to user
                    var roleResult = await _userManager.AddToRoleAsync(user, "Member");

                    if (roleResult.Succeeded)
                    {
                        _logger.LogInformation($"Registration: New user {dto.Data.Email} was added to member role");
                        _logger.LogInformation($"Registration complete for user {dto.Data.Email}");
                        result = new ApiResult<object>
                        {
                            Successful = true
                        };
                    }
                    else
                    {
                        _logger.LogError($"Registration Error: An error occurred when adding role to {dto.Data.Email}:");
                        result = new ApiResult<object>
                        {
                            Error = $"Registration Error: An error occurred when adding role to {dto.Data.Email}:",
                            Successful = false
                        };
                    }
                }
                else
                {
                    _logger.LogError($"An error occured when creating new user {dto.Data.Email}:");
                    string errorString = $"An error occured when creating new user {dto.Data.Email}:\n\n";
                    foreach (var error in identityResult.Errors)
                    {
                        _logger.LogError($"{error.Code}: {error.Description}");
                        errorString += error + ".\n";
                    }
                    result = new ApiResult<object>
                    {
                        Error = errorString,
                        Successful = false
                    };
                }
            }
            else
            {
                result = new ApiResult<object>
                {
                    Error = "Invalid registration data",
                    Successful = false
                };
            }

            // something went wrong, return result
            return result;
        }

        public async Task<ApiResult<object>> RemoveUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                _logger.LogError("No user could be found for that id.");
                return new ApiResult<object>
                {
                    Successful = false,
                    Error = "No user could be found for that id."
                };
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new ApiResult<object>
                {
                    Successful = true
                };
            }
            else
            {
                string errorString = "";
                foreach (var error in result.Errors)
                {
                    errorString += error.Description + " ";
                }

                _logger.LogError(errorString);

                return new ApiResult<object>
                {
                    Successful = false,
                    Error = errorString
                };
            }
        }

        public async Task<ApiResult<object>> UpdateUsername(string newUsername, Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.SetUserNameAsync(user, newUsername);
            if (result.Succeeded)
            {
                return new ApiResult<object>
                {
                    Successful = true
                };
            }
            else
            {
                string errorString = "";
                foreach (var error in result.Errors)
                {
                    errorString += error.Description + " ";
                }

                _logger.LogError(errorString);

                return new ApiResult<object>
                {
                    Successful = false,
                    Error = errorString
                };
            }
        }
    }
}
