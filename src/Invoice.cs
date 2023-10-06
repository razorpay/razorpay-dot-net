using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Invoice : Entity
    {
        new public Invoice Fetch(string id)
        {
            return (Invoice)base.Fetch(id);
        }

        public Invoice Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Invoice)entities[0];
        }

        public List<Invoice> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Invoice> invoices = new List<Invoice>();
            foreach (Entity entity in entities)
            {
                invoices.Add(entity as Invoice);
            }
            return invoices;
        }

        public Invoice Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            if (entities != null && entities.Count > 0)
            {
                return (Invoice)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Invoice Cancel()
        {
            string relativeUrl = string.Format("{0}/invoices/{1}/cancel", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            if (entities != null && entities.Count > 0)
            {
                return (Invoice)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Invoice NotifyBy(string medium)
        {
            string relativeUrl = string.Format("{0}/invoices/{1}/notify_by/{2}", GetUrlVersion(), this["id"], medium);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            if (entities != null && entities.Count > 0)
            {
                return (Invoice)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Invoice CreateRegistrationLink(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/subscription_registration/auth_links", GetUrlVersion());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Invoice)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Invoice Issue()
        {
            string relativeUrl = string.Format("{0}/invoices/{1}/issue", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            if (entities != null && entities.Count > 0)
            {
                return (Invoice)entities[0];
            }
            else
            {
                return null;
            }
        }

        public List<Invoice> Delete()
        {
            string relativeUrl = string.Format("{0}/invoices/{1}", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.DELETE, null);
            List<Invoice> invoices = new List<Invoice>();
            foreach (Entity entity in entities)
            {
                invoices.Add(entity as Invoice);
            }
            return invoices;
        }
    }
}