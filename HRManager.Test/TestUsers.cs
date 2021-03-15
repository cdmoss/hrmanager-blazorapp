using AutoMapper;
using HRManager.Common.Dtos;
using HRManager.Idp.Services;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRManager.Test
{
    public class TestUsers : IClassFixture<IdpDbFixture>
    {
        private readonly IdpDbFixture _dbFixture;

        public TestUsers(IdpDbFixture db)
        {
            _dbFixture = db;
        }

        [Fact]
        public void AddUser_ReturnCount()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var userManager = TestHelpers.Identity.CreateUserManager(context);

                var shiftService = new UserService(userManager, new NullLogger<UserService>());

                var dto = new IdentityDto() { MemberId = 15, Data = new AccountCredsData { Email = "newtestuser@email.com", Password = "P@$$W0rd", ConfirmPassword = "P@$$W0rd"} };

                var shiftResult = shiftService.RegisterUser(dto).Result;

                Assert.True(context.Users.Any(u => u.MemberId == 15));
            }
        }

        [Fact]
        public void UpdateUsername_Success()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var userManager = TestHelpers.Identity.CreateUserManager(context);

                var userService = new UserService(userManager, new NullLogger<UserService>());

                Guid id = context.Users.FirstOrDefault().Id;

                var userResult = userService.UpdateUsername("newtestuser@email.com", id).Result;
                Assert.True(userResult.Successful);
                Assert.True(context.Users.FirstOrDefault(u => u.Id == id).UserName == "newtestuser@email.com");
            }
        }

        [Fact]
        public void UpdateUsername_UsernameAlreadyExists()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var userManager = TestHelpers.Identity.CreateUserManager(context);

                var userService = new UserService(userManager, new NullLogger<UserService>());

                Guid id = context.Users.FirstOrDefault().Id;

                var userResult = userService.UpdateUsername("test2@email.com", id).Result;
                Assert.False(userResult.Successful);
            }
        }

        [Fact]
        public void ChangePassword_Success()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var userManager = TestHelpers.Identity.CreateUserManager(context);

                var userService = new UserService(userManager, new NullLogger<UserService>());

                Guid id = context.Users.FirstOrDefault().Id;

                var passwordDto = new ChangePasswordDto { Id = id, OldPassword = "P@$$W0rd", NewPassword = "P@$$W0rd1", ConfirmNewPassword = "P@$$W0rd1" };

                var userResult = userService.ChangePassword(passwordDto).Result;
                Assert.True(userResult.Successful);
            }
        }

        [Fact]
        public void ChangePassword_PasswordAlreadyInUse()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var userManager = TestHelpers.Identity.CreateUserManager(context);

                var userService = new UserService(userManager, new NullLogger<UserService>());

                Guid id = context.Users.FirstOrDefault().Id;

                var passwordDto = new ChangePasswordDto { Id = id, OldPassword = "P@$$W0rd", NewPassword = "P@$$W0rd", ConfirmNewPassword = "P@$$W0rd" };

                var userResult = userService.ChangePassword(passwordDto).Result;
                Assert.False(userResult.Successful);
            }
        }

        [Fact]
        public void RemoveUser_Success()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var userManager = TestHelpers.Identity.CreateUserManager(context);

                var userService = new UserService(userManager, new NullLogger<UserService>());

                Guid id = context.Users.FirstOrDefault().Id;

                var userResult = userService.RemoveUser(id).Result;
                Assert.True(userResult.Successful);
                Assert.False(context.Users.Any(u => u.Id == id));
            }
        }

        [Fact]
        public void RemoveUser_UserNotFound()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var userManager = TestHelpers.Identity.CreateUserManager(context);

                var userService = new UserService(userManager, new NullLogger<UserService>());

                Guid id = new Guid();

                var userResult = userService.RemoveUser(id).Result;
                Assert.False(userResult.Successful);
            }
        }
    }
}
