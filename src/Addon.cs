using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Addon : Entity
    {
        new public Addon Fetch(string id)
        {
            return (Addon)base.Fetch(id);
        }

        new public List<Addon> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Addon> addons = new List<Addon>();
            foreach (Entity entity in entities)
            {
                addons.Add(entity as Addon);
            }
            return addons;
        }

        public Addon Create(Dictionary<string, object> data)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Addon)entities[0];
        }
    }
}