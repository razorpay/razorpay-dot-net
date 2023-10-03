using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Account : Entity
    {
        public Account(string customerId = "")
        {
            this["id"] = customerId;
        }

        public Account Fetch(string id)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion("v2"), GetEntityUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Account)entities[0];
        }

        public Account Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion("v2"), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Account)entities[0];
        }

        public Account Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion("v2"), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Account)entities[0];
        }

        public Account Delete()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion("v2"), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.DELETE, null);
            return (Account)entities[0];
        }

    }
}