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
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Plan)entities[0];
            }
            else
            {
                return null;
            }
        }
    }
}