## Payments

### Capture payment

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("amount", 1000);
paymentRequest.Add("currency", "INR");
        
Payment payment = client.Payment.Fetch("pay_Z6t7VFTb9xHeOs").Capture(paymentRequest);
```

**Parameters:**

| Name       | Type    | Description                                                                    |
|------------|---------|--------------------------------------------------------------------------------|
| paymentId (mandatory) | string  | Id of the payment to capture                                                   |
| amount (mandatory)    | integer | The amount to be captured (should be equal to the authorized amount, in paise) |
| currency   | string  | The currency of the payment (defaults to INR)                                  |

**Response:**
```json
{
  "id": "pay_Z6t7VFTb9xHeOs",
  "entity": "payment",
  "amount": 1000,
  "currency": "INR",
  "status": "captured",
  "order_id": "order_Z6t7VFTb9xHeOs",
  "invoice_id": null,
  "international": false,
  "method": "upi",
  "amount_refunded": 0,
  "refund_status": null,
  "captured": true,
  "description": "Purchase Shoes",
  "card_id": null,
  "bank": null,
  "wallet": null,
  "vpa": "gaurav.kumar@exampleupi",
  "email": "gaurav.kumar@example.com",
  "contact": "+919999999999",
  "customer_id": "cust_Z6t7VFTb9xHeOs",
  "notes": [],
  "fee": 24,
  "tax": 4,
  "error_code": null,
  "error_description": null,
  "error_source": null,
  "error_step": null,
  "error_reason": null,
  "acquirer_data": {
    "rrn": "033814379298"
  },
  "created_at": 1606985209
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all payments

```C#
Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("count", "10");

List<Payment> payment = client.Payment.All(paymentRequest);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| from  | timestamp | timestamp after which the payments were created  |
| to    | timestamp | timestamp before which the payments were created |
| count | integer   | number of payments to fetch (default: 10)        |
| skip  | integer   | number of payments to be skipped (default: 0)    |
| expand[]  | string   | Used to retrieve additional information about the payment.Possible value is `cards` or `emi`  |

**Response:**
```json
{
  "entity": "collection",
  "count": 2,
  "items": [
    {
      "id": "pay_Z6t7VFTb9xHeOs",
      "entity": "payment",
      "amount": 900,
      "currency": "INR",
      "status": "captured",
      "order_id": "order_Z6t7VFTb9xHeOs",
      "invoice_id": null,
      "international": false,
      "method": "netbanking",
      "amount_refunded": 0,
      "refund_status": null,
      "captured": true,
      "description": "Purchase Shoes",
      "card_id": null,
      "bank": "KKBK",
      "wallet": null,
      "vpa": null,
      "email": "gaurav.kumar@example.com",
      "contact": "+919999999999",
      "customer_id": "cust_Z6t7VFTb9xHeOs",
      "notes": [],
      "fee": 22,
      "tax": 4,
      "error_code": null,
      "error_description": null,
      "error_source": null,
      "error_step": null,
      "error_reason": null,
      "acquirer_data": {
        "bank_transaction_id": "0125836177"
      },
      "created_at": 1606985740
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch a payment

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Payment payment = client.Payment.Fetch(paymentId);
```

**Parameters:**

| Name       | Type   | Description                       |
|------------|--------|-----------------------------------|
| PaymentId (mandatory) | string | Id of the payment to be retrieved |

**Response:**
```json
{
  "id": "pay_Z6t7VFTb9xHeOs",
  "entity": "payment",
  "amount": 1000,
  "currency": "INR",
  "status": "captured",
  "order_id": "order_Z6t7VFTb9xHeOs",
  "invoice_id": null,
  "international": false,
  "method": "upi",
  "amount_refunded": 0,
  "refund_status": null,
  "captured": true,
  "description": "Purchase Shoes",
  "card_id": null,
  "bank": null,
  "wallet": null,
  "vpa": "gaurav.kumar@exampleupi",
  "email": "gaurav.kumar@example.com",
  "contact": "+919999999999",
  "customer_id": "cust_DitrYCFtCIokBO",
  "notes": [],
  "fee": 24,
  "tax": 4,
  "error_code": null,
  "error_description": null,
  "error_source": null,
  "error_step": null,
  "error_reason": null,
  "acquirer_data": {
    "rrn": "033814379298"
  },
  "created_at": 1606985209
}
```
-------------------------------------------------------------------------------------------------------

### Fetch payments for an order

```C#                           
string orderId = "order_Z6t7VFTb9xHeOs";

List<Payment> payments = client.Order.Fetch(orderId).Payments();
```
**Parameters**

| Name     | Type   | Description                         |
|----------|--------|-------------------------------------|
| orderId (mandatory) | string | The id of the order to be retrieve payment info |

**Response:**
```json
{
  "count": 1,
  "entity": "collection",
  "items": [
    {
      "id": "pay_Z6t7VFTb9xHeOs",
      "entity": "payment",
      "amount": 600,
      "currency": "INR",
      "status": "captured",
      "order_id": "order_Z6t7VFTb9xHeOs",
      "method": "netbanking",
      "amount_refunded": 0,
      "refund_status": null,
      "captured": true,
      "description": "A Wild Sheep Chase is a novel by Japanese author Haruki Murakami",
      "card_id": null,
      "bank": "SBIN",
      "wallet": null,
      "vpa": null,
      "email": "gaurav.kumar@example.com",
      "contact": "9364591752",
      "fee": 70,
      "tax": 10,
      "error_code": null,
      "error_description": null,
      "error_source": null,
      "error_step": null,
      "error_reason": null,
      "notes": [],
      "acquirer_data": {
        "bank_transaction_id": "0125836177"
      },
      "created_at": 1400826750
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Update a payment

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
Dictionary<string, string> notes= new Dictionary<string, string>();
notes.Add("key1", "value1");
notes.Add("key2", "value2");
paymentRequest.Add("notes", notes);

Payment payment = client.Payment.Fetch(paymentId).Edit(paymentRequest);
```

**Parameters:**

| Name       | Type    | Description                          |
|------------|---------|--------------------------------------|
| PaymentId (mandatory) | string  | Id of the payment to update          |
| notes (mandatory)     | object  | A key-value pair                   |

**Response:**
```json
{
  "id": "pay_Z6t7VFTb9xHeOs",
  "entity": "payment",
  "amount": 1000,
  "currency": "INR",
  "status": "authorized",
  "order_id": null,
  "invoice_id": null,
  "international": false,
  "method": "netbanking",
  "amount_refunded": 0,
  "refund_status": null,
  "captured": false,
  "description": null,
  "card_id": null,
  "bank": "UTIB",
  "wallet": null,
  "vpa": null,
  "email": "testme@acme.com",
  "notes": {
    "key1": "value1",
    "key2": "value2"
  },
  "fee": null,
  "tax": null,
  "error_code": null,
  "error_description": null,
  "error_source": null,
  "error_step": null,
  "error_reason": null,
  "acquirer_data": {
    "bank_transaction_id": "0125836177"
  },
  "created_at": 1553504328
}
```
-------------------------------------------------------------------------------------------------------

### Fetch expanded card or emi details for payments

Request #1: Card

```c#
Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.Add("expand[]","card");

List<Payment> payment = client.Payment.All(paramRequest);
```

Request #2: EMI

```C#
Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.Add("expand[]","emi");

List<Payment> payment = client.Payment.All(paramRequest);
```

**Response:**

For expanded card or emi details for payments response please click [here](https://razorpay.com/docs/api/payments/#fetch-expanded-card-or-emi-details-for-payments)

-------------------------------------------------------------------------------------------------------

### Fetch card details with paymentId

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Card card = client.Card.FetchCardDetails(paymentId);
```

**Parameters:**

| Name       | Type    | Description                          |
|------------|---------|--------------------------------------|
| paymentId (mandatory) | string  | Id of the payment to update          |

**Response:**
```json
{
  "id": "card_Z6t7VFTb9xHeOs",
  "entity": "card",
  "name": "Gaurav",
  "last4": "3335",
  "network": "Visa",
  "type": "debit",
  "issuer": "SBIN",
  "international": false,
  "emi": null,
  "sub_type": "business"
}
```
-------------------------------------------------------------------------------------------------------

### Fetch Payment Downtime Details

```C#
List<Payment> payment = client.Payment.FetchPaymentDowntime();
```
**Response:**

For payment downtime response please click [here](https://razorpay.com/docs/api/payments/downtime/#fetch-payment-downtime-details)

-------------------------------------------------------------------------------------------------------

### Fetch Payment Downtime Details By Downtime Id

```C#
string downtimeId = "down_Z6t7VFTb9xHeOs";

Payment payment = client.Payment.FetchPaymentDowntimeById(downtimeId);
```

**Parameters:**

| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| DowntimeId (mandatory) | string  | Id to fetch payment downtime         |

**Response:**
For payment downtime by id response please click [here](https://razorpay.com/docs/api/payments/downtime/#fetch-payment-downtime-details-by-id)

-------------------------------------------------------------------------------------------------------

### Payment capture settings API

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("amount", 50000);
orderRequest.Add("currency", "INR");
orderRequest.Add("receipt", "rcptid_11");
Dictionary<string, object> payment = new Dictionary<string, object>();
payment.Add("capture", "automatic");
Dictionary<string, object> captureOptions = new Dictionary<string, object>();
captureOptions.Add("automatic_expiry_period", 12);
captureOptions.Add("manual_expiry_period", 7200);
captureOptions.Add("refund_speed", "optimum");
payment.Add("capture_options", captureOptions);
orderRequest.Add("payment", payment);

Order order = client.Order.Create(orderRequest);
```

**Parameters:**

| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| amount (mandatory)          | integer | Amount of the order to be paid  |
| currency (mandatory)   | string  | The currency of the payment (defaults to INR)                                  |
| order_id (mandatory)        | string  | The unique identifier of the order created. |
| email (mandatory)        | string      | Email of the customer                       |
| contact (mandatory)      | string      | Contact number of the customer              |
| method (mandatory)      | string  | Possible value is `card`, `netbanking`, `wallet`,`emi`, `upi`, `cardless_emi`, `paylater`.  |
| card      | array      | All keys listed [here](https://razorpay.com/docs/payments/payment-gateway/s2s-integration/payment-methods/#supported-payment-fields) are supported  |
| bank      | string      | Bank code of the bank used for the payment. Required if the method is `netbanking`.|
| bank_account | object      | All keys listed [here](https://razorpay.com/docs/payments/customers/customer-fund-account-api/#create-a-fund-account) are supported |
| vpa      | string      | Virtual payment address of the customer. Required if the method is `upi`. |
| wallet | string      | Wallet code for the wallet used for the payment. Required if the method is `wallet`. |
| notes | array  | A key-value pair  |


**Response:**
```json
{
  "id": "order_Z6t7VFTb9xHeOs",
  "entity": "order",
  "amount": 50000,
  "amount_paid": 0,
  "amount_due": 50000,
  "currency": "INR",
  "receipt": "rcptid_11",
  "status": "created",
  "attempts": 0,
  "notes": [],
  "created_at": 1566986570
}
```
-------------------------------------------------------------------------------------------------------

### Create Payment Json

```C#
Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("amount", 100);
paymentRequest.Add("currency", "INR");
paymentRequest.Add("email", "gaurav.kumar@example.com");
paymentRequest.Add("contact", "9123456789");
paymentRequest.Add("order_id", "order_MScdJxfAb4NFbD");
paymentRequest.Add("method", "card");
Dictionary<string, object> card = new Dictionary<string, object>();
card.Add("number", "4854980604708430");
card.Add("cvv", "123");
card.Add("expiry_month", "12");
card.Add("expiry_year", "25");
card.Add("name", "Gaurav Kumar");
paymentRequest.Add("card", card);

Payment payment = client.Payment.CreateJsonPayment(paymentRequest);
```

**Parameters:**
| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| amount (mandatory)          | integer | Amount of the order to be paid  |
| currency (mandatory)   | string  | The currency of the payment (defaults to INR)                                  |
| order_id (mandatory)        | string  | The unique identifier of the order created. |
| email (mandatory)        | string      | Email of the customer                       |
| contact (mandatory)      | string      | Contact number of the customer              |
| method (mandatory)      | string  | Possible value is `card`, `netbanking`, `wallet`,`emi`, `upi`, `cardless_emi`, `paylater`.  |
| card      | object      | All keys listed [here](https://razorpay.com/docs/payments/payment-gateway/s2s-integration/payment-methods/#supported-payment-fields) are supported  |
| bank      | string      | Bank code of the bank used for the payment. Required if the method is `netbanking`.|
| bank_account | object      | All keys listed [here](https://razorpay.com/docs/payments/customers/customer-fund-account-api/#create-a-fund-account) are supported |
| vpa      | string      | Virtual payment address of the customer. Required if the method is `upi`. |
| wallet | string      | Wallet code for the wallet used for the payment. Required if the method is `wallet`. |
| notes | object  | A key-value pair  |

 please refer this [doc](https://razorpay.com/docs/payment-gateway/s2s-integration/payment-methods/) for params

**Response:** <br>
```json
{
  "razorpay_payment_id": "pay_Z6t7VFTb9xHeOs",
  "next": [
    {
      "action": "redirect",
      "url": "https://api.razorpay.com/v1/payments/FVmAtLUe9XZSGM/authorize"
    },
    {
      "action": "otp_generate",
      "url": "https://api.razorpay.com/v1/payments/pay_Z6t7VFTb9xHeOs/otp_generate?track_id=FVmAtLUe9XZSGM&key_id=<YOUR_KEY_ID>"
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### OTP Generate

```C#

RazorpayClient instance = new RazorpayClient("key",""); // Use Only razorpay key

string paymentId = "pay_Z6t7VFTb9xHeOs";

Payment payment = client.Payment.OtpGenerate(paymentId);
```

**Parameters:**

| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| paymentId (mandatory)    | integer | Unique identifier of the payment                                               |

Doc reference [doc](https://razorpay.com/docs/payments/payment-gateway/s2s-integration/json/v2/build-integration/cards/#otp-generation-)

**Response:** <br>

```json
{
 "razorpay_payment_id": "pay_Z6t7VFTb9xHeOs",
 "next": [
  {
   "action": "otp_submit",
   "url": "https://api.razorpay.com/v1/payments/pay_Z6t7VFTb9xHeOs/otp_submit/ac2d415a8be7595de09a24b41661729fd9028fdc?key_id=<YOUR_KEY_ID>"
  },
  {
   "action": "otp_resend",
   "url": "https://api.razorpay.com/v1/payments/pay_Z6t7VFTb9xHeOs/otp_resend/json?key_id=<YOUR_KEY_ID>"
  }
 ],
 "metadata": {
  "issuer": "HDFC",
  "network": "MC",
  "last4": "1111",
  "iin": "411111"
 }
}
```

-------------------------------------------------------------------------------------------------------

### OTP Submit

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("otp", "123456");

Payment payment = client.Payment.OtpSubmit(paymentId, paymentRequest);
```

**Parameters:**

| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| paymentId (mandatory)    | integer | Unique identifier of the payment                                               |
| otp (mandatory)    | string | The customer receives the OTP using their preferred notification medium - SMS or email |

Doc reference [doc](https://razorpay.com/docs/payments/payment-gateway/s2s-integration/json/v2/build-integration/cards/#response-on-submitting-otp)

**Response:** <br>
Success
```json
{
 "razorpay_payment_id": "pay_Z6t7VFTb9xHeOs",
 "razorpay_order_id": "order_Z6t7VFTb9xHeOs",
 "razorpay_signature": "9ef4dffbfd84f1318f6739a3ce19f9d85851857ae648f114332d8401e0949a3d"
}
```
-------------------------------------------------------------------------------------------------------

### OTP Resend

```C#

string paymentId = "pay_Z6t7VFTb9xHeOs";

Payment payment = client.Payment.OtpResend(paymentId);
```

**Parameters:**

| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| paymentId (mandatory)    | integer | Unique identifier of the payment                                               |

Doc reference [doc](https://razorpay.com/docs/payments/payment-methods/cards/authentication/native-otp/#otp-resend)

**Response:** <br>

```json
{
  "next": [
    "otp_submit",
    "otp_resend"
  ],
  "razorpay_payment_id": "pay_Z6t7VFTb9xHeOs"
}
```
-------------------------------------------------------------------------------------------------------
### Create Payment Json (Third party validation)

```C#
Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("amount",500);
paymentRequest.Add("currency","INR");
paymentRequest.Add("email", "gaurav.kumar@example.com");
paymentRequest.Add("contact", "9123456789");
paymentRequest.Add("order_id", "order_JZluwjknyWdhnU");
paymentRequest.Add("method", "netbanking");
paymentRequest.Add("bank", "HDFC");
              
Payment payment = client.Payment.CreateJsonPayment(paymentRequest);
```

**Parameters:**
| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| amount (mandatory)          | integer | Amount of the order to be paid  |
| currency (mandatory)   | string  | The currency of the payment (defaults to INR)                                  |
| order_id (mandatory)        | string  | The unique identifier of the order created. |
| email (mandatory)        | string      | Email of the customer                       |
| contact (mandatory)      | string      | Contact number of the customer              |
| method (mandatory)      | string  | Possible value is `netbanking` |
| bank (mandatory)      | string      | The customer's bank code.For example, `HDFC`.|

please refer this [doc](https://razorpay.com/docs/payments/third-party-validation/s2s-integration/netbanking#step-3-create-a-payment) for params

**Response:** <br>
```json
{
  "razorpay_payment_id": "pay_Z6t7VFTb9xHeOs",
  "next": [
    {
      "action": "redirect",
      "url": "https://api.razorpay.com/v1/payments/pay_Z6t7VFTb9xHeOs/authorize"
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------
### Create Payment UPI s2s / VPA token (Third party validation)

``` C#
Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("amount", 100);
paymentRequest.Add("currency", "INR");
paymentRequest.Add("order_id", "order_MSd9LNbSEB2Gnv");
paymentRequest.Add("email", "gaurav.kumar@example.com");
paymentRequest.Add("contact", "9999999999");
paymentRequest.Add("method", "upi");
paymentRequest.Add("customer_id", "cust_Z6t7VFTb9xHeOs");
paymentRequest.Add("save", 1);
paymentRequest.Add("ip", "192.168.0.103");
paymentRequest.Add("referer", "http");
paymentRequest.Add("user_agent", "Mozilla/5.0");
paymentRequest.Add("description", "Test flow");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("note_key", "value1");
Dictionary<string, object> upi = new Dictionary<string, object>();
upi.Add("flow", "collect");
upi.Add("vpa", "gauravkumar@exampleupi");
upi.Add("expiry_time", 5);
paymentRequest.Add("notes", notes);
paymentRequest.Add("upi", upi);

Payment payment = client.Payment.CreateUpi(paymentRequest);
```

**Parameters:**
| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| amount (mandatory)          | integer | Amount of the order to be paid  |
| currency (mandatory)   | string  | The currency of the payment (defaults to INR)                                  |
| order_id (mandatory)        | string  | The unique identifier of the order created. |
| email (mandatory)        | string      | Email of the customer                       |
| customer_id (mandatory)   | string      | The id of the customer to be fetched |
| contact (mandatory)      | string      | Contact number of the customer              |
| notes | object  | A key-value pair  |
| description | string  | Descriptive text of the payment. |
| save | boolean  |  Specifies if the VPA should be stored as tokens.Possible value is `0`, `1`  |
| callback_url   | string      | URL where Razorpay will submit the final payment status. |
| ip (mandatory)   | string      | The client's browser IP address. For example `117.217.74.98` |
| referer (mandatory)   | string      | Value of `referer` header passed by the client's browser. For example, `https://example.com/` |
| user_agent (mandatory)   | string      | Value of `user_agent` header passed by the client's browser. For example, `Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36` |
| upi (mandatory) (for Upi only)  | object      | All keys listed [here](https://razorpay.com/docs/payments/third-party-validation/s2s-integration/upi/collect#step-14-initiate-a-payment) are supported  |

**Response:** <br>
```json
{
  "razorpay_payment_id": "pay_Z6t7VFTb9xHeOs"
}
```
-------------------------------------------------------------------------------------------------------
### Create Payment UPI s2s / VPA token (Third party validation)

```C#

Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("amount",500);
paymentRequest.Add("currency","INR");
paymentRequest.Add("order_id", "order_Z6t7VFTb9xHeOs");
paymentRequest.Add("email", "gaurav.kumar@example.com");
paymentRequest.Add("contact", "9123456789");
paymentRequest.Add("method", "upi");
paymentRequest.Add("ip", "192.168.0.103");
paymentRequest.Add("referer", "http");
paymentRequest.Add("user_agent", "Mozilla/5.0");
paymentRequest.Add("description", "Test flow");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("purpose","UPI test payment");
Dictionary<string, object> upi = new Dictionary<string, object>();
upi.Add("flow","intent");
paymentRequest.Add("notes",notes);
paymentRequest.Add("upi",upi);

Payment payment = client.Payment.CreateUpi(paymentRequest);
```

**Parameters:**
| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| amount (mandatory)          | integer | Amount of the order to be paid  |
| currency (mandatory)   | string  | The currency of the payment (defaults to INR)                                  |
| order_id (mandatory)        | string  | The unique identifier of the order created. |
| email (mandatory)        | string      | Email of the customer                       |
| customer_id (mandatory)   | string      | The id of the customer to be fetched |
| contact (mandatory)      | string      | Contact number of the customer              |
| notes | object  | A key-value pair  |
| description | string  | Descriptive text of the payment. |
| save | boolean  |  Specifies if the VPA should be stored as tokens.Possible value is `0`, `1`  |
| callback_url   | string      | URL where Razorpay will submit the final payment status. |
| ip (mandatory)   | string      | The client's browser IP address. For example `117.217.74.98` |
| referer (mandatory)   | string      | Value of `referer` header passed by the client's browser. For example, `https://example.com/` |
| user_agent (mandatory)   | string      | Value of `user_agent` header passed by the client's browser. For example, `Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36` |
| upi (mandatory) (for Upi only)  | object      | All keys listed [here](https://razorpay.com/docs/payments/third-party-validation/s2s-integration/upi/intent/#step-2-initiate-a-payment) are supported  |

**Response:** <br>
```json
{
  "razorpay_payment_id": "pay_Z6t7VFTb9xHeOs",
  "link": "upi://pay?pa=success@razorpay&pn=xyz&tr=xxxxxxxxxxx&tn=gourav&am=1&cu=INR&mc=xyzw"
}
```
-------------------------------------------------------------------------------------------------------

### Valid VPA (Third party validation)

```C#
Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
paymentRequest.Add("vpa", "gauravkumar@exampleupi");

Payment payment = client.Payment.ValidateUpi(paymentRequest)
```

**Parameters:**
| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| vpa (mandatory)          | string | The virtual payment address (VPA) you want to validate. For example,   `gauravkumar@exampleupi`  |

please refer this [doc](https://razorpay.com/docs/payments/third-party-validation/s2s-integration/upi/collect#step-13-validate-the-vpa) for params

**Response:** <br>
```json
{
  "vpa": "gauravkumar@exampleupi",
  "success": true,
  "customer_name": "Gaurav Kumar"
}
```
-------------------------------------------------------------------------------------------------------
### Fetch payment methods (Third party validation)

```C#
RazorpayClient client  = new RazorpayClient("key",""); // Use only razorpay key

Method methods = client.Method.Fetch();
```

**Response:** <br>
please refer this [doc](https://razorpay.com/docs/payments/third-party-validation/s2s-integration/methods-api/#fetch-payment-methods) for response

-------------------------------------------------------------------------------------------------------

### Token IIN API

```C#
string tokenIin = "412345";

Iin iin = client.Iin.Fetch(tokenIin);
```

**Parameters:**

| Name       | Type   | Description                       |
|------------|--------|-----------------------------------|
| tokenIin (mandatory) | string | The token IIN. |

**Response:**
```json
{
  "iin": "412345",
  "entity": "iin",
  "network": "Visa",
  "type": "credit",
  "sub_type": "business",
  "issuer_code": "HDFC",
  "issuer_name": "HDFC Bank Ltd",
  "international": false,
  "is_tokenized": true,
  "card_iin": "411111",
  "emi":{
     "available": true
     },
  "recurring": {
     "available": true
     },
  "authentication_types": [
   {
       "type":"3ds"
   },
   {
       "type":"otp"
   }
  ]
}
```
-------------------------------------------------------------------------------------------------------
**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/payments/)**