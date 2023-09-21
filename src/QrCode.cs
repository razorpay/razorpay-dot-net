using System;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class QrCode : Entity
    {
        public string QrCodeUrl(string qrcode_url= "payments/qr_codes")
        {  
            return qrcode_url;
        }

        new public QrCode Fetch(string id)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}", GetUrlVersion(), QrCodeUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (QrCode)entities[0];
        }

        public QrCode Create(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), QrCodeUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (QrCode)entities[0];
        }

        public List<QrCode> All(Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}", GetUrlVersion(), QrCodeUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            List<QrCode> qrcodes = new List<QrCode>();
            foreach (Entity entity in entities)
            {
                qrcodes.Add(entity as QrCode);
            }
            return qrcodes;
        }

        public List<Payment> FetchAllPayments(string id, Dictionary<string, object> options = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/payments", GetUrlVersion(), QrCodeUrl(), id);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, options);
            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }
            return payments;
        }

        public QrCode Close()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/close", GetUrlVersion(), QrCodeUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            return (QrCode)entities[0];
        }

    }
}