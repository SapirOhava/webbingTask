using ActivityLogger.Models;
using Microsoft.EntityFrameworkCore;

namespace ActivityLogger.Data
{
    public class ActivityLoggerContext : DbContext
    {
        public ActivityLoggerContext(DbContextOptions<ActivityLoggerContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
