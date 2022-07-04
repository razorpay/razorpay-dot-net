using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razorpay.Api
{
    public class QrCode : Entity
    {
        string Url = "";
        public QrCode()
        {

            Url = "payments";
        }
        new public QrCode Fetch(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                string message = "id is null";
                throw new ArgumentNullException(message);
            }

            
            string relativeUrl = Url + "/qr_codes/" + id;
            List<Entity> entitiesList = Request(relativeUrl, HttpMethod.Get, null);
            return (QrCode)entitiesList[0];

            
        }
        public QrCode Create(Dictionary<string, object> attributes)
        {
            string relativeUrl = Url + "/qr_codes";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, attributes);
            return (QrCode)entities[0];
        }
        public QrCode Close(string id)
        {
            string relativeUrl = Url + "/qr_codes/" + id + "/Close";
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, null);
            return (QrCode)entities[0];
        }
        public List<QrCode> fetchAll()
        {
            return fetchAll(null);
        }
        public List<QrCode> fetchAll(Dictionary<string, object> attributes)
        {
            string relativeUrl = Url + "/qr_codes/" + QueryString(attributes);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Get, null);
            List<QrCode> QrCode = new List<QrCode>();
            foreach (Entity entity in entities)
            {
                QrCode.Add(entity as QrCode);
            }
            return QrCode;
        }
        public List<QrCode> fetchAllPayments(string id)
        {
            return fetchAllPayments(id, null);
        }
        public List<QrCode> fetchAllPayments(string id, Dictionary<string, object> attributes)
        {
            string relativeUrl = Url + "/qr_codes/" + id + "/" + Url + QueryString(attributes);
            List<Entity> entities = Request(relativeUrl, HttpMethod.Post, null);
            List<QrCode> QrCode = new List<QrCode>();
            foreach (Entity entity in entities)
            {
                QrCode.Add(entity as QrCode);
            }
            return QrCode;

        }
    }
}
