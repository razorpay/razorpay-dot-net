## Register nach and charge first payment together

### Create customer
```C#
Dictionary<string, object> customerRequest = new Dictionary<string, object>();
customerRequest.Add("name", "Gaurav Kumar");
customerRequest.Add("contact", "9123456780");
customerRequest.Add("email", "gaurav.kumar@example.com");
customerRequest.Add("fail_existing", "0");
customerRequest.Add("gstin", "29XAbbA4369J1PA");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
customerRequest.Add("notes", notes);

Customer customer = client.Customer.Create(customerRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| name*          | string      | Name of the customer                        |
| email        | string      | Email of the customer                       |
| contact      | string      | Contact number of the customer              |
| fail_existing | string | If a customer with the same details already exists, the request throws an exception by default. Possible value is `0` or `1`|
| notes         | object      | A key-value pair                            |

**Response:**
```json
{
  "id": "cust_1Aa00000000003",
  "entity": "customer",
  "name": "Gaurav Kumar",
  "email": "Gaurav.Kumar@example.com",
  "contact": "9000000000",
  "gstin": null,
  "notes": {
    "notes_key_1": "Tea, Earl Grey, Hot",
    "notes_key_2": "Tea, Earl Grey… decaf."
  },
  "created_at": 1582033731
}
```
-------------------------------------------------------------------------------------------------------

### Create Order

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("amount", 0);
orderRequest.Add("currency", "INR");
orderRequest.Add("customer_id", "cust_JDdNazagOgg9Ig");
orderRequest.Add("method", "nach");
orderRequest.Add("receipt", "receipt#1");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1","Tea, Earl Grey, Hot");
notes.Add("notes_key_2","Tea, Earl Grey… decaf.");
orderRequest.Add("notes", notes);
Dictionary<string, object> token = new Dictionary<string, object>();
token.Add("auth_type","physical");
token.Add("max_amount","10000000");
token.Add("expire_at","2709971120");
Dictionary<string, object> tokenNotes = new Dictionary<string, object>();
tokenNotes.Add("notes_key_1","Tea, Earl Grey, Hot");
tokenNotes.Add("notes_key_2","Tea, Earl Grey… decaf.");
token.Add("notes",tokenNotes);
orderRequest.Add("token", token);
Dictionary<string, object> bankAccount = new Dictionary<string, object>();
bankAccount.Add("beneficiary_name","Gaurav Kumar");
bankAccount.Add("account_number","11214311215411");
bankAccount.Add("account_type","savings");
bankAccount.Add("ifsc_code","HDFC0001233");
token.Add("bank_account",bankAccount);
Dictionary<string, object> nach = new Dictionary<string, object>();
nach.Add("form_reference1","Recurring Payment for Gaurav Kumar");
nach.Add("form_reference2","Method Paper NACH");
nach.Add("description","Paper NACH Gaurav Kumar");
token.Add("nach",nach);

Order order = client.Order.Create(orderRequest);
```

**Parameters:**


| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| amount*   | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |
| currency*   | string  | The currency of the payment (defaults to INR)  |
| customerId*   | string      | The id of the customer to be fetched |
| method*      | string  | Payment method used to make the registration transaction. Possible value is `nach`.  |
| token  | object  |  All parameters listed [here](https://razorpay.com/docs/api/payments/recurring-payments/paper-nach/auto-debit/#112-create-an-order) are supported |
| notes | object  | A key-value pair  |

**Response:**
```json
{
  "id":"order_1Aa00000000001",
  "entity":"order",
  "amount":0,
  "amount_paid":0,
  "amount_due":0,
  "currency":"INR",
  "receipt":"rcptid #10",
  "offer_id":null,
  "offers":{
    "entity":"collection",
    "count":0,
    "items":[]
  },
  "status":"created",
  "attempts":0,
  "notes": {
    "notes_key_1": "Beam me up Scotty",
    "notes_key_2": "Engage"
  },
  "created_at":1579775420,
  "token":{
    "method":"nach",
    "notes": {
      "notes_key_1": "Tea, Earl Grey, Hot",
      "notes_key_2": "Tea, Earl Grey… decaf."
    },
    "recurring_status":null,
    "failure_reason":null,
    "currency":"INR",
    "max_amount":10000000,
    "auth_type":"physical",
    "expire_at":1580480689,
    "nach":{
      "create_form":true,
      "form_reference1":"Recurring Payment for Gaurav Kumar",
      "form_reference2":"Method Paper NACH",
      "prefilled_form":"https://rzp.io/i/bitw",
      "upload_form_url":"https://rzp.io/i/gts",
      "description":"Paper NACH Gaurav Kumar"
    },
    "bank_account":{
      "ifsc":"HDFC0000001",
      "bank_name":"HDFC Bank",
      "name":"Gaurav Kumar",
      "account_number":"11214311215411",
      "account_type":"savings",
      "beneficiary_email":"gaurav.kumar@example.com",
      "beneficiary_mobile":"9876543210"
    },
    "first_payment_amount":10000
  }
}
```
-------------------------------------------------------------------------------------------------------

### Create an Authorization Payment

Please refer this [doc](https://razorpay.com/docs/api/recurring-payments/paper-nach/auto-debit/#113-create-an-authorization-payment) for authorization payment

-----------------------------------------------------------------------------------------------------

### Create registration link

```C#
Dictionary<string, object> registrationLinkRequest = new Dictionary<string, object>();
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("name","Gaurav Kumar");
customer.Add("email","gaurav.kumar@example.com");
customer.Add("contact","9123456780");
registrationLinkRequest.Add("customer", customer);
registrationLinkRequest.Add("type", "link");
registrationLinkRequest.Add("amount", 0);
registrationLinkRequest.Add("currency", "INR");
registrationLinkRequest.Add("description", "12 p.m. Meals");
Dictionary<string, object> subscriptionRegistration = new Dictionary<string, object>();
subscriptionRegistration.Add("method","nach");
subscriptionRegistration.Add("auth_type","physical");
subscriptionRegistration.Add("max_amount",50000);
subscriptionRegistration.Add("expire_at",1609423824);
Dictionary<string, object> bankAccount = new Dictionary<string, object>();
bankAccount.Add("beneficiary_name","Gaurav Kumar");
bankAccount.Add("account_number","11214311215411");
bankAccount.Add("account_type","savings");
bankAccount.Add("ifsc_code","HDFC0001233");
Dictionary<string, object> nach = new Dictionary<string, object>();
nach.Add("form_reference1","Recurring Payment for Gaurav Kumar");
nach.Add("form_reference2","Method Paper NACH");
subscriptionRegistration.Add("bank_account",bankAccount);
subscriptionRegistration.Add("nach",nach);
registrationLinkRequest.Add("subscription_registration", subscriptionRegistration);
registrationLinkRequest.Add("receipt", "Receipt No. #111");
registrationLinkRequest.Add("email_notify", 1);
registrationLinkRequest.Add("sms_notify", 1);
registrationLinkRequest.Add("expire_by", 1580479824);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1","Tea, Earl Grey, Hot");
notes.Add("notes_key_2","Tea, Earl Grey… decaf.");
registrationLinkRequest.Add("notes", notes);

Invoice invoice = client.Invoice.CreateRegistrationLink(registrationLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                   |
|-----------------|---------|---------------------------------------------------------------|
| customer   | object      | All parameters listed [here](https://razorpay.com/docs/api/payments/recurring-payments/paper-nach/auto-debit/#121-create-a-registration-link) are supported |
| type*  | object | the value is `link`. |
| amount*   | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |
| currency*   | string  | The currency of the payment (defaults to INR)  |
| description*  | string      | A brief description of the payment.   |
| subscription_registration           | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/recurring-payments/paper-nach/auto-debit/#121-create-a-registration-link) are supported |
| receipt      | string  | Your system order reference id.  |
| sms_notify  | boolean  | SMS notifications are to be sent by Razorpay (default : 1)  |
| email_notify | boolean  | Email notifications are to be sent by Razorpay (default : 1)  |
| expire_by    | integer | The timestamp, in Unix format, till when the customer can make the authorization payment. |
| notes | object  | A key-value pair  |

**Response:**
```json
{
    "id": "inv_FHrZiAubEzDdaq",
    "entity": "invoice",
    "receipt": "Receipt No. 27",
    "invoice_number": "Receipt No. 27",
    "customer_id": "cust_BMB3EwbqnqZ2EI",
    "customer_details": {
        "id": "cust_BMB3EwbqnqZ2EI",
        "name": "Gaurav Kumar",
        "email": "gaurav.kumar@example.com",
        "contact": "9123456780",
        "gstin": null,
        "billing_address": null,
        "shipping_address": null,
        "customer_name": "Gaurav Kumar",
        "customer_email": "gaurav.kumar@example.com",
        "customer_contact": "9123456780"
    },
    "order_id": "order_FHrZiBOkWHZPOp",
    "line_items": [],
    "payment_id": null,
    "status": "issued",
    "expire_by": 1647483647,
    "issued_at": 1595491154,
    "paid_at": null,
    "cancelled_at": null,
    "expired_at": null,
    "sms_status": "sent",
    "email_status": "sent",
    "date": 1595491154,
    "terms": null,
    "partial_payment": false,
    "gross_amount": 0,
    "tax_amount": 0,
    "taxable_amount": 0,
    "amount": 0,
    "amount_paid": 0,
    "amount_due": 0,
    "currency": "INR",
    "currency_symbol": "₹",
    "description": "12 p.m. Meals",
    "notes": {
        "note_key 1": "Beam me up Scotty",
        "note_key 2": "Tea. Earl Gray. Hot."
    },
    "comment": null,
    "short_url": "https://rzp.io/i/bzDYbNg",
    "view_less": true,
    "billing_start": null,
    "billing_end": null,
    "type": "link",
    "group_taxes_discounts": false,
    "created_at": 1595491154,
    "idempotency_key": null,
    "token": {
        "method": "nach",
        "notes": {
            "note_key 1": "Beam me up Scotty",
            "note_key 2": "Tea. Earl Gray. Hot."
        },
        "recurring_status": null,
        "failure_reason": null,
        "currency": "INR",
        "max_amount": 50000,
        "auth_type": "physical",
        "expire_at": 1947483647,
        "nach": {
            "create_form": true,
            "form_reference1": "Recurring Payment for Gaurav Kumar",
            "form_reference2": "Method Paper NACH",
            "prefilled_form": "https://rzp.io/i/exdIzYN",
            "upload_form_url": "https://rzp.io/i/bzDYbNg",
            "description": "12 p.m. Meals"
        },
        "bank_account": {
            "ifsc": "HDFC0001233",
            "bank_name": "HDFC Bank",
            "name": "Gaurav Kumar",
            "account_number": "11214311215411",
            "account_type": "savings",
            "beneficiary_email": "gaurav.kumar@example.com",
            "beneficiary_mobile": "9123456780"
        },
        "first_payment_amount": 0
    },
    "nach_form_url": "https://rzp.io/i/exdIzYN"
}
```
-------------------------------------------------------------------------------------------------------

### Create an order to charge the customer

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("amount", 1000);
orderRequest.Add("currency", "INR");
orderRequest.Add("payment_capture", true);
orderRequest.Add("receipt", "Receipt No. 1");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1","Tea, Earl Grey, Hot");
notes.Add("notes_key_2","Tea, Earl Grey… decaf.");
orderRequest.Add("notes", notes);

Order order = client.Order.Create(orderRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| amount*   | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |
| currency*   | string  | The currency of the payment (defaults to INR)  |
| receipt      | string  | Your system order reference id.  |
| payment_capture*  | boolean  | Indicates whether payment status should be changed to captured automatically or not. Possible values: true - Payments are captured automatically. false - Payments are not captured automatically. |
| notes | object  | A key-value pair  |

**Response:**
```json
{
   "id":"order_1Aa00000000002",
   "entity":"order",
   "amount":1000,
   "amount_paid":0,
   "amount_due":1000,
   "currency":"INR",
   "receipt":"Receipt No. 1",
   "offer_id":null,
   "status":"created",
   "attempts":0,
   "notes":{
      "notes_key_1":"Tea, Earl Grey, Hot",
      "notes_key_2":"Tea, Earl Grey… decaf."
   },
   "created_at":1579782776
}
```
-------------------------------------------------------------------------------------------------------

### Create a Recurring Payment

```C#
Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("email", "gaurav.kumar@example.com");
paymentRequest.Add("contact", "9123456789");
paymentRequest.Add("amount", 1000);
paymentRequest.Add("currency", "INR");
paymentRequest.Add("order_id", "order_1Aa00000000002");
paymentRequest.Add("customer_id", "cust_1Aa00000000001");
paymentRequest.Add("token", "token_1Aa00000000001");
paymentRequest.Add("recurring", 1);
paymentRequest.Add("description", "Creating recurring payment for Gaurav Kumar");
Dictionary<string, object> notes = new Dictionary<string, object>();
paymentRequest.Add("notes_key_1","Tea, Earl Grey, Hot");
paymentRequest.Add("notes_key_2","Tea, Earl Grey… decaf.");

Payment payment = client.Payment.CreateRecurringPayment(paymentRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| email*   | string      | The customer's email address |
| contact*   | string      | The customer's phone number |
| amount*   | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |
| currency*   | string  | The currency of the payment (defaults to INR)  |
| orderId*   | string      | The id of the order to be fetched |
| customerId*   | string      | The id of the customer to be fetched |
| tokenId*   | string      | The id of the token to be fetched |
| recurring*   | boolean      | Possible values is `0` or `1` |
| description  | string      | A brief description of the payment.   |
| notes | object  | A key-value pair  |

**Response:**
```json
{
  "razorpay_payment_id" : "pay_1Aa00000000001",
  "razorpay_order_id" : "order_1Aa00000000001",
  "razorpay_signature" : "9ef4dffbfd84f1318f6739a3ce19f9d85851857ae648f114332d8401e0949a3d"
}
```
-------------------------------------------------------------------------------------------------------

### Send/Resend notifications

```C#
string invoiceId = "inv_DAweOiQ7amIUVd";

string medium = "sms";

Invoice invoice = client.Invoice.Fetch(invoiceId).NotifyBy(medium);
```

**Parameters:**

| Name       | Type    |Description      |
|------------|---------|------------------------------------------------------------------------------|
| invoiceId* | string      | The id of the invoice to be fetched |
| medium*    | string      | Possible values are `sms` or `email` |

**Response:**
```json
{
    "success": true
}
```

-------------------------------------------------------------------------------------------------------

### Cancel a registration link

```C#
string invoiceId = "inv_DAweOiQ7amIUVd";

Invoice invoice = client.Invoice.Fetch(invoiceId).Cancel();
```

**Parameters:**

| Name       | Type    | Description                                                                  |
|------------|---------|------------------------------------------------------------------------------|
| invoiceId* | string      | The id of the invoice to be fetched |

**Response:**
```json
{
  "id": "inv_FHrZiAubEzDdaq",
  "entity": "invoice",
  "receipt": "Receipt No. 27",
  "invoice_number": "Receipt No. 27",
  "customer_id": "cust_BMB3EwbqnqZ2EI",
  "customer_details": {
    "id": "cust_BMB3EwbqnqZ2EI",
    "name": "Gaurav Kumar",
    "email": "gaurav.kumar@example.com",
    "contact": "9123456780",
    "gstin": null,
    "billing_address": null,
    "shipping_address": null,
    "customer_name": "Gaurav Kumar",
    "customer_email": "gaurav.kumar@example.com",
    "customer_contact": "9123456780"
  },
  "order_id": "order_FHrZiBOkWHZPOp",
  "line_items": [],
  "payment_id": null,
  "status": "cancelled",
  "expire_by": 1647483647,
  "issued_at": 1595491154,
  "paid_at": null,
  "cancelled_at": 1595491339,
  "expired_at": null,
  "sms_status": "sent",
  "email_status": "sent",
  "date": 1595491154,
  "terms": null,
  "partial_payment": false,
  "gross_amount": 0,
  "tax_amount": 0,
  "taxable_amount": 0,
  "amount": 0,
  "amount_paid": 0,
  "amount_due": 0,
  "currency": "INR",
  "currency_symbol": "₹",
  "description": "12 p.m. Meals",
  "notes": {
    "note_key 1": "Beam me up Scotty",
    "note_key 2": "Tea. Earl Gray. Hot."
  },
  "comment": null,
  "short_url": "https://rzp.io/i/bzDYbNg",
  "view_less": true,
  "billing_start": null,
  "billing_end": null,
  "type": "link",
  "group_taxes_discounts": false,
  "created_at": 1595491154,
  "idempotency_key": null,
  "token": {
    "method": "nach",
    "notes": {
      "note_key 1": "Beam me up Scotty",
      "note_key 2": "Tea. Earl Gray. Hot."
    },
    "recurring_status": null,
    "failure_reason": null,
    "currency": "INR",
    "max_amount": 50000,
    "auth_type": "physical",
    "expire_at": 1947483647,
    "nach": {
      "create_form": true,
      "form_reference1": "Recurring Payment for Gaurav Kumar",
      "form_reference2": "Method Paper NACH",
      "prefilled_form": "https://rzp.io/i/tSYd5aV",
      "upload_form_url": "https://rzp.io/i/bzDYbNg",
      "description": "12 p.m. Meals"
    },
    "bank_account": {
      "ifsc": "HDFC0001233",
      "bank_name": "HDFC Bank",
      "name": "Gaurav Kumar",
      "account_number": "11214311215411",
      "account_type": "savings",
      "beneficiary_email": "gaurav.kumar@example.com",
      "beneficiary_mobile": "9123456780"
    },
    "first_payment_amount": 0
  },
  "nach_form_url": "https://rzp.io/i/tSYd5aV"
}
```
-------------------------------------------------------------------------------------------------------

### Fetch token by payment ID

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Payment payment = client.Payment.Fetch(paymentId);
```

**Parameters:**

| Name       | Type    | Description                                                                  |
|------------|---------|------------------------------------------------------------------------------|
| paymentId* | string  | The id of the payment to be fetched |

**Response:**
```json
{
  "id": "pay_EnLNTjINiPkMEZ",
  "entity": "payment",
  "amount": 0,
  "currency": "INR",
  "status": "captured",
  "order_id": "order_EnLLfglmKksr4K",
  "invoice_id": "inv_EnLLfgCzRfcMuh",
  "international": false,
  "method": "nach",
  "amount_refunded": 0,
  "refund_status": null,
  "captured": true,
  "description": "Invoice #inv_EnLLfgCzRfcMuh",
  "card_id": null,
  "bank": "UTIB",
  "wallet": null,
  "vpa": null,
  "email": "gaurav.kumar@example.com",
  "contact": "+919876543210",
  "customer_id": "cust_DtHaBuooGHTuyZ",
  "token_id": "token_EnLNTnn7uyRg5V",
  "notes": {
    "note_key 1": "Beam me up Scotty",
    "note_key 2": "Tea. Earl Gray. Hot."
  },
  "fee": 0,
  "tax": 0,
  "error_code": null,
  "error_description": null,
  "error_source": null,
  "error_step": null,
  "error_reason": null,
  "acquirer_data": {},
  "created_at": 1588827564
}
```
-------------------------------------------------------------------------------------------------------

### Fetch tokens by customer ID

```C#
string customerId = "cust_1Aa00000000001";

List<Token> token = client.Customer.Fetch(customerId).Tokens();
```

**Parameters:**

| Name        | Type    | Description                                                                  |
|-------------|---------|------------------------------------------------------------------------------|
| CustomerId* | string      | The id of the customer to be fetched |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "token_EhYgIE3pOyMQpD",
      "entity": "token",
      "token": "3mQ5Czc6APNppI",
      "bank": "HDFC",
      "wallet": null,
      "method": "nach",
      "vpa": null,
      "recurring": true,
      "recurring_details": {
        "status": "confirmed",
        "failure_reason": null
      },
      "auth_type": "physical",
      "mrn": null,
      "used_at": 1587564373,
      "created_at": 1587564373,
      "dcc_enabled": false
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Delete token

```C#
string customerId = "cust_DtHaBuooGHTuyZ";

string tokenId = "token_HouA2OQR5Z2jTL";

Customer token = client.Customer.Fetch(customerId).DeleteToken(tokenId);
```
**Parameters:**

| Name        | Type    | Description                                                                  |
|-------------|---------|------------------------------------------------------------------------------|
| CustomerId* | string      | The id of the customer to be fetched |
| TokenId*    | string      | The id of the token to be fetched |

**Response:**
```json
{
    "deleted": true
}
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/recurring-payments/paper-nach/auto-debit/)**