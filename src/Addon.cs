using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace Razorpay.Api
{
    public class Addon : Entity
    {
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

        public Addon Delete()
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"];
            List<Entity> entities = Request(relativeUrl, HttpMethod.Delete, null);
            return (Addon)entities[0];
        }
    }
}