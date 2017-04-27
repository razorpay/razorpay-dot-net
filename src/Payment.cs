using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Payment : Entity
    {
        new public Payment Fetch(string id)
        {
            return (Payment)base.Fetch(id);
        }

        new public List<Payment> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }
            return payments;
        }

        public Payment Capture(Dictionary<string, object> attributes)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/capture";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, attributes);
            return (Payment)entities[0];
        }

        public Refund createRefund(Dictionary<string, object> data = null)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/refunds";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Refund)entities[0];
        }

        public Refund fetchRefund(string id)
        {
            string relativeUrl = string.Format("payments/{0}/refunds/{1}", this["id"], id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            return (Refund)entities[0];
        }

        public List<Refund> getAllRefunds(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("payments/{0}/refunds", this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, data);
            List<Refund> refunds = new List<Refund>();
            foreach (Entity entity in entities)
            {
                refunds.Add(entity as Refund);
            }
            return refunds;
        }

        public Transfer Transfer(Dictionary<string, object> data = null)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/transfers";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Transfer)entities[0];
        }

        public List<Transfer> Transfers
        {
            get
            {
                string relativeUrl = string.Format("payments/{0}/transfers", this["id"]);
                List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);

                List<Transfer> transfers = new List<Transfer>();

                foreach(Entity entity in entities)
                {
                    transfers.Add(entity as Transfer);
                }

                return transfers;
            }
        }
    }
}