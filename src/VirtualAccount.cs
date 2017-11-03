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
            string relativeUrl = "virtual_accounts";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (VirtualAccount)entities[0];
        }

        public VirtualAccount Edit(Dictionary<string, object> data) 
        {
            string relativeUrl = string.Format("virtual_accounts/{0}", this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Patch, data);
            return (VirtualAccount)entities[0];
        }

        public List<Payment> Payments()
        {
            string relativeUrl = string.Format("virtual_accounts/{0}/payments", this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);

            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }
            return payments;
        }
    }
}