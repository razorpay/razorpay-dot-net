## Orders

### Create order

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("amount", 50000);
orderRequest.Add("currency", "INR");
orderRequest.Add("receipt", "receipt#1");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey, Hot");
orderRequest.Add("notes", notes);

Order order = client.Order.Create(orderRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| amount (mandatory)          | integer | Amount of the order to be paid                                               |
| currency (mandatory)        | string  | Currency of the order. Currently only `INR` is supported.                      |
| receipt         | string  | Your system order reference id.                                              |
| notes           | object  | A key-value pair |
|partial_payment | boolean  | Indicates whether customers can make partial payments on the invoice . Possible values: true - Customer can make partial payments. false (default) - Customer cannot make partial payments. |

**Response:**

```json
{
  "id": "order_Z6t7VFTb9xHeOs",
  "entity": "order",
  "amount": 50000,
  "amount_paid": 0,
  "amount_due": 50000,
  "currency": "INR",
  "receipt": "receipt#1",
  "offer_id": null,
  "status": "created",
  "attempts": 0,
  "notes": [],
  "created_at": 1582628071
}
```

-------------------------------------------------------------------------------------------------------
### Create order (Third party validation)

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("amount", 50000);
orderRequest.Add("method", "netbanking");
orderRequest.Add("currency", "INR");
orderRequest.Add("receipt", "receipt#1");
Dictionary<string, object> bankAccount = new Dictionary<string, object>();
bankAccount.Add("account_number","765432123456789");
bankAccount.Add("name","Gaurav Kumar");
bankAccount.Add("ifsc","HDFC0000053");
orderRequest.Add("bank_account", bankAccount);

Order order = client.Order.Create(orderRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| amount (mandatory)          | integer | Amount of the order to be paid                                               |
| method        | string  | The payment method used to make the payment. If this parameter is not passed, customers will be able to make payments using both netbanking and UPI payment methods. Possible values is `netbanking` or `upi`|
| currency (mandatory)        | string  | Currency of the order. Currently only `INR` is supported.       |
| receipt         | string  | Your system order reference id.                                              |
|bank_account | object  | All keys listed [here](https://razorpay.com/docs/payments/third-party-validation/#step-2-create-an-order) are supported |

**Response:**

```json
{
  "id": "order_Z6t7VFTb9xHeOs",
  "entity": "order",
  "amount": 500,
  "amount_paid": 0,
  "amount_due": 500,
  "currency": "INR",
  "receipt": "BILL13375649",
  "offer_id": null,
  "status": "created",
  "attempts": 0,
  "notes": [],
  "created_at": 1573044247
}
```

-------------------------------------------------------------------------------------------------------

### Fetch all orders

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("count","1");

List<Order> order = client.Order.All(orderRequest);
```

**Parameters**

| Name       | Type      | Description                                                  |
|------------|-----------|--------------------------------------------------------------|
| from       | timestamp | timestamp after which the orders were created              |
| to         | timestamp | timestamp before which the orders were created             |
| count      | integer   | number of orders to fetch (default: 10)                    |
| skip       | integer   | number of orders to be skipped (default: 0)                |
| authorized | boolean   | Orders for which orders are currently in authorized state. |
| receipt    | string    | Orders with the provided value for receipt.                  |
| expand[]  | string   | Used to retrieve additional information about the payment.Possible value is `payments` or `payments.card`, `transfers` or `virtual_account` |

**Response:**

```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "order_Z6t7VFTb9xHeOs",
      "entity": "order",
      "amount": 1234,
      "amount_paid": 0,
      "amount_due": 1234,
      "currency": "INR",
      "receipt": "Receipt No. 1",
      "offer_id": null,
      "status": "created",
      "attempts": 0,
      "notes": [],
      "created_at": 1582637108
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch particular order

```C#
string orderId = "order_Z6t7VFTb9xHeOs";

Order order = client.Order.Fetch(orderId);
```
**Parameters**

| Name     | Type   | Description                         |
|----------|--------|-------------------------------------|
| orderId (mandatory) | string | The id of the order to be fetched |

**Response:**

```json
{
  "id":"order_Z6t7VFTb9xHeOs",
  "entity":"order",
  "amount":2200,
  "amount_paid":0,
  "amount_due":2200,
  "currency":"INR",
  "receipt":"Receipt #211",
  "status":"attempted",
  "attempts":1,
  "notes":[],
  "created_at":1572505143
}
```
-------------------------------------------------------------------------------------------------------

### Fetch payments for an order

```C#
string orderId = "order_Z6t7VFTb9xHeOs";

List<Payment> order = client.Order.Fetch(orderId).Payments();
```
**Parameters**

| Name     | Type   | Description                         |
|----------|--------|-------------------------------------|
| orderId (mandatory) | string | The id of the order to be retrieve payment info |

**Response:**
```json
{
  "entity":"collection",
  "count":1,
  "items":[
    {
      "id":"pay_Z6t7VFTb9xHeOs",
      "entity":"payment",
      "amount":2200,
      "currency":"INR",
      "status":"captured",
      "order_id":"order_Z6t7VFTb9xHeOs",
      "invoice_id":null,
      "international":false,
      "method":"card",
      "amount_refunded":0,
      "refund_status":null,
      "captured":true,
      "description":"Beans in every imaginable flavour",
      "card_id":"card_Z6t7VFTb9xHeOs",
      "bank":null,
      "wallet":null,
      "vpa":null,
      "email":"gaurav.kumar@example.com",
      "contact":"+919999999988",
      "notes":[],
      "fee":44,
      "tax":0,
      "error_code":null,
      "error_description":null,
      "created_at":1572505160
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Update order

```C#
string orderId = "order_Z6t7VFTb9xHeOs";

Dictionary<string, object> orderRequest = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey, Hot Update");
orderRequest.Add("notes", notes);

Order order = client.Order.Fetch(orderId).Edit(orderRequest);
```
**Parameters**

| Name     | Type   | Description                         |
|----------|--------|-------------------------------------|
| orderId (mandatory) | string | The id of the order to be retrieve payment info |
| notes (mandatory)   | object  | A key-value pair                    |

**Response:**
```json
{
  "id":"order_Z6t7VFTb9xHeOs",
  "entity":"order",
  "amount":2200,
  "amount_paid":0,
  "amount_due":2200,
  "currency":"INR",
  "receipt":"Receipt #211",
  "offer_id":null,
  "status":"attempted",
  "attempts":1,
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "created_at":1572505143
}
```
-------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------

### View RTO/Risk Reasons

```C#
string orderId = "order_DaaS6LOUAASb7Y";

Order order = client.Order.Fetch(orderId).ViewRtoReview();
```
**Parameters**

| Name     | Type   | Description                                                             |
|----------|--------|-------------------------------------------------------------------------|
| orderId* | string | The unique identifier of an order to access the rto_review information. |

**Response:**
```json
{
  "risk_tier": "high",
  "rto_reasons": [
    {
      "reason": "short_shipping_address",
      "description": "Short shipping address",
      "bucket": "address"
    },
    {
      "reason": "address_pincode_state_mismatch",
      "description": "Incorrect pincode state entered",
      "bucket": "address"
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Update the Fulfillment Details

```C#
string orderId = "order_DaaS6LOUAASb7Y";

Dictionary<string, object> param = new Dictionary<string, object>();
Dictionary<string, object> shipping = new Dictionary<string, object>();
param.Add("payment_method", "upi");
shipping.Add("waybill","12345678");
shipping.Add("status","rto");
shipping.Add("provider","Bluedart");
param.Add("shipping", shipping);

Order order = client.Order.Fetch(orderId).EditFulFillment(param);
```
**Parameters**

| Name           | Type   | Description                                                                                                                                                                                   |
|----------------|--------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| orderId*       | string | The unique identifier of an order to access the fulfillment information.                                                                                                                      |
| payment_method | string | Payment Method opted by the customer to complete the payment. Possible values is `upi`, `card`, `wallet`, `netbanking`, `cod`, `emi`, `cardless_emi`, `paylater`, `recurring`, `other`.       |
| shipping       | object | Contains the shipping data. [here](https://razorpay.com/docs/payments/magic-checkout/rto-intelligence/#step-3-update-the-fulfillment-details) are supported                                   |

**Response:**
```json
{
  "entity": "order.fulfillment",
  "order_id": "EKwxwAgItXXXX",
  "payment_method": "upi",
  "shipping": {
    "waybill": "123456789",
    "status": "rto",
    "provider": "Bluedart"
  }
}
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/orders/)**