namespace PalTracker
{
    public static class MappingExtensions
    {
        
        public static TimeEntry ToEntity(this TimeEntryRecord record) => new TimeEntry{
            Id = record.Id,
            ProjectId = record.ProjectId,
            UserId = record.UserId,
            Date = record.Date,
            Hours = record.Hours
        };
        
        public static TimeEntryRecord ToRecod(this TimeEntry entry) => new TimeEntryRecord{
            Id = entry.Id,
            ProjectId = entry.ProjectId,
            UserId = entry.UserId,
            Date = entry.Date,
            Hours = entry.Hours
        };
    }
}