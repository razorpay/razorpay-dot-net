using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Transfer : Entity
    {
        public string PaymentId;

        new public Transfer Fetch(string id)
        {
            return (Transfer)base.Fetch(id);
        }

        new public List<Transfer> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("payments/{0}/{1}", this.PaymentId, GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);

            List<Transfer> transfers = new List<Transfer>();

            foreach(Entity entitiy in entities)
            {
                transfers.Add(entitiy as Transfer);
            }

            return transfers;
        }

        public Transfer Edit(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Put, options);   
            return (Transfer)entities[0];
        }

        public Transfer Create(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("payments/{0}/{1}", this.PaymentId, GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, options);
            return (Transfer)entities[0];
        }

        public Reversal Reversals
        {
            get 
            {
                Reversal reversal = new Reversal();
                reversal.TransferId = this["id"].ToString();
                return reversal;
            }
        }
    }
}