using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Token : Entity
    {
        new public Token Fetch(string id)
        {
            return (Token)base.Fetch(id);
        }

        new public List<Token> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Token> tokens = new List<Token>();

            foreach(Entity entity in entities)
            {
                tokens.Add(entity as Token);
            }

            return tokens;
        }
    }
}