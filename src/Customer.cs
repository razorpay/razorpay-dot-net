using Newtonsoft.Json.Linq;
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
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Customer)entities[0];
        }
           
        public Customer Edit(Dictionary<string, object> data) 
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PUT, data);
            return (Customer)entities[0];
        }

        public Token Token(string tokenId) 
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/tokens/{3}", GetUrlVersion(), GetEntityUrl(), this["id"], tokenId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Token)entities[0];
        }

        /**
         * Fetch multiple tokens associated with the customerId
        **/
        public List<Token> Tokens() 
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/tokens", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);

            List<Token> tokens = new List<Token>();

            foreach(Entity entity in entities)
            {
                tokens.Add(entity as Token);
            }

            return tokens;
        }

        public Customer DeleteToken(string tokenId)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/tokens/{3}", GetUrlVersion(), GetEntityUrl(), this["id"], tokenId);
            List<Entity> entities =  Request(relativeUrl, HttpMethod.DELETE, null);
            if (entities != null && entities.Count > 0)
            {
                return (Customer)entities[0];
            }
            else
            {
                return null;
            }
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

        public BankAccount AddBankAccount(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/bank_account", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (BankAccount)entities[0];
        }

        public Customer DeleteBankAccount(string bankAccountId)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/bank_account/{3}", GetUrlVersion(), GetEntityUrl(), this["id"], bankAccountId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.DELETE, null);
            if (entities != null && entities.Count > 0)
            {
                return (Customer)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Customer RequestEligibilityCheck(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/eligibility", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Customer)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Customer FetchEligibility(string eligiblityId)
        {
            string relativeUrl = string.Format("{0}/{1}/eligibility/{2}", GetUrlVersion(), GetEntityUrl(), eligiblityId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            if (entities != null && entities.Count > 0)
            {
                return (Customer)entities[0];
            }
            else
            {
                return null;
            }
        }
    }
}
