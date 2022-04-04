using System;
using Microsoft.EntityFrameworkCore;

namespace UtahCrashes.Models
{
    public class CrashesDbContext : DbContext
    {
        public CrashesDbContext(DbContextOptions<CrashesDbContext> options) : base (options)
        {
        }

        public DbSet<Crash> Crashes { get; set; }
        public DbSet<County> Counties { get; set; }
    }
}
