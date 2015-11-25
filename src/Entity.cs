using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Razorpay.Api
{
	public class Entity
	{
		private RestClient client;

        protected dynamic Fetch(string id)
		{			
			if(string.IsNullOrWhiteSpace(id))
			{
				string message = "id is null";
				throw new ArgumentNullException(message);
			}

			string entityUrl = GetEntityUrl();
			string relativeUrl = string.Format("{0}{1}", entityUrl, id);
			return Request(relativeUrl, HttpMethod.Get, null);
		}

        protected dynamic All(Dictionary<string, object> options = null)
		{
			string entityUrl = GetEntityUrl();
			return Request(entityUrl, HttpMethod.Get, options);
		}

        protected dynamic Request(string relativeUrl, HttpMethod verb, Dictionary<string, object> options)
		{
			client = new RestClient();
            string postData = JsonConvert.SerializeObject(options);

			string responseStr = client.MakeRequest(relativeUrl, verb, postData);

            Dictionary<string, object> response = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
			return response;
		}

		protected string GetEntityUrl()
		{
			return this.GetType().Name.ToLower() + "s/";
		}
	}
}