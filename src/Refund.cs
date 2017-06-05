using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Refund : Entity
    {
        new public Refund Fetch(string id)
        {
            return (Refund)base.Fetch(id);
        }

        new public List<Refund> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = Request(GetEntityUrl(), HttpMethod.Get, options);
            List<Refund> refunds = new List<Refund>();
            foreach (Entity entity in entities)
            {
                refunds.Add(entity as Refund);
            }
            return refunds;
        }

    }
}