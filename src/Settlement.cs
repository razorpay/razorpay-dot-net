using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Settlement : Entity
    {
        new public Settlement Fetch(string id)
        {
            return (Settlement)base.Fetch(id);
        }

        public Settlement Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/ondemand", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Settlement)entities[0];
        }

        public List<Settlement> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Settlement> items = new List<Settlement>();
            foreach (Entity entity in entities)
            {
                items.Add(entity as Settlement);
            }
            return items;
        }

        public List<Settlement> Reports(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/recon/combined", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, data);
            List<Settlement> items = new List<Settlement>();
            foreach (Entity entity in entities)
            {
                items.Add(entity as Settlement);
            }
            return items;
        }

        public List<Settlement> FetchAllDemand(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/{1}/ondemand", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, data);
            List<Settlement> items = new List<Settlement>();
            foreach (Entity entity in entities)
            {
                items.Add(entity as Settlement);
            }
            return items;
        }

        public Settlement FetchDemandSettlement(string id, Dictionary<string, object> option = null)
        {
            string relativeUrl = string.Format("{0}/{1}/ondemand/{2}", GetUrlVersion(), GetEntityUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, option);
            return (Settlement)entities[0];
        }
    }
}