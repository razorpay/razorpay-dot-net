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

        public List<Addon> All()
        {
            List<Entity> entities = Request(GetEntityUrl(), HttpMethod.Get, null);

            List<Addon> addons = new List<Addon>();

            foreach (Entity entity in entities)
            {
                addons.Add(entity as Addon);
            }

            return addons;
        }

        public void Delete()
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"];
            Request(relativeUrl, HttpMethod.Delete, null);
        }
    }
}
