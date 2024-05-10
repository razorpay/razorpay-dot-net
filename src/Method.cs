using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Method : Entity
    {

        public Method Fetch(Dictionary<string, object> data=null)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, data);
            return (Method)entities[0];
        }
    }
}