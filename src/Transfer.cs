using System.Collections.Generic;
using System;

namespace Razorpay.Api
{
    public class Transfer : Entity
    {
        new public Transfer Fetch(string id)
        {
            return (Transfer)base.Fetch(id);
        }

        public Transfer Edit(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}", GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Patch, options);   
            return (Transfer)entities[0];
        }

        public Transfer Create(Dictionary<string, object> options = null)
        {
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, options);
            return (Transfer)entities[0];
        }

        public Reversal Reversal
        {
            get 
            {
                Reversal reversal = new Reversal();
                reversal.TransferId = this["id"].ToString();
                return reversal;
            }
        }
    }
}