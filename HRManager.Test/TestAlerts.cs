using AutoMapper;
using HRManager.Api.Services;
using HRManager.Common.Dtos;
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
    public class TestAlerts
    {
        private readonly ApiDbFixture _dbFixture;
        private readonly IMapper _mapper;

        public TestAlerts(ApiDbFixture dbFixture, IMapper mapper)
        {
            _dbFixture = dbFixture;
            _mapper = mapper;
        }


        [Fact]
        public void GetMembers_ReturnCount()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var alertService = new EFAlertService(_dbFixture.CreateContext(transaction), new NullLogger<EFAlertService>(), _mapper);
                var alerts = alertService.GetAdminAlerts();

                Assert.True(alerts.Successful);
                Assert.True(alerts.Data.Count > 0);
            }
        }

        [Fact]
        public void UpdateAlert_Success()
        {
            using (var transaction = _dbFixture.Connection.BeginTransaction())
            {
                var alertService = new EFAlertService(_dbFixture.CreateContext(transaction), new NullLogger<EFAlertService>(), _mapper);
                var alerts = alertService.GetAdminAlerts();

                alerts.Data[0].Read = true;
                var updatedAlert = alertService.UpdateAlert(alerts.Data[0]).Result;

                Assert.True(alerts.Successful);
                Assert.True(updatedAlert.Successful);
                Assert.True(alerts.Data[0].Read);
            }
        }
    }
}
