using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Plan : Entity
    {
        new public Plan Fetch(string id)
        {
            return (Plan)base.Fetch(id);
        }

        new public List<Plan> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Plan> plans = new List<Plan>();
            foreach (Entity entity in entities)
            {
                plans.Add(entity as Plan);
            }
            return plans;
        }

        public Plan Create(Dictionary<string, object> data = null)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Plan)entities[0];
        }
    }
}