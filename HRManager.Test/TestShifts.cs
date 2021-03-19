using AutoMapper;
using HRManager.Api.Data;
using HRManager.Api.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRManager.Test
{
    [Collection("apiDbCollection")]
    public class TestShifts
    {
        private readonly ApiDbFixture _dbFixture;
        private readonly IMapper _mapper;

        public TestShifts(ApiDbFixture db, IMapper mapper)
        {
            _dbFixture = db;
            _mapper = mapper;
        }

        [Fact]
        public void GetShifts_ReturnCount()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var shiftService = new EFShiftService(_dbFixture.CreateContext(transaction), _mapper, new NullLogger<EFShiftService>());

                var shiftResult = shiftService.GetShifts().Result;
                Assert.True(shiftResult.Successful);
                Assert.True(shiftResult.Data.Count() > 0);
            }
        }

        // TODO: make test more comprehensive
        [Fact]
        public void AddShift_ReturnShift()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                int count = context.Shifts.ToList().Count();
                var shiftService = new EFShiftService(context, _mapper, new NullLogger<EFShiftService>());
                var shiftResult = shiftService.AddShifts(TestHelpers.Data.GenerateShiftDto(context)).Result;
                Assert.True(shiftResult.Successful);
                Assert.Equal(count + 5, context.Shifts.Count());
            }
        }

        [Fact]
        public void UpdateShift_ReturnShift()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                var dto = TestHelpers.Data.GenerateShiftDtoForUpdate(context);
                var shiftService = new EFShiftService(context, _mapper, new NullLogger<EFShiftService>());
                var shiftResult = shiftService.UpdateShifts(new List<Common.Dtos.ShiftReadEditDto> { dto }).Result;
                Assert.True(shiftResult.Successful);
                var updatedShift = context.Shifts.FirstOrDefault(s => s.Id == dto.Id);
                Assert.Equal(new DateTime(1, 1, 1, 5, 0, 0), updatedShift.StartTime);
                Assert.Equal(new DateTime(1, 1, 1, 15, 0, 0), updatedShift.EndTime);
            }
        }

        [Fact]
        public void DeleteShifts_Successful()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var context = _dbFixture.CreateContext(transaction);
                int count = context.Shifts.Count();
                List<int> ids = context.Shifts.Take(5).Select(s => s.Id).ToList();

                var shiftService = new EFShiftService(context, _mapper, new NullLogger<EFShiftService>());
                var result = shiftService.DeleteShifts(ids).Result;

                Assert.True(result.Successful);
                Assert.Equal(count - 5, context.Shifts.Count());
            }
        }  
    }
}
