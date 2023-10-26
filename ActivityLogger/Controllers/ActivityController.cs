using ActivityLogger.Models;
using ActivityLogger.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ActivityLogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService ?? throw new ArgumentNullException(nameof(activityService));
        }

        // GET: api/Activity
        [HttpGet]
        public ActionResult<IEnumerable<Activity>> GetActivities()
        {
            var activities = _activityService.GetAllActivities();
            return Ok(activities);
        }

        // GET: api/Activity/{id}
        [HttpGet("{id}")]
        public ActionResult<Activity> GetActivity(string id)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        // POST: api/Activity
        [HttpPost]
        public ActionResult<Activity> CreateActivity([FromBody] Activity activity)
        {
            _activityService.AddActivity(activity);
            return CreatedAtAction(nameof(GetActivity), new { id = activity.Id }, activity);
        }

        // PUT: api/Activity/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateActivity(string id, [FromBody] Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            var existingActivity = _activityService.GetActivityById(id);
            if (existingActivity == null)
            {
                return NotFound();
            }

            _activityService.UpdateActivity(activity);
            return NoContent();
        }

        // DELETE: api/Activity/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteActivity(string id)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }

            _activityService.DeleteActivity(id);
            return NoContent();
        }
    }
}
