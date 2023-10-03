using System;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class FundAccount : Entity
    {
        new public FundAccount Fetch(string id)
        {
            string relativeUrl = string.Format("{0}/fund_accounts/{1}", GetUrlVersion(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (FundAccount)entities[0];
        }

        public FundAccount Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/fund_accounts", GetUrlVersion());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (FundAccount)entities[0];
        }

        public List<FundAccount> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/fund_accounts", GetUrlVersion());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            List<FundAccount> fundaccounts = new List<FundAccount>();
            foreach (Entity entity in entities)
            {
                fundaccounts.Add(entity as FundAccount);
            }
            return fundaccounts;
        }
    }
}