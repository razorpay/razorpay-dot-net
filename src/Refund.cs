using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Refund : Entity
    {
        public string PaymentId;

        public Refund(string paymentId)
        {
            PaymentId = paymentId;
        }

        new public Refund Fetch(string id)
        {
            return (Refund)base.Fetch(id);
        }

        new public List<Refund> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("payments/{0}/{1}", this.PaymentId, GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, options);
            List<Refund> refunds = new List<Refund>();
            foreach (Entity entity in entities)
            {
                refunds.Add(entity as Refund);
            }
            return refunds;
        }

    }
}