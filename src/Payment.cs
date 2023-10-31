using System.Collections.Generic;

namespace Razorpay.Api
{
    public class Payment : Entity
    {
        public Payment(string paymentId = "")
        {
            this["id"] = paymentId;
        }

        new public Payment Fetch(string id)
        {
            return (Payment)base.Fetch(id);
        }

        new public List<Payment> All(Dictionary<string, object> options = null)
        {
            List<Entity> entities = base.All(options);
            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }
            return payments;
        }

        public Payment Capture(Dictionary<string, object> attributes)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/capture", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, attributes);
            return (Payment)entities[0];
        }

        public Refund Refund(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/refund", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            return (Refund)entities[0];
        }

        public Refund FetchRefund(string refundId)
        {
            string relativeUrl = string.Format("{0}/payments/{1}/refunds/{2}", GetUrlVersion(), this["id"], refundId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (Refund)entities[0];
        }

        public List<Refund> AllRefunds(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/payments/{1}/refunds", GetUrlVersion(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, data);
            List<Refund> refunds = new List<Refund>();
            foreach (Entity entity in entities)
            {
                refunds.Add(entity as Refund);
            }
            return refunds;
        }

        public List<Transfer> Transfer(Dictionary<string, object> data = null)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/transfers", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);

            // Todo: Make a utility method or something to DRY below for-each thing from across this sdk.
            List<Transfer> transfers = new List<Transfer>();
            foreach(Entity entity in entities)
            {
                transfers.Add(entity as Transfer);
            }

            return transfers;
        }

        public BankTransfer BankTransfers()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/bank_transfer", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            return (BankTransfer)entities[0];
        }

        public List<Transfer> Transfers()
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/transfers", GetUrlVersion(), GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);

            List<Transfer> transfers = new List<Transfer>();

            foreach(Entity entity in entities)
            {
                transfers.Add(entity as Transfer);
            }

            return transfers;
        }

        public Payment Edit(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/", GetUrlVersion(),  GetEntityUrl(), this["id"]);
            List<Entity> entities = Request(relativeUrl, HttpMethod.PATCH, data);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public List<Payment> FetchPaymentDowntime()
        {
            string relativeUrl = string.Format("{0}/{1}/downtimes", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            List<Payment> payments = new List<Payment>();
            foreach (Entity entity in entities)
            {
                payments.Add(entity as Payment);
            }
            return payments;
        }

        public Payment FetchPaymentDowntimeById(string downtimeId)
        {
            string relativeUrl = string.Format("{0}/{1}/downtimes/{2}", GetUrlVersion(), GetEntityUrl(), downtimeId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.GET, null);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Payment CreateJsonPayment(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/create/json", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Payment CreateRecurringPayment(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/create/recurring", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Payment OtpGenerate(string paymentId)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/otp_generate", GetUrlVersion(), GetEntityUrl(), paymentId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Payment OtpResend(string paymentId)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/otp/resend", GetUrlVersion(), GetEntityUrl(), paymentId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, null);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Payment OtpSubmit(string paymentId, Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/{2}/otp/submit", GetUrlVersion(), GetEntityUrl(), paymentId);
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Payment CreateUpi(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/create/upi", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }

        public Payment ValidateUpi(Dictionary<string, object> data)
        {
            string relativeUrl = string.Format("{0}/{1}/validate/vpa", GetUrlVersion(), GetEntityUrl());
            List<Entity> entities = Request(relativeUrl, HttpMethod.POST, data);
            if (entities != null && entities.Count > 0)
            {
                return (Payment)entities[0];
            }
            else
            {
                return null;
            }
        }
    }
}

