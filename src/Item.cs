using System;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Item : Entity
    {
        new public Item Fetch(string id)
        {
            return (Item)base.Fetch(id);
        }

        public Item Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Item)entities[0];
        }

        public List<Item> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Item> items = new List<Item>();
            foreach (Entity entity in entities)
            {
                items.Add(entity as Item);
            }
            return items;
        }

        public Item Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            return (Item)entities[0];
        }

        public List<Item> Delete()
        {
            string relativeUrl = string.Format("{0}/items/{1}", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.DELETE, null);
            List<Item> items = new List<Item>();
            foreach (Entity entity in entities)
            {
                items.Add(entity as Item);
            }
            return items;
        }
    }
}