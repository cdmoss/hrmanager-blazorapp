using System;
using System.Collections.Generic;
using System.Text;
using HRManager.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Api.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<MemberProfile> Members { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<ShiftRequestAlert> ShiftAlerts { get; set; }
        public DbSet<ApplicationAlert> ApplicationAlerts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<MemberPosition> MemberPositions { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reference>().HasOne(p => p.Member).WithMany(b => b.References).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WorkExperience>().HasOne(p => p.Member).WithMany(b => b.WorkExperiences).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Availability>().HasOne(p => p.Member).WithMany(b => b.Availabilities).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Shift>().HasOne(p => p.Member).WithMany(b => b.Shifts).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Alert>().HasOne(p => p.Member).WithMany(b => b.Alerts).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TimeEntry>().HasOne(p => p.Member).WithMany(b => b.TimeEntries).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ShiftRequestAlert>().HasOne(p => p.OriginalShift).WithMany().OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<MemberPosition>().HasOne(p => p.Member).WithMany(b => b.Positions).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MemberPosition>().HasOne(p => p.Position).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
