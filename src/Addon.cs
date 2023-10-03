using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace Razorpay.Api
{
    public class Addon : Entity
    {
        public Addon(string addonId = "")
        {
            this["id"] = addonId;
        }
        
        new public Addon Fetch(string id)
        {
            return (Addon)base.Fetch(id);
        }

        public List<Addon> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);

            List<Addon> addons = new List<Addon>();

            foreach (Entity entity in entities)
            {
                addons.Add(entity as Addon);
            }

            return addons;
        }

        public List<Addon> Delete()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities =  Request(relativeUrl, HttpMethod.DELETE, null);
            List<Addon> addons = new List<Addon>();
            foreach (Entity entity in entities)
            {
                addons.Add(entity as Addon);
            }
            return addons;
        }
    }
}
