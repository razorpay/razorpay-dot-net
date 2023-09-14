using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Webhook : Entity
    {
        public Webhook(string customerId = "")
        {
            this["id"] = customerId;
        }

        public Webhook Fetch(string id, string accountId=null)
        {
            string relativeUrl;
            if (!string.IsNullOrEmpty(accountId))
            {
                 relativeUrl = string.Format("{0}/accounts/{2}/{1}/{3}", GetUrlVersion("v2"), GetEntityUrl(), accountId, id);
            }
            else
            {
                 relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), id);
            }            
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Webhook)entities[0];
        }

        public Webhook Create(Dictionary<string, object> data, string accountId=null)
        {
            string relativeUrl;
            if (!string.IsNullOrEmpty(accountId))
            {
                relativeUrl = string.Format("{0}/accounts/{2}/{1}", GetUrlVersion("v2"), GetEntityUrl(), accountId);
            }
            else
            {
                relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            }
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Webhook)entities[0];
        }

        public Webhook Edit(Dictionary<string, object> data, string accountId=null)
        {
            string relativeUrl;
            List<Entity> entities;
            if (!string.IsNullOrEmpty(accountId))
            {
                relativeUrl = string.Format("{0}/accounts/{2}/{1}/{3}", GetUrlVersion("v2"), GetEntityUrl(), accountId, this["id"]);
                entities = Request(relativeUrl, HttpMethod.PATCH, data);
            }
            else
            {
                relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
                entities = Request(relativeUrl, HttpMethod.PUT, data);
            }
            return (Webhook)entities[0];
        }

        public List<Webhook> Delete(string id, string accountId)
        {
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}/{3}", GetUrlVersion("v2"), GetEntityUrl(), accountId, id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.DELETE, null);
            List<Webhook> webhooks = new List<Webhook>();
            foreach (Entity entity in entities)
            {
                webhooks.Add(entity as Webhook);
            }
            return webhooks;
        }

        public List<Webhook> All(string accountId=null, Dictionary<string, object> options = null)
        {
            string relativeUrl;
            if (!string.IsNullOrEmpty(accountId))
            {
                relativeUrl = string.Format("{0}/accounts/{2}/{1}", GetUrlVersion("v2"), GetEntityUrl(), accountId);
            }
            else
            {
                relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            }
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            List<Webhook> webhooks = new List<Webhook>();
            foreach (Entity entity in entities)
            {
                webhooks.Add(entity as Webhook);
            }
            return webhooks;
        }
    }
}