namespace Razorpay.Tests.Fixtures
{
    public static class TestFixtures
    {
        public static class Orders
        {
            public const string OrderId = "order_DBJOWzybf0sJbb";

            public static string SingleOrder => $@"{{
                ""id"": ""{OrderId}"",
                ""entity"": ""order"",
                ""amount"": 50000,
                ""amount_paid"": 0,
                ""amount_due"": 50000,
                ""currency"": ""INR"",
                ""receipt"": ""receipt#1"",
                ""status"": ""created"",
                ""attempts"": 0,
                ""notes"": [],
                ""created_at"": 1566986570
            }}";

            public static string OrderCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleOrder}]
            }}";

            public static string OrderWithPayments => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{{
                    ""id"": ""pay_DGR998PPmjTCPH"",
                    ""entity"": ""payment"",
                    ""amount"": 50000,
                    ""currency"": ""INR"",
                    ""status"": ""captured"",
                    ""order_id"": ""{OrderId}"",
                    ""method"": ""card""
                }}]
            }}";
        }

        public static class Payments
        {
            public const string PaymentId = "pay_DGR998PPmjTCPH";

            public static string SinglePayment => $@"{{
                ""id"": ""{PaymentId}"",
                ""entity"": ""payment"",
                ""amount"": 50000,
                ""currency"": ""INR"",
                ""status"": ""captured"",
                ""order_id"": ""order_DBJOWzybf0sJbb"",
                ""method"": ""card"",
                ""description"": ""Test payment"",
                ""bank"": null,
                ""wallet"": null,
                ""vpa"": null,
                ""email"": ""test@example.com"",
                ""contact"": ""+919876543210"",
                ""fee"": 1000,
                ""tax"": 0,
                ""captured"": true,
                ""notes"": {{}},
                ""created_at"": 1606985209
            }}";

            public static string PaymentCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SinglePayment}]
            }}";

            public static string CapturedPayment => $@"{{
                ""id"": ""{PaymentId}"",
                ""entity"": ""payment"",
                ""amount"": 50000,
                ""currency"": ""INR"",
                ""status"": ""captured"",
                ""captured"": true
            }}";
        }

        public static class Refunds
        {
            public const string RefundId = "rfnd_FP8QHiV938haTz";

            public static string SingleRefund => $@"{{
                ""id"": ""{RefundId}"",
                ""entity"": ""refund"",
                ""amount"": 50000,
                ""currency"": ""INR"",
                ""payment_id"": ""pay_DGR998PPmjTCPH"",
                ""notes"": {{}},
                ""receipt"": null,
                ""acquirer_data"": {{}},
                ""created_at"": 1597078124,
                ""status"": ""processed"",
                ""speed_processed"": ""normal"",
                ""speed_requested"": ""normal""
            }}";

            public static string RefundCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleRefund}]
            }}";
        }

        public static class Customers
        {
            public const string CustomerId = "cust_1Aa00000000003";

            public static string SingleCustomer => $@"{{
                ""id"": ""{CustomerId}"",
                ""entity"": ""customer"",
                ""name"": ""Test Customer"",
                ""email"": ""test@example.com"",
                ""contact"": ""9876543210"",
                ""gstin"": null,
                ""notes"": {{}},
                ""created_at"": 1234567890
            }}";

            public static string CustomerCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleCustomer}]
            }}";
        }

        public static class Invoices
        {
            public const string InvoiceId = "inv_DBa1yWB0nP4xfC";

            public static string SingleInvoice => $@"{{
                ""id"": ""{InvoiceId}"",
                ""entity"": ""invoice"",
                ""type"": ""invoice"",
                ""receipt"": null,
                ""invoice_number"": null,
                ""customer_id"": ""cust_1Aa00000000003"",
                ""customer_details"": {{
                    ""id"": ""cust_1Aa00000000003"",
                    ""name"": ""Test"",
                    ""email"": ""test@example.com"",
                    ""contact"": ""9876543210""
                }},
                ""order_id"": ""order_DBJOWzybf0sJbb"",
                ""line_items"": [],
                ""payment_id"": null,
                ""status"": ""issued"",
                ""expire_by"": null,
                ""issued_at"": 1595491014,
                ""paid_at"": null,
                ""cancelled_at"": null,
                ""expired_at"": null,
                ""sms_status"": ""pending"",
                ""email_status"": ""pending"",
                ""amount"": 100,
                ""gross_amount"": 100,
                ""tax_amount"": 0,
                ""currency"": ""INR"",
                ""created_at"": 1595491014
            }}";

            public static string InvoiceCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleInvoice}]
            }}";
        }

        public static class Plans
        {
            public const string PlanId = "plan_DBJOdP3GGRaq6g";

            public static string SinglePlan => $@"{{
                ""id"": ""{PlanId}"",
                ""entity"": ""plan"",
                ""interval"": 1,
                ""period"": ""monthly"",
                ""item"": {{
                    ""id"": ""item_7Oy8OMV6BdEAac"",
                    ""active"": true,
                    ""amount"": 99900,
                    ""unit_amount"": 99900,
                    ""currency"": ""INR"",
                    ""name"": ""Test plan"",
                    ""description"": ""Description for test plan"",
                    ""unit"": null
                }},
                ""notes"": {{}},
                ""created_at"": 1580219019
            }}";

            public static string PlanCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SinglePlan}]
            }}";
        }

        public static class Subscriptions
        {
            public const string SubscriptionId = "sub_DBJOemMQqnGoxW";

            public static string SingleSubscription => $@"{{
                ""id"": ""{SubscriptionId}"",
                ""entity"": ""subscription"",
                ""plan_id"": ""plan_DBJOdP3GGRaq6g"",
                ""customer_id"": ""cust_1Aa00000000003"",
                ""status"": ""active"",
                ""current_start"": 1577385991,
                ""current_end"": 1580064391,
                ""ended_at"": null,
                ""quantity"": 1,
                ""notes"": {{}},
                ""charge_at"": 1577385991,
                ""offer_id"": null,
                ""short_url"": ""https://rzp.io/i/m0y0f"",
                ""has_scheduled_changes"": false,
                ""change_scheduled_at"": null,
                ""source"": ""api"",
                ""payment_method"": ""card"",
                ""created_at"": 1577385991
            }}";

            public static string SubscriptionCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleSubscription}]
            }}";
        }

        public static class Transfers
        {
            public const string TransferId = "trf_DGSTeXzHkqVsmC";

            public static string SingleTransfer => $@"{{
                ""id"": ""{TransferId}"",
                ""entity"": ""transfer"",
                ""source"": ""pay_DGR998PPmjTCPH"",
                ""recipient"": ""acc_CMaomTz4o0FOFz"",
                ""amount"": 1000,
                ""currency"": ""INR"",
                ""amount_reversed"": 0,
                ""notes"": {{}},
                ""on_hold"": false,
                ""on_hold_until"": null,
                ""recipient_settlement_id"": null,
                ""created_at"": 1596771429,
                ""linked_account_notes"": [],
                ""processed_at"": 1596771429
            }}";

            public static string TransferCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleTransfer}]
            }}";
        }

        public static class VirtualAccounts
        {
            public const string VirtualAccountId = "va_Di5gbNptcWV8fQ";

            public static string SingleVirtualAccount => $@"{{
                ""id"": ""{VirtualAccountId}"",
                ""name"": ""Test Virtual Account"",
                ""entity"": ""virtual_account"",
                ""status"": ""active"",
                ""description"": ""Virtual Account for testing"",
                ""amount_expected"": null,
                ""notes"": {{}},
                ""amount_paid"": 0,
                ""customer_id"": ""cust_1Aa00000000003"",
                ""receivers"": [],
                ""close_by"": 1881615838,
                ""closed_at"": null,
                ""close_reason"": null,
                ""created_at"": 1574837626
            }}";

            public static string VirtualAccountCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleVirtualAccount}]
            }}";
        }

        public static class Items
        {
            public const string ItemId = "item_JnjKnSKjYCPkAe";

            public static string SingleItem => $@"{{
                ""id"": ""{ItemId}"",
                ""active"": true,
                ""amount"": 100,
                ""unit_amount"": 100,
                ""currency"": ""INR"",
                ""name"": ""Test item"",
                ""description"": ""Test item description"",
                ""unit"": null,
                ""hsn_code"": null,
                ""sac_code"": null,
                ""tax_inclusive"": false,
                ""tax_id"": null,
                ""tax_group_id"": null,
                ""created_at"": 1656597363
            }}";

            public static string ItemCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleItem}]
            }}";
        }

        public static class QrCodes
        {
            public const string QrCodeId = "qr_HMsVL8HOpbMcjU";

            public static string SingleQrCode => $@"{{
                ""id"": ""{QrCodeId}"",
                ""entity"": ""qr_code"",
                ""created_at"": 1623914648,
                ""name"": ""Test QR code"",
                ""usage"": ""single_use"",
                ""type"": ""upi_qr"",
                ""image_url"": ""https://rzp.io/i/test"",
                ""payment_amount"": 300,
                ""status"": ""active"",
                ""description"": ""Test QR"",
                ""fixed_amount"": true,
                ""payments_amount_received"": 0,
                ""payments_count_received"": 0,
                ""notes"": [],
                ""customer_id"": ""cust_1Aa00000000003"",
                ""close_by"": 1681615838
            }}";

            public static string QrCodeCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleQrCode}]
            }}";
        }

        public static class PaymentLinks
        {
            public const string PaymentLinkId = "plink_ExjpAUN3gVHrPJ";

            public static string SinglePaymentLink => $@"{{
                ""id"": ""{PaymentLinkId}"",
                ""entity"": ""payment_link"",
                ""accept_partial"": true,
                ""amount"": 1000,
                ""amount_paid"": 0,
                ""callback_method"": """",
                ""callback_url"": """",
                ""cancelled_at"": null,
                ""created_at"": 1591097057,
                ""currency"": ""INR"",
                ""customer"": {{}},
                ""description"": ""Test Payment Link"",
                ""expire_by"": null,
                ""expired_at"": null,
                ""first_min_partial_amount"": 100,
                ""name"": ""Test"",
                ""notes"": null,
                ""notify"": {{}},
                ""payments"": null,
                ""reference_id"": ""testref"",
                ""reminder_enable"": true,
                ""reminders"": [],
                ""short_url"": ""https://rzp.io/i/test"",
                ""status"": ""created"",
                ""updated_at"": 1591097057
            }}";

            public static string PaymentLinkCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SinglePaymentLink}]
            }}";
        }

        public static class Settlements
        {
            public const string SettlementId = "setl_DGSTeXzHkqVsmC";

            public static string SingleSettlement => $@"{{
                ""id"": ""{SettlementId}"",
                ""entity"": ""settlement"",
                ""amount"": 9999,
                ""status"": ""processed"",
                ""fees"": 23,
                ""tax"": 0,
                ""utr"": ""110011001100110""
            }}";

            public static string SettlementCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleSettlement}]
            }}";
        }

        public static class Addons
        {
            public const string AddonId = "ao_00000000000001";

            public static string SingleAddon => $@"{{
                ""id"": ""{AddonId}"",
                ""entity"": ""addon"",
                ""created_at"": 1495097859,
                ""subscription_id"": ""sub_DBJOemMQqnGoxW"",
                ""item"": {{
                    ""id"": ""item_00000000000001"",
                    ""active"": true,
                    ""amount"": 300,
                    ""unit_amount"": 300,
                    ""currency"": ""INR"",
                    ""name"": ""Test addon"",
                    ""description"": ""Test addon description""
                }},
                ""quantity"": 2,
                ""invoiced_at"": null,
                ""invoice_id"": null
            }}";

            public static string AddonCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleAddon}]
            }}";
        }

        public static class FundAccounts
        {
            public const string FundAccountId = "fa_100000000000fa";

            public static string SingleFundAccount => $@"{{
                ""id"": ""{FundAccountId}"",
                ""entity"": ""fund_account"",
                ""contact_id"": ""cont_1234567890"",
                ""account_type"": ""bank_account"",
                ""bank_account"": {{
                    ""ifsc"": ""HDFC0000053"",
                    ""bank_name"": ""HDFC Bank"",
                    ""name"": ""Test Account"",
                    ""notes"": [],
                    ""account_number"": ""1234567890123456789""
                }},
                ""active"": true,
                ""created_at"": 1543650891
            }}";

            public static string FundAccountCollection => $@"{{
                ""entity"": ""collection"",
                ""count"": 1,
                ""items"": [{SingleFundAccount}]
            }}";
        }

        public static class Errors
        {
            public static string BadRequest(string description, string field = null) => $@"{{
                ""error"": {{
                    ""code"": ""BAD_REQUEST_ERROR"",
                    ""description"": ""{description}"",
                    ""field"": {(field != null ? $"\"{field}\"" : "null")}
                }}
            }}";

            public static string ServerError => @"{
                ""error"": {
                    ""code"": ""SERVER_ERROR"",
                    ""description"": ""Internal server error"",
                    ""field"": null
                }
            }";

            public static string GatewayError => @"{
                ""error"": {
                    ""code"": ""GATEWAY_ERROR"",
                    ""description"": ""Gateway timeout"",
                    ""field"": null
                }
            }";
        }
    }
}
