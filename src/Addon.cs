using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Addon : Entity
    {
        new public Addon Fetch(string id)
        {
            return (Addon)base.Fetch(id);
        }

        public Addon Delete()
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"];
            List<Entity> entities = Request(relativeUrl, HttpMethod.Delete, null);
            return (Addon)entities[0];
        }

        public Addon Create(Dictionary<string, object> data)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Addon)entities[0];
        }
    }
}