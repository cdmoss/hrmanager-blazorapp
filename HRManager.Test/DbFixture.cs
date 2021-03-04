
using HRManager.Api.Data;
using HRManager.Api.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    [CollectionDefinition("idpDbCollection")]
    public class IdpDbCollection : ICollectionFixture<IdpDbFixture>
    {

    }

    [CollectionDefinition("apiDbCollection")]
    public class ApiDbCollection : ICollectionFixture<ApiDbFixture>
    {

    }

    public abstract class DbFixture<TContext> : IDisposable where TContext : DbContext
    {
        public DbConnection Connection { get; set; }
        protected static bool _databaseInitialized;
        protected static readonly object _lock = new object();

        public DbFixture(string dbPath)
        {
            Connection = new SqliteConnection($"Data Source={dbPath}");
            Seed();
            Connection.Open();
        }

        public virtual DbContext CreateContext(DbTransaction transaction = null)
        {
            return null;
        }

        public virtual void ClearDb(TContext context)
        {

        }

        public virtual void Seed()
        {
            
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}