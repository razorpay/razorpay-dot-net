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
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Refund)entities[0];
        }

        new public List<Refund> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = Request(GetEntityUrl(), HttpMethod.GET, options);
            List<Refund> refunds = new List<Refund>();
            foreach (Entity entity in entities)
            {
                refunds.Add(entity as Refund);
            }
            return refunds;
        }

    }
}