using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace Razorpay.Api
{
    public class Tnc : Entity
    {

        public Tnc Fetch(string productName)
        {
            string relativeUrl = string.Format("{0}/products/{1}/tnc", GetUrlVersion("v2"), productName);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Tnc)entities[0];
        }
    }
}
