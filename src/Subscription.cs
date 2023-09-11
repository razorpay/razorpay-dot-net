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
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Subscription)entities[0];
        }

        public Subscription Cancel(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/cancel", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, options);
            return (Subscription)entities[0];
        }

        public Addon CreateAddon(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/addons", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, options);
            return (Addon)entities[0];
        }

        public Subscription Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Subscription)entities[0];
        }

        public Subscription FetchPendingUpdate()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/retrieve_scheduled_changes", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Subscription)entities[0];
        }

        public Subscription CancelPendingUpdate()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/cancel_scheduled_changes", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            return (Subscription)entities[0];
        }

        public Subscription Pause(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/pause", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, options);
            return (Subscription)entities[0];
        }

        public Subscription Resume(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/resume", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, options);
            return (Subscription)entities[0];
        }

        public Subscription DeleteOffer(string offerId)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/{3}", GetUrlVersion(), GetEntityUrl(), this["id"] , offerId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.DELETE, null);
            return (Subscription)entities[0];
        }
    }
}