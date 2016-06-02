using System.Collections.Generic;
using System.Net.Http;

namespace Razorpay.Api
{
    public class Order : Entity
    {
        new public Order Fetch(string id)
        {
            return (Order)base.Fetch(id);
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
            string relativeUrl = GetEntityUrl();
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, data);
            return (Order)entities[0];
        }

        public List<Payment> Payments()
        {
            string relativeUrl = GetEntityUrl() + "/" + this["id"] + "/payments";
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