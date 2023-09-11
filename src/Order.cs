using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Order : Entity
    {
        public Order Fetch(string id, Dictionary<string, object> options=null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            return (Order)entities[0];
        }

        new public List<Order> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Order> orders = new List<Order>();
            foreach (Entity entity in entities)
            {
                orders.Add(entity as Order);
            }
            return orders;
        }

        public Order Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Order)entities[0];
        }

        public List<Payment> Payments()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/payments", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);

            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }

            return payments;
        }

        public Order Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Order)entities[0];
        }
    }
}