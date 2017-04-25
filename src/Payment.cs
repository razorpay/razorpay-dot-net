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

        public Refund Refund(Dictionary<string, object> data = null)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/refund";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Refund)entities[0];
        }

        public Payment Capture(Dictionary<string, object> attributes)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/capture";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, attributes);
            return (Payment)entities[0];
        }

        public Refund Refunds
        {
            get
            {
                Refund refund = new Refund();
                refund.PaymentId = this["id"].ToString();
                return refund;
            }
        }

        public Transfer Transfer(Dictionary<string, object> data = null)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/transfers";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Transfer)entities[0];
        }

        public List<Transfer> Transfers(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("payments/{0}/{1}", this["id"], GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);

            List<Transfer> transfers = new List<Transfer>();

            foreach(Entity entitiy in entities)
            {
                transfers.Add(entitiy as Transfer);
            }

            return transfers;
        }
    }
}