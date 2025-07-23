using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class DeviceActivity : Entity 
    {
        public DeviceActivity(string activityId = "")
        {
            this["id"] = activityId;
        }

        new public DeviceActivity Fetch(string id)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null, "POS");
            return (DeviceActivity)entities[0];
        }

        /// <summary>
        /// Create a new device activity for POS gateway
        /// </summary>
        /// <param name="data">Dictionary containing device activity data in the format expected by rzp-pos-gateway</param>
        /// <returns>DeviceActivity object</returns>
        public DeviceActivity Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data, "POS");
            return (DeviceActivity)entities[0];
        }

        /// <summary>
        /// Get the status of a device activity
        /// </summary>
        /// <param name="activityId">Activity ID to fetch status for</param>
        /// <returns>DeviceActivity object with current status</returns>
        public DeviceActivity GetStatus(string activityId)
        {
            if (string.IsNullOrWhiteSpace(activityId))
            {
                throw new System.ArgumentNullException("activityId", "Activity ID cannot be null or empty");
            }

            // Use the correct endpoint format: device/activity/{activity_id}
            // Build the relative URL using the same entity path helper for consistency
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), activityId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null, "POS");
            return (DeviceActivity)entities[0];
        }


        /// <summary>
        /// Override to use custom entity URL for device activities
        /// </summary>
        /// <returns>Entity URL for device activities</returns>
        protected new string GetEntityUrl()
        {
            return "device/activity";
        }
    }
} 