using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Token : Entity
    {
        public string CustomerId;

        public Token(string customerId = "")
        {
            CustomerId = customerId;
        }

        new public Token Fetch(string id)
        {
            string relativeUrl = string.Format("customers/{0}/{1}/{2}", this.CustomerId, GetEntityUrl(), id);
            List<Entity> tokens = Request(relativeUrl, HttpMethod.Get, null);
            return (Token)tokens[0];
        }

        new public List<Token> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("customers/{0}/{1}", this.CustomerId, GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, options);

            List<Token> tokens = new List<Token>();

            foreach(Entity entity in entities)
            {
                tokens.Add(entity as Token);
            }

            return tokens;
        }

        public Token Delete(string id)
        {
            string relativeUrl = string.Format("customers/{0}/{1}/{2}", this.CustomerId, GetEntityUrl(), id);
            List<Entity> tokens = Request(relativeUrl, HttpMethod.Delete, null);
            return (Token)tokens[0];
        }
    }
}