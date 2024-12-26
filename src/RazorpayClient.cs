using System.Collections.Generic;

namespace Razorpay.Api
{
    public class RazorpayClient
    {
        const string CurrentVersion = "3.1.4";
        protected const string DefaultBaseUrl = "https://api.razorpay.com";
        public const string DefaultAuthUrl = "https://auth.razorpay.com";

        protected static List<Dictionary<string, string>> appsDetails = new List<Dictionary<string, string>>();
        protected static Dictionary<string, string> headers = new Dictionary<string, string>();

        private static string key = null;
        private static string secret = null;
        private static string baseUrl = null;
        private static string accessToken = null;
        private Payment payment = null;
        private Order order = null;
        private Refund refund = null;
        private Customer customer = null;
        private Invoice invoice = null;
        private Card card = null;
        private Transfer transfer = null;
        private Addon addon = null;
        private Plan plan = null;
        private Subscription subscription = null;
        private VirtualAccount virtualaccount = null;
        private BankTransfer banktransfer = null;
        private Token token = null;
        private FundAccount fundAccount = null;
        private Product product = null;
        private Iin iin = null;
        private QrCode qrcode = null;
        private PaymentLink paymentlink = null;
        private Settlement settlement = null;
        private Tnc tnc = null;
        private Item item = null;
        private Account account = null;
        private Stakeholder stakeholder = null;
        private Webhook webhook = null;
        private BankAccount bankaccount = null;
        private OAuthTokenClient oAuthTokenClient = null;
        private Method method = null;
        private Dispute dispute = null;

        public RazorpayClient(string accessToken)
        {
            RazorpayClient.AccessToken = accessToken;
        }

        public RazorpayClient(string key, string secret)
        {
            RazorpayClient.Key = key;
            RazorpayClient.Secret = secret;
        }


        public RazorpayClient(string baseUrl, string key, string secret)
        {
            RazorpayClient.BaseUrl = baseUrl;
            RazorpayClient.Key = key;
            RazorpayClient.Secret = secret;
        }

        public static string Key
        {
            get
            {
                return key;
            }
            private set
            {
                key = value;
            }
        }

        public static string Secret
        {
            get
            {
                return secret;
            }
            private set
            {
                secret = value;
            }
        }

        public static string BaseUrl
        {
            get
            {
                if (baseUrl == null)
                {
                    baseUrl = DefaultBaseUrl;
                }
                return baseUrl;
            }
            private set
            {
                baseUrl = value;
            }
        }

        public static string AccessToken
        {
            get
            {
                return accessToken;
            }
            private set
            {
                accessToken = value;
            }
        }

        public static List<Dictionary<string, string>> AppsDetails
        {
            get
            {
                return appsDetails;
            }
        }

        public static Dictionary<string, string> Headers
        {
            get
            {
                return headers;
            }
        }

        public void setAppsDetails(string title, string version)
        {
            Dictionary<string, string> appDetail = new Dictionary<string, string>();
            appDetail.Add("title", title);
            appDetail.Add("version", version);

            appsDetails.Add(appDetail);
        }

        public void addHeader(string key, string value)
        {
            headers.Add(key, value);
        }

        public static string Version
        {
            get
            {
                return CurrentVersion;
            }
        }

        public Payment Payment
        {
            get
            {
                if (payment == null)
                {
                    payment = new Payment();
                }
                return payment;
            }
        }

        public Order Order
        {
            get
            {
                if (order == null)
                {
                    order = new Order();
                }
                return order;
            }
        }

        public Refund Refund
        {
            get
            {
                if (refund == null)
                {
                    refund = new Refund();
                }
                return refund;
            }
        }

        public Customer Customer
        {
            get
            {
                if (customer == null)
                {
                    customer = new Customer();
                }
                return customer;
            }
        }

        public Invoice Invoice
        {
            get
            {
                if (invoice == null)
                {
                    invoice = new Invoice();
                }
                return invoice;
            }
        }

        public Card Card
        {
            get
            {
                if (card == null)
                {
                    card = new Card();
                }
                return card;
            }
        }

        public Transfer Transfer
        {
            get
            {
                if (transfer == null)
                {
                    transfer = new Transfer();
                }
                return transfer;
            }
        }

        public Addon Addon
        {
            get
            {
                if (addon == null)
                {
                    addon = new Addon();
                }
                return addon;
            }
        }

        public Plan Plan
        {
            get
            {
                if (plan == null)
                {
                    plan = new Plan();
                }
                return plan;
            }
        }

        public Subscription Subscription
        {
            get
            {
                if (subscription == null)
                {
                    subscription = new Subscription();
                }
                return subscription;
            }
        }

        public VirtualAccount VirtualAccount
        {
            get
            {
                if (virtualaccount == null)
                {
                    virtualaccount = new VirtualAccount();
                }
                return virtualaccount;
            }
        }
        
        public BankTransfer BankTransfer
        {
            get
            {
                if (banktransfer == null)
                {
                    banktransfer = new BankTransfer();
                }
                return banktransfer;
            }
        }

        public Token Token
        {
            get
            {
                if (token == null)
                {
                    token = new Token();
                }
                return token;
            }
       }

        public FundAccount FundAccount
        {
            get
            {
                if (fundAccount == null)
                {
                    fundAccount = new FundAccount();
                }
                return fundAccount;
            }
        }

        public Product Product
        {
            get
            {
                if (product == null)
                {
                    product = new Product();
                }
                return product;
            }
        }

        public Iin Iin
        {
            get
            {
                if (iin == null)
                {
                    iin = new Iin();
                }
                return iin;
            }
        }

        public QrCode QrCode
        {
            get
            {
                if (qrcode == null)
                {
                    qrcode = new QrCode();
                }
                return qrcode;
            }
        }

        public PaymentLink PaymentLink
        {
            get
            {
                if (paymentlink == null)
                {
                    paymentlink = new PaymentLink();
                }
                return paymentlink;
            }
        }

        public Settlement Settlement
        {
            get
            {
                if (settlement == null)
                {
                    settlement = new Settlement();
                }
                return settlement;
            }
        }

        public Tnc Tnc
        {
            get
            {
                if (tnc == null)
                {
                    tnc = new Tnc();
                }
                return tnc;
            }
        }

        public Item Item
        {
            get
            {
                if (item == null)
                {
                    item = new Item();
                }
                return item;
            }
        }  

        public Account Account
        {
            get
            {
                if (account == null)
                {
                    account = new Account();
                }
                return account;
            }
        } 

        public Stakeholder Stakeholder
        {
            get
            {
                if (stakeholder == null)
                {
                    stakeholder = new Stakeholder();
                }
                return stakeholder;
            }
        } 

        public Webhook Webhook
        {
            get
            {
                if (webhook == null)
                {
                    webhook = new Webhook();
                }
                return webhook;
            }
        }
        
        public OAuthTokenClient OAuthTokenClient
        {
            get
            {
                if (oAuthTokenClient == null)
                {
                    oAuthTokenClient = new OAuthTokenClient();
                }
                return oAuthTokenClient;
            }
        }

        public Method Method
        {
            get
            {
                if (method == null)
                {
                    method = new Method();
                }
                return method;
            }
        }   

        public Dispute Dispute
        {
            get
            {
                if (dispute == null)
                {
                    dispute = new Dispute();
                }
                return dispute;
            }
        }  

        public BankAccount BankAccount
        {
            get
            {
                if (bankaccount == null)
                {
                    bankaccount = new BankAccount();
                }
                return bankaccount;
            }
        }
    }
}
