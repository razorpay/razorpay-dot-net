using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Subscription : Entity
    {
        public Subscription(string subscriptionId = "")
        {
            this["id"] = subscriptionId;
        }

        new public Subscription Fetch(string id)
        {
            return (Subscription)base.Fetch(id);
        }

        new public List<Subscription> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Subscription> subscriptions = new List<Subscription>();
            foreach (Entity entity in entities)
            {
                subscriptions.Add(entity as Subscription);
            }
            return subscriptions;
        }

        public Subscription Create(Dictionary<string, object> data)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Subscription)entities[0];
        }

        public Subscription Cancel()
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/cancel";
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            return (Subscription)entities[0];
        }

        public Addon createAddon(Dictionary<string, object> data = null)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/addons";
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Addon)entities[0];
        }
    }
}