using Microsoft.EntityFrameworkCore;

namespace PalTracker
{    
    public class TimeEntryContext : DbContext
    {

        public TimeEntryContext(DbContextOptions<TimeEntryContext> options) : base(options)
        {
            
        }

        public DbSet<TimeEntryRecord> TimeEntryRecords { get; set; }

    }
}