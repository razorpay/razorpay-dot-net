using System.Collections.Generic;
using System;

namespace Razorpay.Api
{
    public class Dispute : Entity
    {
        public Dispute(string disputeId = "")
        {
            this["id"] = disputeId;
        }

        new public Dispute Fetch(string id, Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, data);
            if (entities != null && entities.Count > 0)
            {
                return (Dispute)entities[0];
            }
            else
            {
                return null;
            }
        }

        public List<Dispute> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);

            List<Dispute> disputes = new List<Dispute>();

            foreach (Entity entity in entities)
            {
                disputes.Add(entity as Dispute);
            }

            return disputes;
        }

        public Dispute Accept(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/accept", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Dispute)entities[0];
        }

        public Dispute Contest(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/contest", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Dispute)entities[0];
        }
    }
}
