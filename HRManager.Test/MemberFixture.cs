using AutoMapper;
using HRManager.Api.Services;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRManager.Test
{
    public class MemberFixture : IDisposable
    {
        public EFTeamService Service { get; set; }
        private DbTransaction _transaction;

        public MemberFixture(ApiDbFixture dbFixture, IMapper mapper)
        {
            _transaction = dbFixture.Connection.BeginTransaction();
            Service = new EFTeamService(dbFixture.CreateContext(), new NullLogger<EFTeamService>(), mapper);
        }

        public void Dispose()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
