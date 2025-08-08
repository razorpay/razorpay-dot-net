using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Razorpay.Api
{
    /// <summary>
    /// Device connection mode for POS gateway operations
    /// </summary>
    public enum DeviceMode
    {
        /// <summary>
        /// Wired device connection
        /// </summary>
        Wired,
        
        /// <summary>
        /// Wireless device connection
        /// </summary>
        Wireless
    }

    public class DeviceActivity : Entity 
    {
        public DeviceActivity(string activityId = "")
        {
            this["id"] = activityId;
        }

        /// <summary>
        /// Create a new device activity for POS gateway
        /// </summary>
        /// <param name="mode">Device connection mode</param>
        /// <param name="data">Dictionary containing device activity data in the format expected by rzp-pos-gateway</param>
        /// <returns>DeviceActivity object</returns>
        public DeviceActivity Create(DeviceMode mode, Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data, "API", AuthType.Public, mode);
            return (DeviceActivity)entities[0];
        }

        /// <summary>
        /// Get the status of a device activity
        /// </summary>
        /// <param name="mode">Device connection mode</param>
        /// <param name="activityId">Activity ID to fetch status for</param>
        /// <returns>DeviceActivity object with current status</returns>
        public DeviceActivity GetStatus(DeviceMode mode, string activityId)
        {
            // Use the correct endpoint format: devices/activity/{activity_id}
            // Build the relative URL using the same entity path helper for consistency
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), activityId);

            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null, "API", AuthType.Public, mode);
            return (DeviceActivity)entities[0];
        }


        /// <summary>
        /// Override to use custom entity URL for device activities
        /// </summary>
        /// <returns>Entity URL for device activities</returns>
        protected new string GetEntityUrl()
        {
            return "devices/activity";
        }
    }
} 