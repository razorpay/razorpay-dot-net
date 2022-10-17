using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Invoice : Entity
    {
        new public Invoice Fetch(string id)
        {
            return (Invoice)base.Fetch(id);
        }

        public Invoice Create(Dictionary<string, object> data)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Invoice)entities[0];
        }
    }
}