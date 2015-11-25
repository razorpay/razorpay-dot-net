using System.Collections.Generic;
using System.Net.Http;

namespace Razorpay.Api
{
	public class Payment : Entity
	{
        new public dynamic Fetch(string id)
        {
            return base.Fetch(id);
        }

        new public dynamic All(Dictionary<string, object> options = null)
        {
            return base.All(options);
        }

        public dynamic Refund(string id)
	    {
	        string relativeUrl = GetEntityUrl() + id + "/refund";
	        return Request(relativeUrl, HttpMethod.Post, null);
	    }

        public dynamic Capture(string id, Dictionary<string, object> attributes)
	    {
	        string relativeUrl = GetEntityUrl()  +  id  + "/capture";
	        return Request(relativeUrl, HttpMethod.Post, attributes);
	    }

	    public Refund this[string id]
	    {
            get
            {
                Refund refund = new Refund();
                refund.PaymentId = id;
                return refund;
            }

	    }
	}
}