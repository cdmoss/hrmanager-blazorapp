using AutoMapper;
using HRManager.Api.Data;
using HRManager.Api.Services;
using HRManager.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HRManager.Test
{
    [Collection("apiDbCollection")]
    public class TestMembers
    {
        private readonly ApiDbFixture _dbFixture;
        private readonly IMapper _mapper;

        public TestMembers(ApiDbFixture dbFixture, IMapper mapper)
        {
            _dbFixture = dbFixture;
            _mapper = mapper;
        }


        [Fact]
        public void GetMembers_ReturnCount()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                
                var memberService = new EFTeamService(_dbFixture.CreateContext(transaction), new NullLogger<EFTeamService>(), _mapper);
                var testMembers = memberService.GetMembers<AdminMemberDto>().Result;

                Assert.True(testMembers.Successful);
                Assert.True(testMembers.Data.Count > 0);
            }
        }

        [Fact]
        public void GetMembers_ReturnErrorOnEmptyDb()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                _dbFixture.ClearDb(context);

                var memberService = new EFTeamService(context, new NullLogger<EFTeamService>(), _mapper);
                var membersResult = memberService.GetMembers<AdminMemberDto>().Result;
                Assert.False(membersResult.Data.Any());
            }
        }

        [Fact]
        public void AddMember_ReturnMember()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var memberService = new EFTeamService(_dbFixture.CreateContext(transaction), new NullLogger<EFTeamService>(), _mapper);

                var registerDto = TestHelpers.Data.GenerateRegisterDto();
                var registerResult = memberService.AddMember(registerDto).Result;
                Assert.True(registerResult.Successful);

                var memberResult = memberService.GetMember<AdminMemberDto>(registerResult.Data).Result;

                Assert.True(memberResult.Successful);
                Assert.True(memberResult.Data != null);
                Assert.True(memberResult.Data.Email == "test@email.com");
                Assert.True(memberResult.Data.FirstName == "testfirst");
            }
        }

        [Fact]
        public void AddMember_ReturnErrorOnEmptyDto()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var memberService = new EFTeamService(_dbFixture.CreateContext(transaction), new NullLogger<EFTeamService>(), _mapper);

                MemberRegisterDto registerDto = null;
                var registerResult = memberService.AddMember(registerDto).Result;
                Assert.False(registerResult.Successful);
            }
        }

        [Fact]
        public void AdminUpdateMember_ReturnMember()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);

                var memberService = new EFTeamService(context, new NullLogger<EFTeamService>(), _mapper);
                int id = context.Members.FirstOrDefault().Id;
                var dto = TestHelpers.Data.GenerateAdminMemberDto(id);

                var updateResult = memberService.UpdateMemberForAdmin(dto).Result;

                Assert.True(updateResult.Successful);

                var members = updateResult.Data;

                Assert.True(members.Exists(m => m.Email == dto.Email));
            }
        }

        [Fact]
        public void MemberUpdate_Member_ReturnMember()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);

                var memberService = new EFTeamService(context, new NullLogger<EFTeamService>(), _mapper);

                int id = context.Members.FirstOrDefault().Id;
                var dto = TestHelpers.Data.GenerateNonAdminMemberDto(id);

                var updateResult = memberService.UpdateMemberForMember(dto).Result;

                Assert.True(updateResult.Successful);

                Assert.True(updateResult.Data.Email == dto.Email);
            }
        }

        [Fact]
        public void Delete_Member()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);

                var memberService = new EFTeamService(context, new NullLogger<EFTeamService>(), _mapper);
                int id = context.Members.FirstOrDefault().Id;

                var deleteResult = memberService.DeleteMember(id).Result;

                Assert.True(deleteResult.Successful);

                Assert.False(context.Members.Any(m => m.Id == id));
            }
        }
    }
}
