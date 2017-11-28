using System.Collections.Generic;
using System;using Newtonsoft.Json;


namespace Razorpay.Api
{
    public class VirtualAccount : Entity
    {
        public VirtualAccount(string accountId = "")
        {
            this["id"] = accountId;
        }

        new public VirtualAccount Fetch(string id)
        {
            string relativeUrl = string.Format("virtual_accounts/{0}", id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            return (VirtualAccount)entities[0];
        }

        new public List<VirtualAccount> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = "virtual_accounts";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);

            List<VirtualAccount> virtualaccounts = new List<VirtualAccount>();
            
            foreach (Entity entity in entities)
            {
                virtualaccounts.Add(entity as VirtualAccount);
            }
            return virtualaccounts;
        }

        public VirtualAccount Create(Dictionary<string, object> data = null)
        {
            string relativeUrl = "virtual_accounts";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (VirtualAccount)entities[0];
        }

        public VirtualAccount Edit(Dictionary<string, object> data = null) 
        {
            string relativeUrl = string.Format("virtual_accounts/{0}", this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Patch, data);
            return (VirtualAccount)entities[0];
        }

        public VirtualAccount Close() 
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("status", "closed");
            return Edit(data);
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