using ActivityLogger.Models;

namespace ActivityLogger.Services
{
    public interface IActivityService
    {
        IEnumerable<Activity> GetAllActivities();
        Activity GetActivityById(string id);
        void AddActivity(Activity activity);
        void DeleteActivity(string id);
        void UpdateActivity(Activity activity);
    }


}

