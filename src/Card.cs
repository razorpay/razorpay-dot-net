namespace Razorpay.Api
{
    public class Card : Entity
    {
        new public Card Fetch(string id)
        {
            return (Card)base.Fetch(id);
        }
    }
}