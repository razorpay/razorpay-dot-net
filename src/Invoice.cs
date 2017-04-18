using System.Collections.Generic;

namespace Razorpay.Api
{
    class Invoice : Entity
    {
        new public Invoice Fetch(string id)
        {
            return (Invoice)base.Fetch(id);
        }

        public Invoice create(Dictionary<string, object> data)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Invoice)entities[0];
        }
    }
}