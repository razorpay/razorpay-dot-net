using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Payment : Entity
    {
        public Payment(string paymentId = "")
        {
            this["id"] = paymentId;
        }

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

        public Refund Refund(Dictionary<string, object> data = null)
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/refund";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Refund)entities[0];
        }

        public Refund FetchRefund(string refundId)
        {
            string relativeUrl = string.Format("payments/{0}/refunds/{1}", this["id"], refundId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            return (Refund)entities[0];
        }

        public List<Refund> AllRefunds(Dictionary<string, object> data = null)
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

        public List<Transfer> Transfer(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/{1}/transfers", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);

            // Todo: Make a utility method or something to DRY below for-each thing from across this sdk.
            List<Transfer> transfers = new List<Transfer>();
            foreach(Entity entity in entities)
            {
                transfers.Add(entity as Transfer);
            }

            return transfers;
        }

        public List<Transfer> Transfers()
        {
            string relativeUrl = string.Format("{0}/{1}/transfers", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);

            List<Transfer> transfers = new List<Transfer>();

            foreach(Entity entity in entities)
            {
                transfers.Add(entity as Transfer);
            }

            return transfers;
        }

        public Payment Edit(Dictionary<string, object> data) 
        {
            string relativeUrl = string.Format("{0}/{1}/", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Payment)entities[0];
        }

        public Card FetchCardDetails(string cardId)
        {
            string relativeUrl = string.Format("{0}/{1}/card", GetEntityUrl(), cardId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            return (Card)entities[0];
        }

        public List<Payment> FetchPaymentDowntime()
        {
            string relativeUrl = string.Format("{0}/downtimes", GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }
            return payments;
        }

        public Payment FetchPaymentDowntimeById(string downtimeId)
        {
            string relativeUrl = string.Format("{0}/downtimes/{1}", GetEntityUrl(), downtimeId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            return (Payment)entities[0];
        }
    }
}
