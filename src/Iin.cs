using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Iin : Entity
    {
        public Iin Fetch(string id)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Iin)entities[0];
        }

        public Iin All(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/list", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, data);
            return (Iin)entities[0];
        }
    }
}