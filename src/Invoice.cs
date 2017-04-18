using System.Collections.Generic;

namespace Razorpay.Api
{
    class Invoice : Entity
    {
        new public Invoice Fetch(string id)
        {
            return (Invoice)base.Fetch(id);
        }

        public Invoice create(Dictionary<string, string> data)
        {
            string relativeUrl = GetEntitiyUrl();
            List<Entity> enitities = Request(relativeUrl, HttpMethod.Post, data);
            return (Invoice)entities[0];
        }
    }
}