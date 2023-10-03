using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Token : Entity
    {
        public Token Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Token)entities[0];
        }

        public Token Fetch(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/fetch", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Token)entities[0];
        }

        public Token ProcessPaymentOnAlternatePAorPG(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/service_provider_tokens/token_transactional_data", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Token)entities[0];
        }

        public List<Token> Delete(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/delete", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            List<Token> items = new List<Token>();
            foreach (Entity entity in entities)
            {
                items.Add(entity as Token);
            }
            return items;
        }
    }
}