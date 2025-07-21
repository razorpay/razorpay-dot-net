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
            return (DeviceActivity)base.Fetch(id);
        }

        /// <summary>
        /// Create a new device activity for POS gateway
        /// </summary>
        /// <param name="data">Dictionary containing device activity data in the format expected by rzp-pos-gateway</param>
        /// <returns>DeviceActivity object</returns>
        public DeviceActivity Create(Dictionary<string, object> data)
        {
            // Set the communication mode header if provided
            if (data.ContainsKey("communication_mode"))
            {
                string communicationMode = data["communication_mode"].ToString();
                if (communicationMode != "wired" && communicationMode != "wireless")
                {
                    throw new System.ArgumentException("communication_mode must be 'wired' or 'wireless'");
                }
                
                // The header should already be set in the calling code, but ensure it's set
                if (!RazorpayClient.Headers.ContainsKey("X-Communication-Mode"))
                {
                    RazorpayClient.Headers["X-Communication-Mode"] = communicationMode;
                }
            }

            // Remove communication_mode from data as it's not part of the request body
            var requestData = new Dictionary<string, object>(data);
            if (requestData.ContainsKey("communication_mode"))
            {
                requestData.Remove("communication_mode");
            }

            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, requestData, "POS");
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

            // Use the correct endpoint format: device/activity/{activity_id} (no leading slash)
            // Build the relative URL using the same entity path helper for consistency
            string relativeUrl = string.Format("{0}/{1}", GetEntityUrl(), activityId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null, "POS");
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