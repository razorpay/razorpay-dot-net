## Emandates

### Create customer
```C#
Dictionary<string, object> customerRequest = new Dictionary<string, object>();
customerRequest.Add("name", "Gaurav Kumar");
customerRequest.Add("contact", "9123456780");
customerRequest.Add("email", "gaurav.kumar@example.com");
customerRequest.Add("fail_existing", "1");
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
| fail_existing | string | If a customer with the same details already exists, the request throws an exception by default. Possible value is `1` or `0`|
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

### Create order

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("amount", 0);
orderRequest.Add("currency", "INR");
orderRequest.Add("payment_capture", true);
orderRequest.Add("customer_id", "cust_JDdNazagOgg9Ig");
orderRequest.Add("method", "emandate");
orderRequest.Add("receipt", "receipt#1");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1","Tea, Earl Grey, Hot");
notes.Add("notes_key_2","Tea, Earl Grey… decaf.");
orderRequest.Add("notes", notes);
Dictionary<string, object> token = new Dictionary<string, object>();
token.Add("auth_type","netbanking");
token.Add("max_amount","9999900");
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

Order order = client.Order.Create(orderRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| amount*          | integer | Amount of the order to be paid                                               |
| currency*        | string  | Currency of the order. Currently only `INR` is supported.                      |
| method*        | string  | The authorization method. In this case the value will be `emandate`                      |
| receipt         | string  | Your system order reference id.                                              |
| customer_id*         | string  | The `customer_id` for the customer you want to charge.|
| payment_capture  | boolean  | Indicates whether payment status should be changed to captured automatically or not. Possible values: true - Payments are captured automatically. false - Payments are not captured automatically. |
| notes           | object  | A key-value pair                                                             |
| token  | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/recurring-payments/emandate/create-authorization-transaction/#112-create-an-order) are supported|


**Response:**

Create order response please click [here](https://razorpay.com/docs/api/recurring-payments/emandate/authorization-transaction/#112-create-an-order)

-------------------------------------------------------------------------------------------------------

### Create an Authorization Payment

Please refer this [doc](https://razorpay.com/docs/api/recurring-payments/emandate/authorization-transaction/#113-create-an-authorization-payment) for authorization payment

-------------------------------------------------------------------------------------------------------

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
subscriptionRegistration.Add("method","emandate");
subscriptionRegistration.Add("auth_type","netbanking");
subscriptionRegistration.Add("max_amount",50000);
subscriptionRegistration.Add("expire_at",1609423824);
Dictionary<string, object> bankAccount = new Dictionary<string, object>();
bankAccount.Add("beneficiary_name","Gaurav Kumar");
bankAccount.Add("account_number","11214311215411");
bankAccount.Add("account_type","savings");
bankAccount.Add("ifsc_code","HDFC0001233");
subscriptionRegistration.Add("bank_account",bankAccount);
registrationLinkRequest.Add("subscription_registration", subscriptionRegistration);
registrationLinkRequest.Add("receipt", "Receipt No. 1");
registrationLinkRequest.Add("email_notify", true);
registrationLinkRequest.Add("sms_notify", true);
registrationLinkRequest.Add("expire_by", 1580479824);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1","Tea, Earl Grey, Hot");
notes.Add("notes_key_2","Tea, Earl Grey… decaf.");
registrationLinkRequest.Add("notes", notes);

Invoice invoice = client.Invoice.CreateRegistrationLink(registrationLinkRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| customer*          | object  | All parameters listed [here](https://razorpay.com/docs/api/payments/recurring-payments/emandate/create-authorization-transaction/#121-create-a-registration-link) are supported  |
| type*        | string  | In this case, the value is `link`.                      |
| currency*        | string  | The 3-letter ISO currency code for the payment. Currently, only `INR` is supported. |
| amount*         | integer  | The payment amount in the smallest currency sub-unit.                 |
| description*    | string  | A description that appears on the hosted page. For example, `12:30 p.m. Thali meals (Gaurav Kumar`).                                                             |
| subscription_registration  | array  | All parameters listed [here](https://razorpay.com/docs/api/payments/recurring-payments/emandate/create-authorization-transaction/#121-create-a-registration-link) are supported  |
| email_notify | boolean  | Email notifications are to be sent by Razorpay (default : true)  |
| expire_by    | integer | The timestamp, in Unix format, till when the customer can make the authorization payment. |
| receipt      | string  | Your system order reference id.  |
| notes           | object  | A key-value pair  |

**Response:**

Create registration link response please click [here](https://razorpay.com/docs/api/recurring-payments/emandate/authorization-transaction/#121-create-a-registration-link)
-------------------------------------------------------------------------------------------------------

### Send/Resend notifications

```C#
string invoiceId = "inv_DAweOiQ7amIUVd";

string medium = "sms";

Invoice invoice = client.Invoice.Fetch(invoiceId).NotifyBy(medium);
```

**Parameters:**

| Name       | Type    | Description                                                                  |
|------------|---------|------------------------------------------------------------------------------|
| invoiceId* | string | The id of the invoice to be notified                         |
| medium*    | string | `sms`/`email`, Medium through which notification should be sent.                         |

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
| invoiceId* | string | The id of the invoice to be cancelled                         |

**Response:**
```json
{
  "id": "inv_FHrfRupD2ouKIt",
  "entity": "invoice",
  "receipt": "Receipt No. 1",
  "invoice_number": "Receipt No. 1",
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
  "order_id": "order_FHrfRw4TZU5Q2L",
  "line_items": [],
  "payment_id": null,
  "status": "cancelled",
  "expire_by": 4102444799,
  "issued_at": 1595491479,
  "paid_at": null,
  "cancelled_at": 1595491488,
  "expired_at": null,
  "sms_status": "sent",
  "email_status": "sent",
  "date": 1595491479,
  "terms": null,
  "partial_payment": false,
  "gross_amount": 100,
  "tax_amount": 0,
  "taxable_amount": 0,
  "amount": 100,
  "amount_paid": 0,
  "amount_due": 100,
  "currency": "INR",
  "currency_symbol": "₹",
  "description": "Registration Link for Gaurav Kumar",
  "notes": {
    "note_key 1": "Beam me up Scotty",
    "note_key 2": "Tea. Earl Gray. Hot."
  },
  "comment": null,
  "short_url": "https://rzp.io/i/QlfexTj",
  "view_less": true,
  "billing_start": null,
  "billing_end": null,
  "type": "link",
  "group_taxes_discounts": false,
  "created_at": 1595491480,
  "idempotency_key": null
}
```
-------------------------------------------------------------------------------------------------------

### Fetch token by payment ID

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Payment payment = client.Payment.Fetch(paymentId);
```

**Parameters:**

| Name       | Type   | Description                       |
|------------|--------|-----------------------------------|
| paymentId* | string | Id of the payment to be retrieved |

**Response:**
```json
{
  "id": "pay_FHf9a7AO0iXM9I",
  "entity": "payment",
  "amount": 0,
  "currency": "INR",
  "status": "captured",
  "order_id": "order_FHf9OwSeyetnKC",
  "invoice_id": "inv_FHf9P2hhXEti7i",
  "international": false,
  "method": "emandate",
  "amount_refunded": 0,
  "refund_status": null,
  "captured": true,
  "description": null,
  "card_id": null,
  "bank": "HDFC",
  "wallet": null,
  "vpa": null,
  "email": "gaurav.kumar@example.com",
  "contact": "+919876543210",
  "customer_id": "cust_DtHaBuooGHTuyZ",
  "token_id": "token_FHf9aAZR9hWJkq",
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
  "created_at": 1595447410
}
```
-------------------------------------------------------------------------------------------------------

### Fetch tokens by customer ID

```C#
string customerId = "cust_1Aa00000000001";

List<Token> token = client.Customer.Fetch(customerId).Tokens();
```

**Parameters:**

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| customerId* | string      | The id of the customer to be fetched |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "token_FHf94Uym9tdYFJ",
      "entity": "token",
      "token": "2wDPM7VAlXtjAR",
      "bank": "HDFC",
      "wallet": null,
      "method": "emandate",
      "vpa": null,
      "recurring": true,
      "recurring_details": {
        "status": "confirmed",
        "failure_reason": null
      },
      "auth_type": "netbanking",
      "mrn": null,
      "used_at": 1595447381,
      "created_at": 1595447381,
      "bank_details": {
        "beneficiary_name": "Gaurav Kumar",
        "account_number": "1121431121541121",
        "ifsc": "HDFC0000001",
        "account_type": "savings"
      },
      "max_amount": 9999900,
      "expired_at": 1689971140,
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

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| customerId* | string      | The id of the customer to be fetched |
| tokenId*    | string      | The id of the token to be fetched |

**Response:**
```json
{
    "deleted": true
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
| amount*          | integer | Amount of the order to be paid                                               |
| currency*        | string  | Currency of the order. Currently only `INR` is supported.                      |
| receipt         | string  | Your system order reference id.                                              |
| notes           | object  | A key-value pair       |
| payment_capture*  | boolean  | Indicates whether payment status should be changed to captured automatically or not. Possible values: true - Payments are captured automatically. false - Payments are not captured automatically. |

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
paymentRequest.Add("recurring", true);
paymentRequest.Add("description", "Creating recurring payment for Gaurav Kumar");
Dictionary<string, object> notes = new Dictionary<string, object>();
paymentRequest.Add("notes_key_1","Tea, Earl Grey, Hot");
paymentRequest.Add("notes_key_2","Tea, Earl Grey… decaf.");

Payment payment = client.Payment.CreateRecurringPayment(paymentRequest);
```

**Parameters:**

| Name           | Type    | Description                                                                  |
|----------------|---------|------------------------------------------------------------------------------|
| email*         | string | The customer's email address.                                               |
| contact*       | string  | The customer's phone number.                      |
| amount*        | integer  | The amount you want to charge your customer. This should be the same as the amount in the order.                        |
| currency*       | string  | The 3-letter ISO currency code for the payment. Currently, only `INR` is supported. |
| order_id*       | string  | The unique identifier of the order created. |
| customer_id*      | string  | The `customer_id` for the customer you want to charge.  |
| token*       | string  | The `token_id` generated when the customer successfully completes the authorization payment. Different payment instruments for the same customer have different `token_id`.|
| recurring*       | string  | Determines if recurring payment is enabled or not. Possible values:<br>* `true` - Recurring is enabled.* `false` - Recurring is not enabled.|
| description       | string  | A user-entered description for the payment.|
| notes        | object  | Key-value pair that can be used to store additional information about the entity. Maximum 15 key-value pairs, 256 characters (maximum) each. |

**Response:**
```json
{
  "razorpay_payment_id" : "pay_1Aa00000000001",
  "razorpay_order_id" : "order_1Aa00000000001",
  "razorpay_signature" : "9ef4dffbfd84f1318f6739a3ce19f9d85851857ae648f114332d8401e0949a3d"
}
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/recurring-payments/emandate/authorization-transaction/)**