using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Card : Entity
    {
        new public Card Fetch(string id)
        {
            return (Card)base.Fetch(id);
        }

        new public List<Card> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Card> cards = new List<Card>();
            foreach (Entity entity in entities)
            {
                cards.Add(entity as Card);
            }
            return cards;
        }
    }
}
