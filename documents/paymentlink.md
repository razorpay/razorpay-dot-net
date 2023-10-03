## Payment Links

### Create payment link

Request #1
Standard Payment Link

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("expire_by", 1691097057);
paymentLinkRequest.Add("reference_id", "TS1989");
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("reminder_enable", true);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("policy_name", "Jeevan Bima");
paymentLinkRequest.Add("notes", notes);
paymentLinkRequest.Add("callback_url", "https://example-callback-url.com/");
paymentLinkRequest.Add("callback_method", "get");

PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

Request #2
UPI Payment Link

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("upi_link", true);
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("reminder_enable", true);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("policy_name", "Jeevan Bima");
paymentLinkRequest.Add("notes", notes);

PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);

```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|upi_link (mandatory)          | boolean | boolean Must be set to true   //   to creating UPI Payment Link only                                     |
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|accept_partial        | boolean  | Indicates whether customers can make partial payments using the Payment Link. Possible values: true - Customer can make partial payments. false (default) - Customer cannot make partial payments. // UPI Payment Link is not supported partial payment  |
|description           | string  | A brief description of the Payment Link                     |
|first_min_partial_amount           | integer  | Minimum amount, in currency subunits, that must be paid by the customer as the first partial payment.  |
|reference_id           | string  | Reference number tagged to a Payment Link.                      |
|customer           | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/#sample-codes-for-upi-payment-links) are supported                 |
|expire_by           | integer  | Timestamp, in Unix, at which the Payment Link will expire. By default, a Payment Link will be valid for six months from the date of creation.                     |
|notify           | object  | sms or email (boolean)                     |
|notes           |  object  | Key-value pair that can be used to store additional information about the entity. Maximum 15 key-value pairs, 256 characters (maximum) each. For example, "note_key": "Beam me up Scotty”                     |
| callback_url | string | If specified, adds a redirect URL to the Payment Link. Once customers completes the payment, they are redirected to the specified URL. |
| callback_method | string | If callback_url parameter is passed, callback_method must be passed with the value `get`. |
| reminder_enable | boolean | Used to send reminders for the Payment Link. Possible values is `true` or `false` |

**Response:**
For create payment link response please click [here](https://razorpay.com/docs/api/payment-links/#create-payment-link)

-------------------------------------------------------------------------------------------------------

### Fetch all payment link

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("count", 1);
        
PaymentLink paymentlink = client.PaymentLink.All(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|payment_id          | string | Unique identifier of the payment associated with the Payment Link.                                               |
|reference_id        | string  | The unique reference number entered by you while creating the Payment Link.                     |

**Response:**
For fetch all payment link response please click [here](https://razorpay.com/docs/api/payment-links/#all-payment-links)

-------------------------------------------------------------------------------------------------------

### Fetch specific payment link

```C#
string paymentLinkId = "plink_Z6t7VFTb9xHeOs";

PaymentLink paymentlink = client.PaymentLink.Fetch(paymentLinkId);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| paymentLinkId (mandatory)          | string |  Unique identifier of the Payment Link.                         |

**Response:**

For fetch specific payment link response please click [here](https://razorpay.com/docs/api/payment-links/#specific-payment-links-by-id)

-------------------------------------------------------------------------------------------------------

### Update payment link

```C#
string paymentLinkId = "plink_Z6t7VFTb9xHeOs";

Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("reference_id","TS35");
paymentLinkRequest.Add("expire_by",1653347540);
paymentLinkRequest.Add("reminder_enable",true);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("policy_name", "Jeevan Bima");
paymentLinkRequest.Add("notes", notes);
              
PaymentLink paymentlink = client.PaymentLink.Fetch(paymentLinkId).Edit(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| paymentLinkId (mandatory)          | string | The unique identifier of the Payment Link that needs to be updated.                         |
| accept_partial         | boolean | Indicates whether customers can make partial payments using the Payment Link. Possible values: true - Customer can make partial payments. false (default) - Customer cannot make partial payments.                         |
| reference_id          | string | Adds a unique reference number to an existing link.                         |
| expire_by         | integer | Timestamp, in Unix format, when the payment links should expire.                         |
| notes          | string | object Key-value pair that can be used to store additional information about the entity. Maximum 15 key-value pairs, 256 characters (maximum) each. For example, "note_key": "Beam me up Scotty”.                         |

**Response:**

For updating payment link response please click [here](https://razorpay.com/docs/api/payment-links/#update-payment-link)

-------------------------------------------------------------------------------------------------------

### Cancel a payment link

```C#
string paymentLinkId = "plink_Z6t7VFTb9xHeOs";

PaymentLink paymentlink = client.PaymentLink.Fetch(paymentLinkId).Cancel();
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| paymentLinkId (mandatory)         | string | Unique identifier of the Payment Link.                         |

**Response:**

For canceling payment link response please click [here](https://razorpay.com/docs/api/payment-links/#cancel-payment-link)
-------------------------------------------------------------------------------------------------------

### Send notification

```C#
string paymentLinkId = "plink_Z6t7VFTb9xHeOs";

string  = "email";

PaymentLink paymentlink = client.PaymentLink.Fetch(paymentLinkId).NotifyBy(medium);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| paymentLinkId (mandatory)          | string | Unique identifier of the Payment Link that should be resent.                         |
| medium (mandatory)          | string | `sms`/`email`,Medium through which the Payment Link must be resent. Allowed values are:           |

**Response:**
```json
{
    "success": true
}
```
-------------------------------------------------------------------------------------------------------

### Transfer payments received using payment links

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", false);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> options = new Dictionary<string, object>();
List<Dictionary<string, object>> transfers = new List<Dictionary<string, object>>();
Dictionary<string, object> transferParams = new Dictionary<string, object>();
transferParams.Add("account", "acc_I0QRP7PpvaHhpB");
transferParams.Add("amount", 500);
transferParams.Add("currency", "INR");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");
transferParams.Add("notes", notes);
List<string> linkedAccountNotes = new List<string>();
linkedAccountNotes.Add("branch");
transferParams.Add("linked_account_notes", linkedAccountNotes);
transfers.Add(transferParams);
Dictionary<string, object> order = new Dictionary<string, object>();
order.Add("transfers", transfers);
options.Add("order", order);
paymentLinkRequest.Add("options", options);



PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|options (mandatory)           | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/transfer-payments/#response-parameters) are supported     |

**Response:**
```json
{
  "accept_partial": false,
  "amount": 1500,
  "amount_paid": 0,
  "callback_method": "",
  "callback_url": "",
  "cancelled_at": 0,
  "created_at": 1596526969,
  "currency": "INR",
  "customer": {
    "contact": "+919999999999",
    "email": "gaurav.kumar@example.com",
    "name": "Gaurav Kumar"
  },
  "deleted_at": 0,
  "description": "Payment for policy no #23456",
  "expire_by": 0,
  "expired_at": 0,
  "first_min_partial_amount": 0,
  "id": "plink_Z6t7VFTb9xHeOs",
  "notes": null,
  "notify": {
    "email": true,
    "sms": true
  },
  "payments": null,
  "reference_id": "#aasasw8",
  "reminder_enable": true,
  "reminders": [],
  "short_url": "https://rzp.io/i/ORor1MT",
  "source": "",
  "source_id": "",
  "status": "created",
  "updated_at": 1596526969,
  "user_id": ""
}
```
-------------------------------------------------------------------------------------------------------

### Offers on payment links

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 3400);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", false);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", false);
Dictionary<string, object> options = new Dictionary<string, object>();
List<string> offerParams = new List<string>();
offerParams.Add("offer_JTUADI4ZWBGWur");
offerParams.Add("offer_F4WJHqvGzw8dWF");
Dictionary<string, object> order = new Dictionary<string, object>();
order.Add("offers", offerParams);
options.Add("order", order);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|description           | string  | A brief description of the Payment Link                     |
|reference_id           | string  | AReference number tagged to a Payment Link.                      |
|customer           | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/offers/#step-2-pass-offer_id-in-payment-link-create) are supported |
|expire_by           | integer  | Timestamp, in Unix, at which the Payment Link will expire. By default, a Payment Link will be valid for six months from the date of creation.                     |
|notify           | object  | sms or email (boolean)                     |
|options*        | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/offers/#step-2-pass-offer_id-in-payment-link-create) are supported                 |

**Response:**
```json
{
  "accept_partial": false,
  "amount": 3400,
  "amount_paid": 0,
  "cancelled_at": 0,
  "created_at": 1600183040,
  "currency": "INR",
  "customer": {
    "contact": "+919999999999",
    "email": "gaurav.kumar@example.com",
    "name": "Gaurav Kumar"
  },
  "description": "Payment for policy no #23456",
  "expire_by": 0,
  "expired_at": 0,
  "first_min_partial_amount": 0,
  "id": "plink_Z6t7VFTb9xHeOs",
  "notes": null,
  "notify": {
    "email": true,
    "sms": true
  },
  "payments": null,
  "reference_id": "#425",
  "reminder_enable": false,
  "reminders": [],
  "short_url": "https://rzp.io/i/CM5ohDC",
  "status": "created",
  "user_id": ""
}
```
-------------------------------------------------------------------------------------------------------

### Managing reminders for payment links

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount",3400);
paymentLinkRequest.Add("currency","INR");
paymentLinkRequest.Add("accept_partial",true);
paymentLinkRequest.Add("reference_id","#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount",100);
paymentLinkRequest.Add("description","Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact","+919999999999");
customer.Add("name","Gaurav Kumar");
customer.Add("email","gaurav.kumar@example.com");
paymentLinkRequest.Add("customer",customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms",true);
notify.Add("email",true);
paymentLinkRequest.Add("notify",notify);
paymentLinkRequest.Add("reminder_enable",false);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|expire_by           | integer  | Timestamp, in Unix, at which the Payment Link will expire. By default, a Payment Link will be valid for six months from the date of creation.                     |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |

**Response:**
```json
{
  "amount": 340000,
  "amount_due": 340000,
  "amount_paid": 0,
  "billing_end": null,
  "billing_start": null,
  "cancelled_at": null,
  "comment": null,
  "created_at": 1592579126,
  "currency": "INR",
  "currency_symbol": "₹",
  "customer_details": {
    "billing_address": null,
    "contact": "9900990099",
    "customer_contact": "9900990099",
    "customer_email": "gaurav.kumar@example.com",
    "customer_name": "Gaurav Kumar",
    "email": "gaurav.kumar@example.com",
    "gstin": null,
    "id": "cust_F4WNtqj1xb0Duv",
    "name": "Gaurav Kumar",
    "shipping_address": null
  },
  "customer_id": "cust_F4WNtqj1xb0Duv",
  "date": 1592579126,
  "description": "Salon at Home Service",
  "email_status": null,
  "entity": "invoice",
  "expire_by": 1608390326,
  "expired_at": null,
  "first_payment_min_amount": 0,
  "gross_amount": 340000,
  "group_taxes_discounts": false,
  "id": "inv_F4WfpZLk1ct35b",
  "invoice_number": null,
  "issued_at": 1592579126,
  "line_items": [],
  "notes": [],
  "order_id": "order_F4WfpxUzWmYOTl",
  "paid_at": null,
  "partial_payment": false,
  "payment_id": null,
  "receipt": "5757",
  "reminder_enable": false,
  "short_url": "https://rzp.io/i/vitLptM",
  "sms_status": null,
  "status": "issued",
  "tax_amount": 0,
  "taxable_amount": 0,
  "terms": null,
  "type": "link",
  "user_id": "",
  "view_less": true
}
```
-------------------------------------------------------------------------------------------------------

### Rename labels in checkout section

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");

Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");

paymentLinkRequest.Add("customer", customer);

Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);

paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> notes = new Dictionary<string, object>();
Dictionary<string, object> options = new Dictionary<string, object>();

notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");

Dictionary<string, object> partialPayment = new Dictionary<string, object>(); ;
partialPayment.Add("min_amount_label", "Minimum Money to be pai");
partialPayment.Add("partial_amount_label", "Pay in parts");
partialPayment.Add("partial_amount_description", "Pay at least ₹100");
partialPayment.Add("full_amount_label", "Pay the entire amount");
Dictionary<string, object> checkout = new Dictionary<string, object>();
checkout.Add("partial_payment", partialPayment);
options.Add("checkout", checkout);
paymentLinkRequest.Add("options", options);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|expire_by           | integer  | Timestamp, in Unix, at which the Payment Link will expire. By default, a Payment Link will be valid for six months from the date of creation.                     |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |
|options*       | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/rename-checkout-labels/#response-parameters) are supported   |

**Response:**
```json
{
  "accept_partial": true,
  "amount": 1000,
  "amount_paid": 0,
  "callback_method": "",
  "callback_url": "",
  "cancelled_at": 0,
  "created_at": 1596193199,
  "currency": "INR",
  "customer": {
    "contact": "+919999999999",
    "email": "gaurav.kumar@example.com",
    "name": "Gaurav Kumar"
  },
  "deleted_at": 0,
  "description": "Payment for policy no #23456",
  "expire_by": 0,
  "expired_at": 0,
  "first_min_partial_amount": 100,
  "id": "plink_Z6t7VFTb9xHeOs",
  "notes": null,
  "notify": {
    "email": true,
    "sms": true
  },
  "payments": null,
  "reference_id": "#42321",
  "reminder_enable": true,
  "reminders": [],
  "short_url": "https://rzp.io/i/F4GC9z1",
  "source": "",
  "source_id": "",
  "status": "created",
  "updated_at": 1596193199,
  "user_id": ""
}
```
-------------------------------------------------------------------------------------------------------

### Change Business name

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> options = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");

Dictionary<string, object> checkout = new Dictionary<string, object>();
checkout.Add("name", "Lacme Corp");
options.Add("checkout", checkout);
paymentLinkRequest.Add("options", options);

PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)       | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|first_min_partial_amount        | integer  | Minimum amount, in currency subunits, that must be paid by the customer as the first partial payment.  |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |
|options*       | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/change-business-name/#request-parameters) are supported   |



**Response:**
```json
{
  "accept_partial": true,
  "amount": 1000,
  "amount_paid": 0,
  "callback_method": "",
  "callback_url": "",
  "cancelled_at": 0,
  "created_at": 1596187657,
  "currency": "INR",
  "customer": {
    "contact": "+919999999999",
    "email": "gaurav.kumar@example.com",
    "name": "Gaurav Kumar"
  },
  "description": "Payment for policy no #23456",
  "expire_by": 0,
  "expired_at": 0,
  "first_min_partial_amount": 100,
  "id": "plink_Z6t7VFTb9xHeOs",
  "notes": null,
  "notify": {
    "email": true,
    "sms": true
  },
  "payments": null,
  "reference_id": "#2234542",
  "reminder_enable": true,
  "reminders": [],
  "short_url": "https://rzp.io/i/at2OOsR",
  "source": "",
  "source_id": "",
  "status": "created",
  "updated_at": 1596187657,
  "user_id": ""
}
```
-------------------------------------------------------------------------------------------------------

### Prefill checkout fields

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> options = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");

Dictionary<string, object> prefill = new Dictionary<string, object>();
prefill.Add("method","card");
prefill.Add("card[name]","Gaurav Kumar");
prefill.Add("card[number]","4111111111111111");
prefill.Add("card[expiry]","12/21");
prefill.Add("card[cvv]","123");
Dictionary<string, object> checkout = new Dictionary<string, object>();
checkout.Add("prefill",prefill);
options.Add("checkout",checkout);
paymentLinkRequest.Add("options",options);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```
**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|first_min_partial_amount        | integer | Minimum amount, in currency subunits, that must be paid by the customer as the first partial payment.  |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |
|options*       | object  | All parameters listed [here](https://razorpay.com/docs/payment-links/api/new/advanced-options/customize/prefill/) are supported   |


**Response:**
For prefill checkout fields response please click [here](https://razorpay.com/docs/payment-links/api/new/advanced-options/customize/prefill/)

-------------------------------------------------------------------------------------------------------

### Customize payment methods

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> options = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");

Dictionary<string, object> method = new Dictionary<string, object>();
method.Add("netbanking",1);
method.Add("card",1);
method.Add("upi",1);
method.Add("wallet",1);

Dictionary<string, object> checkout = new Dictionary<string, object>();
checkout.Add("prefill", prefill);
options.Add("checkout", checkout);
paymentLinkRequest.Add("options", options);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|first_min_partial_amount        | integer  | Minimum amount, in currency subunits, that must be paid by the customer as the first partial payment. |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |
|options*       | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/customise-payment-methods/) are supported   |

**Response:**
```json
{
  "accept_partial": true,
  "amount": 1000,
  "amount_paid": 0,
  "callback_method": "",
  "callback_url": "",
  "cancelled_at": 0,
  "created_at": 1596188371,
  "currency": "INR",
  "customer": {
    "contact": "+919999999999",
    "email": "gaurav.kumar@example.com",
    "name": "Gaurav Kumar"
  },
  "deleted_at": 0,
  "description": "Payment for policy no #23456",
  "expire_by": 0,
  "expired_at": 0,
  "first_min_partial_amount": 100,
  "id": "plink_Z6t7VFTb9xHeOs",
  "notes": null,
  "notify": {
    "email": true,
    "sms": true
  },
  "payments": null,
  "reference_id": "#543422",
  "reminder_enable": true,
  "reminders": [],
  "short_url": "https://rzp.io/i/wKiXKud",
  "source": "",
  "source_id": "",
  "status": "created",
  "updated_at": 1596188371,
  "user_id": ""
}
```
-------------------------------------------------------------------------------------------------------

### Set checkout fields as read-only

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> options = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");

Dictionary<string, object> readOnly = new Dictionary<string, object>();
readOnly.Add("email", 1);
readOnly.Add("contact", 1);
Dictionary<string, object> checkout = new Dictionary<string, object>();
checkout.Add("readonly", readOnly);
options.Add("checkout", checkout);
paymentLinkRequest.Add("options", options);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|first_min_partial_amount        | integer  | Minimum amount, in currency subunits, that must be paid by the customer as the first partial payment.  |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |
|options*       | object  | Options to set contact and email as read-only fields on Checkout. Parent parameter under which the checkout and readonly child parameters must be passed.|

**Response:**
```json
{
  "accept_partial": true,
  "amount": 1000,
  "amount_paid": 0,
  "callback_method": "",
  "callback_url": "",
  "cancelled_at": 0,
  "created_at": 1596190845,
  "currency": "INR",
  "customer": {
    "contact": "+919999999999",
    "email": "gaurav.kumar@example.com",
    "name": "Gaurav Kumar"
  },
  "deleted_at": 0,
  "description": "Payment for policy no #23456",
  "expire_by": 0,
  "expired_at": 0,
  "first_min_partial_amount": 100,
  "id": "plink_Z6t7VFTb9xHeOs",
  "notes": null,
  "notify": {
    "email": true,
    "sms": true
  },
  "payments": null,
  "reference_id": "#19129",
  "reminder_enable": true,
  "reminders": [],
  "short_url": "https://rzp.io/i/QVwUglR",
  "source": "",
  "source_id": "",
  "status": "created",
  "updated_at": 1596190845,
  "user_id": ""
}
```
-------------------------------------------------------------------------------------------------------

### Implement thematic changes in payment links checkout section

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> options = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");

Dictionary<string, object> theme = new Dictionary<string, object>();
theme.Add("hide_topbar",true);
Dictionary<string, object> checkout = new Dictionary<string, object>();
checkout.Add("theme",theme);
options.Add("checkout",checkout);
paymentLinkRequest.Add("options",options);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|first_min_partial_amount        | integer  | Minimum amount, in currency subunits, that must be paid by the customer as the first partial payment.  |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |
|options*       | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/payment-links/checkout-theme#request-parameters) are supported   |

**Response:**
```json
{
  "accept_partial": true,
  "amount": 1000,
  "amount_paid": 0,
  "callback_method": "",
  "callback_url": "",
  "cancelled_at": 0,
  "created_at": 1596187814,
  "currency": "INR",
  "customer": {
    "contact": "+919999999999",
    "email": "gaurav.kumar@example.com",
    "name": "Gaurav Kumar"
  },
  "description": "Payment for policy no #23456",
  "expire_by": 0,
  "expired_at": 0,
  "first_min_partial_amount": 100,
  "id": "plink_Z6t7VFTb9xHeOs",
  "notes": null,
  "notify": {
    "email": true,
    "sms": true
  },
  "payments": null,
  "reference_id": "#423212",
  "reminder_enable": true,
  "reminders": [],
  "short_url": "https://rzp.io/i/j45EmLE",
  "source": "",
  "source_id": "",
  "status": "created",
  "updated_at": 1596187814,
  "user_id": ""
}
```
-------------------------------------------------------------------------------------------------------

### Rename labels in payment details section

```C#
Dictionary<string, object> paymentLinkRequest = new Dictionary<string, object>();
paymentLinkRequest.Add("amount", 1000);
paymentLinkRequest.Add("currency", "INR");
paymentLinkRequest.Add("accept_partial", true);
paymentLinkRequest.Add("reference_id", "#aasasw8");
paymentLinkRequest.Add("first_min_partial_amount", 100);
paymentLinkRequest.Add("description", "Payment for policy no #23456");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("contact", "+919999999999");
customer.Add("name", "Gaurav Kumar");
customer.Add("email", "gaurav.kumar@example.com");
paymentLinkRequest.Add("customer", customer);
Dictionary<string, object> notify = new Dictionary<string, object>();
notify.Add("sms", true);
notify.Add("email", true);
paymentLinkRequest.Add("notify", notify);
paymentLinkRequest.Add("reminder_enable", true);

Dictionary<string, object> options = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("branch", "Acme Corp Bangalore North");
notes.Add("name", "Bhairav Kumar");

Dictionary<string, object> partialPayment = new Dictionary<string, object>();
partialPayment.Add("min_amount_label", "Minimum Money to be pai");
partialPayment.Add("partial_amount_label", "Pay in parts");
partialPayment.Add("partial_amount_description", "Pay at least ₹100");
partialPayment.Add("full_amount_label", "Pay the entire amount");
Dictionary<string, object> checkout = new Dictionary<string, object>();
checkout.Add("partial_payment", partialPayment);
options.Add("checkout", checkout);
paymentLinkRequest.Add("options", options);
              
PaymentLink paymentlink = client.PaymentLink.Create(paymentLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|amount (mandatory)        | integer  | Amount to be paid using the Payment Link.                     |
|currency           | string  |  A three-letter ISO code for the currency in which you want to accept the payment. For example, INR.                     |
|accept_partial        | boolean  |  Indicates whether customers can make partial payments using the Payment Link. Possible values:true - Customer can make partial payments.false (default) - Customer cannot make partial payments.                     |
|first_min_partial_amount        | integer  | Minimum amount, in currency subunits, that must be paid by the customer as the first partial payment.  |
|description           | string  | A brief description of the Payment Link                     |
|customer           | object  | name, email, contact                 |
|notify           | object  | sms or email (boolean)                     |
|reminder_enable       | boolean  | To disable reminders for a Payment Link, pass reminder_enable as false                     |
|options (mandatory)       | object  | All parameters listed [here](https://razorpay.com/docs/payment-links/api/new/advanced-options/customize/rename-payment-details-labels/) are supported   |

**Response:**

For rename labels in payment details section response please click [here](https://razorpay.com/docs/payment-links/api/new/advanced-options/customize/rename-payment-details-labels/)

-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/payment-links/)**