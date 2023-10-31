using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Card : Entity
    {
        new public Card Fetch(string id)
        {
            return (Card)base.Fetch(id);
        }

        public Card FetchCardDetails(string id)
        {
            string relativeUrl = string.Format("{0}/payments/{1}/card", GetUrlVersion(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Card)entities[0];
        }

        public Card RequestCardReference(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/fingerprints", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Card)entities[0];
        }
    }
}