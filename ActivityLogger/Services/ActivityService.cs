using ActivityLogger.Models;
using ActivityLogger.Data;

namespace ActivityLogger.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ActivityLoggerContext _context;

        public ActivityService(ActivityLoggerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities.ToList();
        }

        public Activity GetActivityById(string id)
        {
            return _context.Activities.FirstOrDefault(a => a.Id == id);
        }

        public void AddActivity(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        public void UpdateActivity(Activity updatedActivity)
        {
            var existingActivity = _context.Activities.FirstOrDefault(a => a.Id == updatedActivity.Id);
            if (existingActivity != null)
            {
                existingActivity.Description = updatedActivity.Description;
                existingActivity.Timestamp = updatedActivity.Timestamp;
                existingActivity.Type = updatedActivity.Type;
                _context.SaveChanges();
            }
        }

        public void DeleteActivity(string id)
        {
            var activity = _context.Activities.FirstOrDefault(a => a.Id == id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
