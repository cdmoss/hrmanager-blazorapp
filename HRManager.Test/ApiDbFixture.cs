using HRManager.Api.Data;
using HRManager.Api.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public class ApiDbFixture : DbFixture<MainContext>
    {
        public ApiDbFixture(string dbPath = Constants.apiTestConn) : base(dbPath)
        {
        }

        public override MainContext CreateContext(DbTransaction transaction = null)
        {
            var context = new MainContext(new DbContextOptionsBuilder<MainContext>().UseSqlite(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        public override void ClearDb(MainContext context)
        {
            context.RemoveRange(context.Members.ToList());
            context.RemoveRange(context.Positions.ToList());
            context.RemoveRange(context.Shifts.ToList());

            context.SaveChanges();
        }

        // this always needs to be called before the idp seeder
        public override void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        var seeder = new DbSeeder(context, new NullLogger<DbSeeder>());

                        seeder.SeedMembers();
                        seeder.SeedPositions();
                        seeder.SeedShifts();
                        seeder.SeedTimeEntries();
                    }

                    _databaseInitialized = true;
                }
            }
        }
    }
}
