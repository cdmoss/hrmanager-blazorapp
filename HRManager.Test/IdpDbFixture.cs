using HRManager.Idp.Data;
using HRManager.Idp.Entities;
using HRManager.Idp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Test
{
    public class IdpDbFixture : DbFixture<IdentityContext>
    {
        public IdpDbFixture(string dbPath = Constants.idpTestConn) : base(dbPath)
        {
        }

        public override IdentityContext CreateContext(DbTransaction transaction = null)
        {
            var context = new IdentityContext(new DbContextOptionsBuilder<IdentityContext>().UseSqlite(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        public override void ClearDb(IdentityContext context)
        {
            context.RemoveRange(context.Users.ToList());

            context.SaveChanges();
        }

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

                        var userManager = TestHelpers.Identity.CreateUserManager(context);
                        var roleManager = TestHelpers.Identity.CreateRoleManager(context);

                        var seeder = new DbSeeder(context, userManager, roleManager, new NullLogger<DbSeeder>());

                        var membersWithRoles = new Dictionary<int, string>();

                        for (int i = 1; i < 11; i++)
                        {
                            membersWithRoles.Add(i, "Member");
                        }

                        bool seedSuccess = seeder.SeedUsers(membersWithRoles).Result;
                    }

                    _databaseInitialized = true;
                }
            }
        }
    }
}
