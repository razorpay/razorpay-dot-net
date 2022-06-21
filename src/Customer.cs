using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Customer : Entity 
    {
        public Customer(string customerId = "")
        {
            this["id"] = customerId;
        }

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

        public List<Customer> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Customer> customers = new List<Customer>();
            foreach (Entity entity in entities)
            {
                customers.Add(entity as Customer);
            }
            return customers;
        }        

        public Token Token(string tokenId) 
        {
            string relativeUrl = string.Format("{0}/{1}/tokens/{2}", GetEntityUrl(), this["id"], tokenId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            return (Token)entities[0];
        }

        /**
         * Fetch multiple tokens associated with the customerId
        **/
        public List<Token> Tokens() 
        {
            string relativeUrl = string.Format("{0}/{1}/tokens", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);

            List<Token> tokens = new List<Token>();

            foreach(Entity entity in entities)
            {
                tokens.Add(entity as Token);
            }

            return tokens;
        }

        public void DeleteToken(string tokenId)
        {
            string relativeUrl = string.Format("{0}/{1}/tokens/{2}", GetEntityUrl(), this["id"], tokenId);
            Request(relativeUrl, HttpMethod.Delete, null);
        }
    }
}