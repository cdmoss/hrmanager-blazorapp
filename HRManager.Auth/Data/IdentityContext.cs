using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Auth.Data
{
    public class IdentityContext : IdentityDbContext<UserProfile, IdentityRole<int>, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
