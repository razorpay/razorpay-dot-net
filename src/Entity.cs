using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Razorpay.Api
{
    public class Entity
    {
        public dynamic Attributes = new Dictionary<string, object>();
        private RestClient client;
        private static Dictionary<string, string> Entities = new Dictionary<string, string>()
        {
            {"payment", "Razorpay.Api.Payment"},
            {"refund", "Razorpay.Api.Refund"},
            {"order", "Razorpay.Api.Order"},
            {"customer", "Razorpay.Api.Customer"},
            {"invoice", "Razorpay.Api.Invoice"},
            {"token", "Razorpay.Api.Token"},
            {"card", "Razorpay.Api.Card"},
            {"transfer", "Razorpay.Api.Transfer"},
            {"reversal", "Razorpay.Api.Reversal"},
            {"plan", "Razorpay.Api.Plan"},
            {"subscription", "Razorpay.Api.Subscription"},
            {"virtual_account", "Razorpay.Api.VirtualAccount"},
            {"addon", "Razorpay.Api.Addon"},
            {"tnc_map", "Razorpay.Api.Tnc"},
            {"stakeholder", "Razorpay.Api.Stakeholder"},
            {"webhook", "Razorpay.Api.Webhook"},
        };
      
        private static List<HttpMethod> JsonifyInput = new List<HttpMethod>()
        {
            HttpMethod.POST, HttpMethod.PUT, HttpMethod.PATCH
        };

        protected Entity Fetch(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                string message = "id is null";
                throw new ArgumentNullException(message);
            }

            string entityUrl = GetEntityUrl();
            string versionUrl = GetUrlVersion();
            string relativeUrl = string.Format("{0}/{1}/{2}", versionUrl, entityUrl, id);
            List<Entity> entitiesList = Request(relativeUrl, HttpMethod.GET, null);
            return entitiesList[0];
        }

        protected List<Entity> All(Dictionary<string, object> options = null)
        {
            string entityUrl = GetEntityUrl();
            string versionUrl = GetUrlVersion();
            string relativeUrl = string.Format("{0}/{1}", versionUrl, entityUrl);
            return Request(relativeUrl, HttpMethod.GET, options);
        }

        protected List<Entity> Request(string relativeUrl, HttpMethod verb, Dictionary<string, object> options)
        {
            client = new RestClient();
            string postData = string.Empty;

            if ((verb == HttpMethod.GET) && (options != null))
            {
                string queryString = QueryString(options);

                relativeUrl = relativeUrl + "?" + queryString;
            }
            else if (JsonifyInput.Contains(verb) == true)
            {
                postData = JsonConvert.SerializeObject(options);
            }

            string responseStr = client.MakeRequest(relativeUrl, verb, postData);

            dynamic response = JsonConvert.DeserializeObject(responseStr);

            if (verb == HttpMethod.DELETE)
            {
                string type = Entities[this.GetType().Name.ToLower().ToString()];
                Entity entity = (Entity)FormatterServices.GetUninitializedObject(Type.GetType(type));
                entity.Attributes = response;
                List<Entity> en = new List<Entity>() { entity };
                return en;
            }

            List<Entity> entities = Build(response);

            return entities;
        }

        protected static string QueryString(IDictionary<string, object> dict)
        {
            var list = new List<string>();
            foreach (var item in dict)
            {
                string param = string.Format("{0}={1}", item.Key, item.Value);
                list.Add(param);
            }

            return string.Join("&", list);
        }

        private List<Entity> Build(dynamic response)
        {
            List<Entity> entities = new List<Entity>();

            if (response["entity"] == "collection")
            {
                foreach (dynamic item in response["items"])
                {
                    entities.Add(ParseEntity(item));
                }
            }
            else
            {
                entities.Add(ParseEntity(response));
            }

            return entities;
        }

        // iF HttpMethod = delete, return
        private Entity ParseEntity(dynamic response)
        {
            Entity entity;
            string responseEntity;

            if (!response.ContainsKey("entity"))
            {
                responseEntity = this.GetType().Name.ToLower();
            }
            else
            {
                responseEntity = (string)response["entity"];
            }

            if (Entities.ContainsKey(responseEntity) == true)
            {
                string type = Entities[responseEntity];

                entity = (Entity)FormatterServices.GetUninitializedObject(Type.GetType(type));
            }
            else
            {
                entity = new Entity();
            }
            entity.Attributes = response;

            return entity;
        }

        protected string GetEntityUrl()
        {
            return this.GetType().Name.ToLower() + "s";
        }

        protected string GetUrlVersion(string version = "v1")
        {
            return String.Format("/{0}", version);
        }

        public dynamic this[string key]
        {
            get
            {
                return Attributes[key];
            }
            set
            {
                Attributes[key] = value;
            }
        }
    }
}