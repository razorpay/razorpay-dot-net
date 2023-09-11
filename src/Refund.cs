using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Refund : Entity
    {
        new public Refund Fetch(string id)
        {
            return (Refund)base.Fetch(id);
        }

        public Refund Create(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/{1}/", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Refund)entities[0];
        }

        new public List<Refund> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            List<Refund> refunds = new List<Refund>();
            foreach (Entity entity in entities)
            {
                refunds.Add(entity as Refund);
            }
            return refunds;
        }

        public Refund Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Refund)entities[0];
        }
    }
}