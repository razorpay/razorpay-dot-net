using System.Collections.Generic;
using System.Net.Http;

namespace Razorpay.Api
{
	public class Refund : Entity
	{
		public string PaymentId { get; set; }

        new public dynamic Fetch(string id)
	    {
	        string relativeUrl = string.Format("payments/{0}/{1}{2}", PaymentId, GetEntityUrl(), id);
	        return Request(relativeUrl, HttpMethod.Get, null);
	    }

        new public dynamic All(Dictionary<string, object> options = null)
	    {
	        string relativeUrl = string.Format("payments/{0}/{1}", PaymentId, GetEntityUrl());
	        return Request(relativeUrl, HttpMethod.Get, options);
	    }

	}
}