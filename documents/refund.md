## Refunds

### Create a normal refund

```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Dictionary<string, object> refundRequest = new Dictionary<string, object>();
refundRequest.Add("amount", 200);
refundRequest.Add("speed", "normal");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
refundRequest.Add("notes", notes);
refundRequest.Add("receipt", "Receipt No. #32");

Refund refund = client.Payment.Fetch(paymentId).Refund(refundRequest);
```

**Parameters:**

| Name       | Type        | Description                                 |
|------------|-------------|---------------------------------------------|
| paymentId (mandatory) | string      | The id of the payment                       |
| amount     | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |                       |
| speed      | string      | Here, it must be normal                |
| notes      | object       | A key-value pair                |
| receipt    | string      | A unique identifier provided by you for your internal reference. |

**Response:**
```json
{
  "id": "rfnd_Z6t7VFTb9xHeOs",
  "entity": "refund",
  "amount": 500100,
  "receipt": "Receipt No. 31",
  "currency": "INR",
  "payment_id": "pay_Z6t7VFTb9xHeOs",
  "notes": [],
  "acquirer_data": {
    "arn": null
  },
  "created_at": 1597078866,
  "batch_id": null,
  "status": "processed",
  "speed_processed": "normal"
}
```
-------------------------------------------------------------------------------------------------------

### Create an instant refund

```C#

String paymentId = "pay_Z6t7VFTb9xHeOs";

Dictionary<string, object> refundRequest = new Dictionary<string, object>();
refundRequest.Add("amount",100);
refundRequest.Add("speed","optimum");
refundRequest.Add("receipt","Receipt No. 31");
              
Refund refund = client.Payment.Fetch(paymentId).Refund(refundRequest);
```

**Parameters:**

| Name       | Type        | Description                                 |
|------------|-------------|---------------------------------------------|
| paymentId (mandatory) | string      | The id of the payment                       |
| amount     | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |
| speed (mandatory)     | string      | Here, it must be optimum                    |
| receipt    | string      | A unique identifier provided by you for your internal reference. |

**Response:**
```json
{
  "id": "rfnd_Z6t7VFTb9xHeOs",
  "entity": "refund",
  "amount": 500100,
  "currency": "INR",
  "payment_id": "pay_Z6t7VFTb9xHeOs",
  "notes": {
    "notes_key_1": "Tea, Earl Grey, Hot",
    "notes_key_2": "Tea, Earl Grey… decaf."
  },
  "receipt": "Receipt No. 31",
  "acquirer_data": {
    "arn": null
  },
  "created_at": 1597078914,
  "batch_id": null,
  "status": "processed",
  "speed_requested": "optimum"
}
```
-------------------------------------------------------------------------------------------------------

### Fetch multiple refunds for a payment

```C#
String paymentId = "pay_Z6t7VFTb9xHeOs";

Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.add("count","1");
 
List<Refund> refund = client.Payment.Fetch(paymentId).AllRefunds(paramRequest)
```

**Parameters:**

| Name       | Type      | Description                                      |
|------------|-----------|--------------------------------------------------|
| paymentId (mandatory) | string      | The id of the payment                       |
| from       | timestamp | timestamp after which the payments were created  |
| to         | timestamp | timestamp before which the payments were created |
| count      | integer   | number of payments to fetch (default: 10)        |
| skip       | integer   | number of payments to be skipped (default: 0)    |

**Refund:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "rfnd_Z6t7VFTb9xHeOs",
      "entity": "refund",
      "amount": 300100,
      "currency": "INR",
      "payment_id": "pay_Z6t7VFTb9xHeOs",
      "notes": {
        "comment": "Comment for refund"
      },
      "receipt": null,
      "acquirer_data": {
        "arn": "10000000000000"
      },
      "created_at": 1597078124,
      "batch_id": null,
      "status": "processed",
      "speed_processed": "normal",
      "speed_requested": "optimum"
    }
  ]
}
 ```
-------------------------------------------------------------------------------------------------------

### Fetch a specific refund for a payment
```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

string refundId = "rfnd_Z6t7VFTb9xHeOs";

Refund refund = client.Payment.Fetch(paymentId).FetchRefund(refundId);
```

**Parameters:**

| Name       | Type        | Description                                 |
|------------|-------------|---------------------------------------------|
| paymentId (mandatory) | string      | The id of the payment to be fetched        |
| refundId (mandatory)  | string      | The id of the refund to be fetched           |

**Response:**
```json
{
  "id": "rfnd_Z6t7VFTb9xHeOs",
  "entity": "refund",
  "amount": 300100,
  "currency": "INR",
  "payment_id": "pay_Z6t7VFTb9xHeOs",
  "notes": {
    "comment": "Comment for refund"
  },
  "receipt": null,
  "acquirer_data": {
    "arn": "10000000000000"
  },
  "created_at": 1597078124,
  "batch_id": null,
  "status": "processed",
  "speed_processed": "normal",
  "speed_requested": "optimum"
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all refunds
```C#
Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.Add("count", "1");

List<Refund> refund = client.Refund.All(paramRequest);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| from  | timestamp | timestamp after which the payments were created  |
| to    | timestamp | timestamp before which the payments were created |
| count | integer   | number of payments to fetch (default: 10)        |
| skip  | integer   | number of payments to be skipped (default: 0)    |

**Response:**
```json
{
  "entity": "collection",
  "count": 2,
  "items": [
    {
      "id": "rfnd_Z6t7VFTb9xHeOs",
      "entity": "refund",
      "amount": 88800,
      "currency": "INR",
      "payment_id": "pay_Z6t7VFTb9xHeOs",
      "notes": {
        "comment": "Issuing an instant refund"
      },
      "receipt": null,
      "acquirer_data": {},
      "created_at": 1594982363,
      "batch_id": null,
      "status": "processed",
      "speed_processed": "optimum",
      "speed_requested": "optimum"
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch particular refund
```C#
string refundId = "rfnd_Z6t7VFTb9xHeOs";

Refund refund = client.Refund.Fetch(refundId);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
|  refundId (mandatory)   | string      | The id of the refund to be fetched           |

**Response:**
```json
{
  "id": "rfnd_Z6t7VFTb9xHeOs",
  "entity": "refund",
  "amount": 6000,
  "currency": "INR",
  "payment_id": "pay_Z6t7VFTb9xHeOs",
  "notes": {
    "comment": "Issuing an instant refund"
  },
  "receipt": null,
  "acquirer_data": {
    "arn": "10000000000000"
  },
  "created_at": 1589521675,
  "batch_id": null,
  "status": "processed",
  "speed_processed": "optimum",
  "speed_requested": "optimum"
}
```
-------------------------------------------------------------------------------------------------------

### Update the refund
```C#
string refundId = "rfnd_Z6t7VFTb9xHeOs";

Dictionary<string, object> refundRequest = new Dictionary<string, object>();
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot update");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
refundRequest.Add("notes", notes);

Refund refund = client.Refund.Fetch(refundId).Edit(refundRequest);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| refundId (mandatory)   | string    | The id of the refund to be fetched     |
| notes (mandatory) | array  | A key-value pair                                 |

**Response:**
```json
{
  "id": "rfnd_Z6t7VFTb9xHeOs",
  "entity": "refund",
  "amount": 300100,
  "currency": "INR",
  "payment_id": "pay_Z6t7VFTb9xHeOs",
  "notes": {
    "notes_key_1": "Beam me up Scotty.",
    "notes_key_2": "Engage"
  },
  "receipt": null,
  "acquirer_data": {
    "arn": "10000000000000"
  },
  "created_at": 1597078124,
  "batch_id": null,
  "status": "processed",
  "speed_processed": "normal",
  "speed_requested": "optimum"
}
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/refunds/)**