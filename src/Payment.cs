using System.Collections.Generic;
using System.Net.Http;

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
            List<Payment> refunds = new List<Payment>();
            foreach (Entity entity in entities)
            {
                refunds.Add(entity as Payment);
            }
            return refunds;
        }

        public Refund Refund()
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/refund";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, null);
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
    }
}