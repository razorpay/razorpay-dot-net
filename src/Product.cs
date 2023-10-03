using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Product : Entity
    {
        public Product(string productId = "", string accountId = "")
        {
            this["id"] = productId;
            this["account_id"] = accountId;
        }


        public Product RequestProductConfiguration(string accountId, Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}", GetUrlVersion("v2"), GetEntityUrl(), accountId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Product)entities[0];
        }

        public Product Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}/{3}", GetUrlVersion("v2"), GetEntityUrl(), this["account_id"], this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Product)entities[0];
        }

        public Product Fetch(string id, string productId)
        {
            string relativeUrl = string.Format("{0}/accounts/{2}/{1}/{3}", GetUrlVersion("v2"), GetEntityUrl(), id, productId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Product)entities[0];
        }
    }
}