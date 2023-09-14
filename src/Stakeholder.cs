using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Stakeholder : Entity
    {
        public Stakeholder(string stakeholderId = "")
        {
            this["id"] = stakeholderId;
        }

        public Stakeholder Fetch(string accountId, string stakeholderId)
        {
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}/{3}", GetUrlVersion("v2"), GetEntityUrl(), accountId, stakeholderId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Stakeholder)entities[0];
        }

        public Stakeholder Create(string id, Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}", GetUrlVersion("v2"), GetEntityUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Stakeholder)entities[0];
        }

        public Stakeholder Edit(string accountId, Dictionary<string, object> data)
        {            
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}/{3}", GetUrlVersion("v2"), GetEntityUrl(), accountId, this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Stakeholder)entities[0];
        }

        public List<Stakeholder> All(string accountId)
        {
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}", GetUrlVersion("v2"), GetEntityUrl(), accountId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            List<Stakeholder> customers = new List<Stakeholder>();
            foreach (Entity entity in entities)
            {
                customers.Add(entity as Stakeholder);
            }
            return customers;
        }
    }
}