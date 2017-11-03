using System.Collections.Generic;

namespace Razorpay.Api
{
    public class VirtualAccount : Entity
    {
        new public VirtualAccount Fetch(string id)
        {
            return (VirtualAccount)base.Fetch(id);
        }

        new public List<VirtualAccount> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<VirtualAccount> virtualaccounts = new List<VirtualAccount>();
            foreach (Entity entity in entities)
            {
                virtualaccounts.Add(entity as VirtualAccount);
            }
            return virtualaccounts;
        }

        public VirtualAccount Create(Dictionary<string, object> data)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (VirtualAccount)entities[0];
        }

        public VirtualAccount Edit(Dictionary<string, object> data) 
        {
            string relativeUrl = string.Format("{0}/{1}", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Put, data);
            return (VirtualAccount)entities[0];
        }
    }
}