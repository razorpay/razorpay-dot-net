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
            string relativeUrl = string.Format("{0}/virtual_accounts/{1}", GetUrlVersion(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            if (entities != null && entities.Count > 0)
            {
                return (VirtualAccount)entities[0];
            }
            else
            {
                return null;
            }
        }

        new public List<VirtualAccount> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/virtual_accounts", GetUrlVersion());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);

            List<VirtualAccount> virtualaccounts = new List<VirtualAccount>();
            
            foreach (Entity entity in entities)
            {
                virtualaccounts.Add(entity as VirtualAccount);
            }
            return virtualaccounts;
        }

        public VirtualAccount Create(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/virtual_accounts", GetUrlVersion());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (VirtualAccount)entities[0];
            }
            else
            {
                return null;
            }
        }

        public VirtualAccount Edit(Dictionary<string, object> data = null) 
        {
            string relativeUrl = string.Format("{0}/virtual_accounts/{1}", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            if (entities != null && entities.Count > 0)
            {
                return (VirtualAccount)entities[0];
            }
            else
            {
                return null;
            }
        }

        public VirtualAccount Close() 
        {
            string relativeUrl = string.Format("{0}/virtual_accounts/{1}/close", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            if (entities != null && entities.Count > 0)
            {
                return (VirtualAccount)entities[0];
            }
            else
            {
                return null;
            }
        }

        public List<Payment> Payments(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/virtual_accounts/{1}/payments", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);

            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }
            return payments;
        }

        public VirtualAccount AddReceiver(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/virtual_accounts/{1}/receivers", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (VirtualAccount)entities[0];
            }
            else
            {
                return null;
            }
        }

        public VirtualAccount AddAllowedPayers(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/virtual_accounts/{1}/allowed_payers", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (VirtualAccount)entities[0];
            }
            else
            {
                return null;
            }
        }
    }
}
