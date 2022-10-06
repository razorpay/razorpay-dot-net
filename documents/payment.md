## Payments

### Capture payment

```cs
String paymentId = "pay_G8VQzjPLoAvm6D";

Dictionary<string, object> request = new Dictionary<string, object>();
request.Add("amount", 1000);
request.Add("currency", "INR");
        
Payment payment = instance.Payment.Fetch(paymentId).Capture(request);
```

**Parameters:**

| Name       | Type    | Description                                                                    |
|------------|---------|--------------------------------------------------------------------------------|
| paymentId* | string  | Id of the payment to capture                                                   |
| amount*    | integer | The amount to be captured (should be equal to the authorized amount, in paise) |
| currency   | string  | The currency of the payment (defaults to INR)                                  |

**Response:**
```json
{
  "id": "pay_G8VQzjPLoAvm6D",
  "entity": "payment",
  "amount": 1000,
  "currency": "INR",
  "status": "captured",
  "order_id": "order_G8VPOayFxWEU28",
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

### Fetch all payments

```java
Dictionary<string, object> request = new Dictionary<string, object>();
request.Add("count","1");

List<Payment> payment = instance.Payment.All(request);
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
      "id": "pay_G8VaL2Z68LRtDs",
      "entity": "payment",
      "amount": 900,
      "currency": "INR",
      "status": "captured",
      "order_id": "order_G8VXfKDWDEOHHd",
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
      "customer_id": "cust_DitrYCFtCIokBO",
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

```java
String paymentId = "pay_G8VQzjPLoAvm6D";

Payment payment = instance.Payment.Fetch(paymentId);
```

**Parameters:**

| Name       | Type   | Description                       |
|------------|--------|-----------------------------------|
| PaymentId* | string | Id of the payment to be retrieved |

**Response:**
```json
{
  "id": "pay_G8VQzjPLoAvm6D",
  "entity": "payment",
  "amount": 1000,
  "currency": "INR",
  "status": "captured",
  "order_id": "order_G8VPOayFxWEU28",
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

```java
String orderId = "order_DovFx48wjYEr2I";

Order order = instance.Order.Fetch(orderId).Payments();
```
**Parameters**

| Name     | Type   | Description                         |
|----------|--------|-------------------------------------|
| orderId* | string | The id of the order to be retrieve payment info |

**Response:**
```json
{
  "count": 1,
  "entity": "collection",
  "items": [
    {
      "id": "pay_DovGQXOkPBJjjU",
      "entity": "payment",
      "amount": 600,
      "currency": "INR",
      "status": "captured",
      "order_id": "order_DovFx48wjYEr2I",
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

```java
String paymentId = "pay_CBYy6tLmJTzn3Q";

Dictionary<string, object> request = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("key1","value1");
notes.Add("key2","value2");
request.Add("notes",notes);
              
Payment payment = instance.Payment.Fetch(paymentId).Edit(request);
```

**Parameters:**

| Name       | Type    | Description                          |
|------------|---------|--------------------------------------|
| PaymentId* | string  | Id of the payment to update          |
| notes*     | object  | A key-value pair                   |

**Response:**
```json
{
  "id": "pay_CBYy6tLmJTzn3Q",
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

```java
Dictionary<string, object> request = new Dictionary<string, object>();
request.Add("expand[]","card");

List<Payment> payment = instance.Payment.All(request);
```

Request #2: EMI

```java
Dictionary<string, object> request = new Dictionary<string, object>();
request.Add("expand[]","emi");

List<Payment> payment = instance.Payment.All(request);
```

**Response:**

For expanded card or emi details for payments response please click [here](https://razorpay.com/docs/api/payments/#fetch-expanded-card-or-emi-details-for-payments)

-------------------------------------------------------------------------------------------------------

### Fetch card details with paymentId

```java
String paymentId = "pay_CBYy6tLmJTzn3Q";

Card card = instance.cards.fetchCardDetails(paymentId);
```

**Parameters:**

| Name       | Type    | Description                          |
|------------|---------|--------------------------------------|
| paymentId* | string  | Id of the payment to update          |

**Response:**
```json
{
  "id": "card_6krZ6bcjoeqyV9",
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

```java
List<Payment> payment = instance.Payment.FetchPaymentDowntime();
```
**Response:**

For payment downtime response please click [here](https://razorpay.com/docs/api/payments/downtime/#fetch-payment-downtime-details)

-------------------------------------------------------------------------------------------------------

### Fetch Payment Downtime Details By Downtime Id

```java
String DowntimeId = "down_F7LroRQAAFuswd";

Payment payment = instance.Payment.FetchPaymentDowntimeById(downtimeId);
```

**Parameters:**

| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| DowntimeId* | string  | Id to fetch payment downtime         |

**Response:**
For payment downtime by id response please click [here](https://razorpay.com/docs/api/payments/downtime/#fetch-payment-downtime-details-by-id)

-------------------------------------------------------------------------------------------------------

### Payment capture settings API

```java
Dictionary<string, object> request = new Dictionary<string, object>();
request.Add("amount",50000);
request.Add("currency","INR");
request.Add("receipt", "rcptid_11");
Dictionary<string, object> payment = new Dictionary<string, object>();
payment.Add("capture","automatic");
Dictionary<string, object> captureOptions = new Dictionary<string, object>();
captureOptions.Add("automatic_expiry_period",12);
captureOptions.Add("manual_expiry_period",7200);
captureOptions.Add("refund_speed","optimum");
payment.Add("capture_options",captureOptions);
request.Add("payment",payment);
              
Order order = instance.Order.Create(request);
```
**Parameters:**

| Name        | Type    | Description                          |
|-------------|---------|--------------------------------------|
| amount*          | integer | Amount of the order to be paid  |
| currency*   | string  | The currency of the payment (defaults to INR)                                  |
| order_id*        | string  | The unique identifier of the order created. |
| email*        | string      | Email of the customer                       |
| contact*      | string      | Contact number of the customer              |
| method*      | string  | Possible value is `card`, `netbanking`, `wallet`,`emi`, `upi`, `cardless_emi`, `paylater`.  |
| card      | array      | All keys listed [here](https://razorpay.com/docs/payments/payment-gateway/s2s-integration/payment-methods/#supported-payment-fields) are supported  |
| bank      | string      | Bank code of the bank used for the payment. Required if the method is `netbanking`.|
| bank_account | array      | All keys listed [here](https://razorpay.com/docs/payments/customers/customer-fund-account-api/#create-a-fund-account) are supported |
| vpa      | string      | Virtual payment address of the customer. Required if the method is `upi`. |
| wallet | string      | Wallet code for the wallet used for the payment. Required if the method is `wallet`. |
| notes | array  | A key-value pair  |


**Response:**
```json
{
  "id": "order_DBJOWzybf0sJbb",
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

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/payments/)**