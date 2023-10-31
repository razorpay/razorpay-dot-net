using System;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class PaymentLink : Entity
    {
        new public PaymentLink Fetch(string id)
        {
            string relativeUrl = string.Format("{0}/payment_links/{1}", GetUrlVersion(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (PaymentLink)entities[0];
        }

        public PaymentLink Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/payment_links", GetUrlVersion());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (PaymentLink)entities[0];
        }

        public PaymentLink All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/payment_links", GetUrlVersion());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            return (PaymentLink)entities[0];
        }

        public PaymentLink Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/payment_links/{1}", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (PaymentLink)entities[0];
        }

        public PaymentLink Cancel()
        {
            string relativeUrl = string.Format("{0}/payment_links/{1}/cancel", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            return (PaymentLink)entities[0];
        }

        public PaymentLink NotifyBy(string medium)
        {
            string relativeUrl = string.Format("{0}/payment_links/{1}/notify_by/{2}", GetUrlVersion(), this["id"] , medium);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            return (PaymentLink)entities[0];
        }
    }
}