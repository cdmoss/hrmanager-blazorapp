using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HRManager.Api.Services;
using Microsoft.Extensions.Logging.Abstractions;
using HRManager.Common.Dtos;

namespace HRManager.Test
{
    [Collection("apiDbCollection")]
    public class TestTimesheets
    {
        private readonly ApiDbFixture _db;
        private readonly IMapper _mapper;

        public TestTimesheets(ApiDbFixture db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // TODO: test both archived and current methods
        [Fact]
        public void GetTimeEntries_Success()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var result = tsService.GetArchivedTimeEntries().Result;

                Assert.True(result.Successful);
                Assert.True(result.Data.Count > 0);
            }
        }

        [Fact]
        public void PunchClock_ClockIn()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now
                };

                var result = tsService.PunchClock(createDto).Result;

                Assert.True(result.Successful);
                Assert.True(context.TimeEntries.OrderBy(t => t.Id).LastOrDefault().EndTime == null);
            }
        }

        [Fact]
        public void PunchClock_ClockOut()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var clockInDto = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now
                };

                var clockInResult = tsService.PunchClock(clockInDto).Result;

                Assert.True(clockInResult.Successful);
                Assert.True(context.TimeEntries.OrderBy(t => t.Id).LastOrDefault().EndTime == null);

                var clockOutDto = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now
                };

                var clockOutResult = tsService.PunchClock(clockOutDto).Result;

                Assert.True(clockOutResult.Successful);
                Assert.True(
                    context.TimeEntries.OrderBy(t => t.Id).LastOrDefault().StartTime == clockInDto.StartTime &&
                    context.TimeEntries.OrderBy(t => t.Id).LastOrDefault().EndTime != null);
            }
        }

        [Fact]
        public void PunchClock_InvalidEntry()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var clockInDto = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                };

                var clockOutResult = tsService.PunchClock(clockInDto).Result;

                Assert.False(clockOutResult.Successful);
            }
        }

        [Fact]
        public void AddTimeEntry_Success()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                int initNumEntries = context.TimeEntries.Count();
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now + new TimeSpan(4, 0, 0)
                };

                var result = tsService.AddFullEntry(createDto).Result;

                Assert.True(result.Successful);
                Assert.True(result.Data.Count > initNumEntries);
            }
        }

        [Fact]
        public void AddTimeEntry_EntryMissingEndTime()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                };

                var result = tsService.AddFullEntry(createDto).Result;

                Assert.False(result.Successful);
            }
        }

        [Fact]
        public void AddTimeEntry_OverlappingEntry1()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto1 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now + new TimeSpan(4, 0, 0)
                };

                var result = tsService.AddFullEntry(createDto1).Result;
                Assert.True(result.Successful);

                result = tsService.AddFullEntry(createDto1).Result;
                Assert.False(result.Successful);
            }
        }

        [Fact]
        public void AddTimeEntry_OverlappingEntry2()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto1 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now + new TimeSpan(4, 0, 0)
                };

                var createDto2 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now + new TimeSpan(2, 0, 0),
                    EndTime = DateTime.Now + new TimeSpan(6, 0, 0)
                };

                var result = tsService.AddFullEntry(createDto1).Result;
                Assert.True(result.Successful);

                result = tsService.AddFullEntry(createDto2).Result;
                Assert.False(result.Successful);
            }
        }

        [Fact]
        public void AddTimeEntry_OverlappingEntry3()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto1 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now + new TimeSpan(4, 0, 0)
                };

                var createDto2 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now + new TimeSpan(1, 0, 0),
                    EndTime = DateTime.Now + new TimeSpan(3, 0, 0)
                };

                var result = tsService.AddFullEntry(createDto1).Result;
                Assert.True(result.Successful);

                result = tsService.AddFullEntry(createDto2).Result;
                Assert.False(result.Successful);
            }
        }

        [Fact]
        public void AddTimeEntry_OverlappingEntry4()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto1 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now + new TimeSpan(4, 0, 0)
                };

                var createDto2 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now - new TimeSpan(1, 0, 0),
                    EndTime = DateTime.Now + new TimeSpan(5, 0, 0)
                };

                var result = tsService.AddFullEntry(createDto1).Result;
                Assert.True(result.Successful);

                result = tsService.AddFullEntry(createDto2).Result;
                Assert.False(result.Successful);
            }
        }

        [Fact]
        public void AddTimeEntry_OverlappingEntry5()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var createDto1 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now + new TimeSpan(4, 0, 0)
                };

                var createDto2 = new TimeEntryCreateDto
                {
                    MemberId = context.Members.FirstOrDefault().Id,
                    PositionId = context.Positions.FirstOrDefault().Id,
                    StartTime = DateTime.Now - new TimeSpan(1, 0, 0),
                    EndTime = DateTime.Now + new TimeSpan(3, 0, 0)
                };

                var result = tsService.AddFullEntry(createDto1).Result;
                Assert.True(result.Successful);

                result = tsService.AddFullEntry(createDto2).Result;
                Assert.False(result.Successful);
            }
        }

        [Fact]
        public void UpdateTimeEntry_Success()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                int idOfUpdatedEntry = context.TimeEntries.FirstOrDefault().Id;

                var newStartTime = DateTime.Now;
                var newEndTime = DateTime.Now + new TimeSpan(3, 0, 0);
                var newMemberId = context.Members.FirstOrDefault().Id + 1;
                var newPositionId = context.Positions.FirstOrDefault().Id + 1;

                var dto = new TimeEntryReadEditDto
                {
                    Id = idOfUpdatedEntry,
                    MemberId = newMemberId,
                    PositionId = newPositionId,
                    StartTime = newStartTime,
                    EndTime = newEndTime
                };

                var result = tsService.UpdateEntry(dto).Result;
                Assert.True(result.Successful);
                Assert.True(context.TimeEntries.FirstOrDefault().StartTime == newStartTime);
                Assert.True(context.TimeEntries.FirstOrDefault().EndTime == newEndTime);
                Assert.True(context.TimeEntries.FirstOrDefault().MemberId == newMemberId);
                Assert.True(context.TimeEntries.FirstOrDefault().PositionId == newPositionId);
            }
        }

        [Fact]
        public void DeleteTimeEntry_Single_Success()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                int initNumEntries = context.TimeEntries.Count();

                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                int idOfDeletedEntry = context.TimeEntries.FirstOrDefault().Id;

                var result = tsService.DeleteEntry(idOfDeletedEntry).Result;
                Assert.True(result.Successful);
                Assert.Equal(initNumEntries - 1, context.TimeEntries.Count());
            }
        }

        [Fact]
        public void DeleteTimeEntry_Multiple_Success()
        {
            using (var transaction = _db.Connection.BeginTransaction())
            {
                var context = _db.CreateContext(transaction);
                int initNumEntries = context.TimeEntries.Count();

                var tsService = new EFTimeSheetService(context, _mapper, new NullLogger<EFTimeSheetService>());

                var idsOfDeletedEntry = context.TimeEntries.Take(3).Select(t => t.Id);

                var result = tsService.DeleteEntries(idsOfDeletedEntry).Result;
                Assert.True(result.Successful);
                Assert.Equal(initNumEntries - 3, context.TimeEntries.Count());
            }
        }
    }
}
