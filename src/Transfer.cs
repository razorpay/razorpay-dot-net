using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Transfer : Entity
    {
        public Transfer(string transferId = "")
        {
            this["id"] = transferId;
        }

        new public Transfer Fetch(string id)
        {
            return (Transfer)base.Fetch(id);
        }

        public Transfer Edit(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, options);
            return (Transfer)entities[0];
        }

        public Transfer Create(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, options);
            return (Transfer)entities[0];
        }

        /**
         * Create a reversal 
        **/
        public Reversal Reversal(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/reversals", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, options);
            return (Reversal)entities[0];
        }

        public List<Reversal> Reversals(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/reversals", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            List<Reversal> reversals = new List<Reversal>();

            foreach (Entity entity in entities)
            {
                reversals.Add((Reversal)entity);
            }

            return reversals;
        }

        public List<Transfer> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Transfer> transfers = new List<Transfer>();
            foreach (Entity entity in entities)
            {
                transfers.Add(entity as Transfer);
            }
            return transfers;
        }
    }
}