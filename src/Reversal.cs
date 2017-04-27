using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Reversal : Entity
    {
        public string TransferId;

        public Reversal(string transferId)
        {
            TransferId = transferId;
        }

        public Reversal Create(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("transfers/{0}/{1}", this.TransferId, GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, options);
            return (Reversal)entities[0];
        }
    }
}