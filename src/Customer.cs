using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Customer : Entity 
    {
        new public Customer Fetch(string id)
        {
            return (Customer)base.Fetch(id);
        }

        public Customer Create(Dictionary<string, object> data)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Customer)entities[0];
        }
           
        public Customer Edit(Dictionary<string, object> data) 
        {
            string relativeUrl = string.Format("{0}/{1}", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Put, data);
            return (Customer)entities[0];
        }

        public Token Tokens()
        {
            Token token = new Token();
            token.CustomerId = this["id"].ToString();
            return token;
        }
    }
}