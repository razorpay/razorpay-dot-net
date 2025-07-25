## Transfers

### Create transfers from payment

```C#
string paymentId = "pay_E8JR8E0XyjUSZd";

Dictionary<string, object> transferRequest = new Dictionary<string, object>();
List<Dictionary<string, object>> transfers = new List<Dictionary<string, object>>();
Dictionary<string, object> transferParams = new Dictionary<string, object>();
transferParams.Add("account", "acc_I0QRP7PpvaHhpB");
transferParams.Add("amount", 100);
transferParams.Add("currency", "INR");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("name", "Gaurav Kumar");
notes.Add("roll_no", "IEC2011025");
transferParams.Add("notes", notes);
List<string> linkedAccountNotes = new List<string>();
linkedAccountNotes.Add("roll_no");
transferParams.Add("linked_account_notes", linkedAccountNotes);
transferParams.Add("on_hold", true);
transfers.Add(transferParams);
transferRequest.Add("transfers", transfers);

List<Transfer> transfer = client.Payment.Fetch(paymentId).Transfer(transferRequest);
```

**Parameters:**

| Name       | Type        | Description                                 |
|------------|-------------|---------------------------------------------|
| PaymentId (mandatory) | string      | The id of the payment to be fetched  |
| transfers  | object     | All parameters listed [here](https://razorpay.com/docs/api/route/#create-transfers-from-payments) are supported |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "trf_E9uhYLFLLZ2pks",
      "entity": "transfer",
      "source": "pay_E8JR8E0XyjUSZd",
      "recipient": "acc_CPRsN1LkFccllA",
      "amount": 100,
      "currency": "INR",
      "amount_reversed": 0,
      "notes": {
        "name": "Gaurav Kumar",
        "roll_no": "IEC2011025"
      },
      "on_hold": true,
      "on_hold_until": 1671222870,
      "recipient_settlement_id": null,
      "created_at": 1580218356,
      "linked_account_notes": [
        "roll_no"
      ],
      "processed_at": 1580218357
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Create transfers from order

```C#
Dictionary<string, object> orderRequest = new Dictionary<string, object>();
orderRequest.Add("amount", 100);
orderRequest.Add("currency", "INR");
orderRequest.Add("receipt", "receipt#341");
List<Dictionary<string, object>> transfers = new List<Dictionary<string, object>>();
Dictionary<string, object> transferParams = new Dictionary<string, object>();
transferParams.Add("account", "acc_I0QRP7PpvaHhpB");
transferParams.Add("amount", 100);
transferParams.Add("currency", "INR");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("name", "Gaurav Kumar");
notes.Add("roll_no", "IEC2011025");
transferParams.Add("notes", notes);
List<string> linkedAccountNotes = new List<string>();
linkedAccountNotes.Add("roll_no");
transferParams.Add("linked_account_notes", linkedAccountNotes);
transferParams.Add("on_hold", true);
transfers.Add(transferParams);
orderRequest.Add("transfers", transfers);

Order token = client.Order.Create(orderRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| amount (mandatory)   | integer      | The transaction amount, in paise |
| currency (mandatory)   | string  | The currency of the payment (defaults to INR)  |
|  receipt      | string      | A unique identifier provided by you for your internal reference. |
| transfers   | object     | All parameters listed [here](https://razorpay.com/docs/api/route/#create-transfers-from-orders) are supported |

**Response:**
```json
{
  "id": "order_E9uTczH8uWPCyQ",
  "entity": "order",
  "amount": 2000,
  "amount_paid": 0,
  "amount_due": 2000,
  "currency": "INR",
  "receipt": null,
  "offer_id": null,
  "status": "created",
  "attempts": 0,
  "notes": [],
  "created_at": 1580217565,
  "transfers": [
    {
      "recipient": "acc_CPRsN1LkFccllA",
      "amount": 1000,
      "currency": "INR",
      "notes": {
        "branch": "Acme Corp Bangalore North",
        "name": "Gaurav Kumar"
      },
      "linked_account_notes": [
        "branch"
      ],
      "on_hold": true,
      "on_hold_until": 1671222870
    },
    {
      "recipient": "acc_CNo3jSI8OkFJJJ",
      "amount": 1000,
      "currency": "INR",
      "notes": {
        "branch": "Acme Corp Bangalore South",
        "name": "Saurav Kumar"
      },
      "linked_account_notes": [
        "branch"
      ],
      "on_hold": false,
      "on_hold_until": null
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Direct transfers

```C#
Dictionary<string, object> transferRequest = new Dictionary<string, object>();
transferRequest.Add("account", "acc_I0QRP7PpvaHhpB");
transferRequest.Add("amount", 100);
transferRequest.Add("currency", "INR");
               
Transfer transfer = client.Transfer.Create(transferRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| accountId*   | string      | The id of the account to be fetched  |
| amount*   | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |
| currency*   | string  | The currency of the payment (defaults to INR)  |

**Response:**
```json
{
  "id": "trf_E9utgtfGTcpcmm",
  "entity": "transfer",
  "source": "acc_CJoeHMNpi0nC7k",
  "recipient": "acc_CPRsN1LkFccllA",
  "amount": 100,
  "currency": "INR",
  "amount_reversed": 0,
  "notes": [],
  "fees": 1,
  "tax": 0,
  "on_hold": false,
  "on_hold_until": null,
  "recipient_settlement_id": null,
  "created_at": 1580219046,
  "linked_account_notes": [],
  "processed_at": 1580219046
}
```
-------------------------------------------------------------------------------------------------------

### Fetch transfer for a payment

```C#
string paymentId = "pay_E9up5WhIfMYnKW";

List<Transfer> token = client.Payment.Fetch(paymentId).Transfers();
```

**Parameters:**

| Name       | Type        | Description                                 |
|------------|-------------|---------------------------------------------|
| PaymentId (mandatory) | string      | The id of the payment to be fetched  |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "trf_EAznuJ9cDLnF7Y",
      "entity": "transfer",
      "source": "pay_E9up5WhIfMYnKW",
      "recipient": "acc_CMaomTz4o0FOFz",
      "amount": 1000,
      "currency": "INR",
      "amount_reversed": 100,
      "notes": [],
      "fees": 3,
      "tax": 0,
      "on_hold": false,
      "on_hold_until": null,
      "recipient_settlement_id": null,
      "created_at": 1580454666,
      "linked_account_notes": [],
      "processed_at": 1580454666
    }
  ]
}
```
-------------------------------------------------------------------------------------

### Fetch transfer for an order

```C#
string orderId = "order_JkaIDdkgGXVcwS";

Dictionary<string, object> transferRequest = new Dictionary<string, object>();
transferRequest.Add("expand[]", "transfers");

Order token = client.Order.Fetch(orderId, transferRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| orderId (mandatory)   | string      | The id of the order to be fetched  |
| expand (mandatory)   | string    | Supported value is `status`  |

**Response:**
```json
{
  "id": "order_DSkl2lBNvueOly",
  "entity": "order",
  "amount": 1000,
  "amount_paid": 1000,
  "amount_due": 0,
  "currency": "INR",
  "receipt": null,
  "offer_id": null,
  "status": "paid",
  "attempts": 1,
  "notes": [],
  "created_at": 1570794714,
  "transfers": {
    "entity": "collection",
    "count": 1,
    "items": [
      {
        "id": "trf_DSkl2lXWbiADZG",
        "entity": "transfer",
        "source": "order_DSkl2lBNvueOly",
        "recipient": "acc_CNo3jSI8OkFJJJ",
        "amount": 500,
        "currency": "INR",
        "amount_reversed": 0,
        "notes": {
          "branch": "Acme Corp Bangalore North",
          "name": "Gaurav Kumar"
        },
        "fees": 2,
        "tax": 0,
        "on_hold": true,
        "on_hold_until": 1670776632,
        "recipient_settlement_id": null,
        "created_at": 1570794714,
        "linked_account_notes": [
          "Acme Corp Bangalore North"
        ],
        "processed_at": 1570794772
      }
    ]
  }
}
```
-------------------------------------------------------------------------------------------------------
### Fetch transfer

```C#
string transferId = "trf_E7V62rAxJ3zYMo";

Transfer transfer = client.Transfer.Fetch("trf_Mb2I3eslnL3bFk");
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| transferId (mandatory)   | string      | The id of the transfer to be fetched  |

**Response:**
```json
{
    "id": "trf_IJOI2DHWQYwqU3",
    "entity": "transfer",
    "status": "created",
    "source": "order_IJOI2CD6CNIywP",
    "recipient": "acc_HjVXbtpSCIxENR",
    "amount": 100,
    "currency": "INR",
    "amount_reversed": 0,
    "fees": 0,
    "tax": null,
    "notes": {
        "branch": "Acme Corp Bangalore North",
        "name": "Gaurav Kumar"
    },
    "linked_account_notes": [
        "branch"
    ],
    "on_hold": true,
    "on_hold_until": 1671222870,
    "settlement_status": null,
    "recipient_settlement_id": null,
    "created_at": 1636435963,
    "processed_at": null,
    "error": {
        "code": null,
        "description": null,
        "reason": null,
        "field": null,
        "step": null,
        "id": "trf_IJOI2DHWQYwqU3",
        "source": null,
        "metadata": null
    }
}
```
-------------------------------------------------------------------------------------------------------

### Fetch transfers for a settlement

```C#
Dictionary<string, object> transferRequest = new Dictionary<string, object>();
transferRequest.Add("recipient_settlement_id", "setl_DHYJ3dRPqQkAgV");

List<Transfer> transfer = client.Transfer.All(transferRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| recipient_settlement_id (mandatory)   | string    | The recipient settlement id obtained from the settlement.processed webhook payload.  |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "trf_HWjmkReRGPhguR",
      "entity": "transfer",
      "status": "processed",
      "source": "pay_HWjY9DZSMsbm5E",
      "recipient": "acc_HWjl1kqobJzf4i",
      "amount": 1000,
      "currency": "INR",
      "amount_reversed": 0,
      "fees": 3,
      "tax": 0,
      "notes": [],
      "linked_account_notes": [],
      "on_hold": false,
      "on_hold_until": null,
      "settlement_status": "settled",
      "recipient_settlement_id": "setl_HYIIk3H0J4PYdX",
      "created_at": 1625812996,
      "processed_at": 1625812996,
      "error": {
        "code": null,
        "description": null,
        "reason": null,
        "field": null,
        "step": null,
        "id": "trf_HWjmkReRGPhguR",
        "source": null,
        "metadata": null
      }
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch settlement details

```C#
Dictionary<string, object> transferRequest = new Dictionary<string, object>();
transferRequest.Add("expand[]", "recipient_settlement");

List<Transfer> transfer = client.Transfer.All(transferRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| expand (mandatory)   | string    | Supported value is `recipient_settlement`  |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "trf_DGSTeXzBkEVh48",
      "entity": "transfer",
      "source": "pay_DGSRhvMbOqeCe7",
      "recipient": "acc_CMaomTz4o0FOFz",
      "amount": 500,
      "currency": "INR",
      "amount_reversed": 0,
      "notes": [],
      "fees": 2,
      "tax": 0,
      "on_hold": false,
      "on_hold_until": null,
      "recipient_settlement_id": "setl_DHYJ3dRPqQkAgV",
      "recipient_settlement": {
        "id": "setl_DHYJ3dRPqQkAgV",
        "entity": "settlement",
        "amount": 500,
        "status": "failed",
        "fees": 0,
        "tax": 0,
        "utr": "CN0038699836",
        "created_at": 1568349124
      },
      "created_at": 1568110256,
      "linked_account_notes": [],
      "processed_at": null
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Refund payments and reverse transfer from a linked account

```C#
String paymentId = "pay_EAdwQDe4JrhOFX";

Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("amount",100);
param.Add("reverse_all", true);

Refund transfer = client.Payment.Fetch("pay_MZS53duPD7FNd1").Refund(param);
```

**Parameters:**

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| paymentId (mandatory)  | string      | The id of the payment to be fetched  |
| amount (mandatory)     | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |
| reverse_all | boolean    | Reverses transfer made to a linked account. Possible values:<br> * `true` - Reverses transfer made to a linked account.<br>* `false` - Does not reverse transfer made to a linked account.|

**Response:**
```json
{
  "id": "rfnd_JJFNlNXPHY640A",
  "entity": "refund",
  "amount": 100,
  "currency": "INR",
  "payment_id": "pay_JJCqynf4fQS0N1",
  "notes": [],
  "receipt": null,
  "acquirer_data": {
    "arn": null
  },
  "created_at": 1649941680,
  "batch_id": null,
  "status": "processed",
  "speed_processed": "normal",
  "speed_requested": "normal"
}
```
-------------------------------------------------------------------------------------------------------

### Fetch payments of a linked account

```C#
client.addHeader("X-Razorpay-Account","acc_CPRsN1LkFccllA");

List<Payment> transfer = client.Payment.All();
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| X-Razorpay-Account   | string      | The linked account id to fetch the payments received by linked account |

**Response:**
```json
{
  "entity": "collection",
  "count": 2,
  "items": [
    {
      "id": "pay_E9uth3WhYbh9QV",
      "entity": "payment",
      "amount": 100,
      "currency": "INR",
      "status": "captured",
      "order_id": null,
      "invoice_id": null,
      "international": null,
      "method": "transfer",
      "amount_refunded": 0,
      "refund_status": null,
      "captured": true,
      "description": null,
      "card_id": null,
      "bank": null,
      "wallet": null,
      "vpa": null,
      "email": "",
      "contact": null,
      "notes": [],
      "fee": 0,
      "tax": 0,
      "error_code": null,
      "error_description": null,
      "created_at": 1580219046
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Reverse transfers from all linked accounts

```C#
string transferId = "trf_EAznuJ9cDLnF7Y";

Dictionary<string, object> transferRequest = new Dictionary<string, object>();
transferRequest.Add("amount","100");
 
Reversal transfer = client.Transfer.Fetch(transferId).Reversal(transferRequest);
```

**Parameters:**

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| transferId (mandatory) | string      | The id of the transfer to be fetched  |
| amount      | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |

**Response:**
```json
{
  "id": "rvrsl_EB0BWgGDAu7tOz",
  "entity": "reversal",
  "transfer_id": "trf_EAznuJ9cDLnF7Y",
  "amount": 100,
  "fee": 0,
  "tax": 0,
  "currency": "INR",
  "notes": [],
  "initiator_id": "CJoeHMNpi0nC7k",
  "customer_refund_id": null,
  "created_at": 1580456007
}
```
-------------------------------------------------------------------------------------------------------

### Hold settlements for transfers
```C#
string paymentId = "pay_EB1R2s8D4vOAKG";

Dictionary<string, object> transferRequest = new Dictionary<string, object>();
List<Dictionary<string, object>> transfers = new List<Dictionary<string, object>>();
Dictionary<string, object> transferParams = new Dictionary<string, object>();
transferParams.Add("account","acc_I0QRP7PpvaHhpB");
transferParams.Add("amount",100);
transferParams.Add("currency","INR");
transferParams.Add("on_hold",true);
transfers.Add(transferParams);
transferRequest.Add("transfers", transfers);

List<Transfer> transfer = client.Payment.Fetch(paymentId).Transfer(transferRequest);
```

**Parameters:**

| Name      | Type        | Description                                 |
|-----------|-------------|---------------------------------------------|
| paymentId (mandatory) | string      | The id of the payment to be fetched  |
| transfer  | object     | All parameters listed here https://razorpay.com/docs/api/route/#hold-settlements-for-transfers are supported |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "trf_Jfm1KCF6w1oWgy",
      "entity": "transfer",
      "status": "pending",
      "source": "pay_JXPULbHbkkkS8D",
      "recipient": "acc_I0QRP7PpvaHhpB",
      "amount": 100,
      "currency": "INR",
      "amount_reversed": 0,
      "notes": [],
      "linked_account_notes": [],
      "on_hold": true,
      "on_hold_until": null,
      "recipient_settlement_id": null,
      "created_at": 1654860101,
      "processed_at": null,
      "error": {
        "code": null,
        "description": null,
        "reason": null,
        "field": null,
        "step": null,
        "id": "trf_Jfm1KCF6w1oWgy",
        "source": null,
        "metadata": null
      }
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Modify settlement hold for transfers
```C#
string transferId = "trf_EB17rqOUbzSCEE";

Dictionary<string, object> transferRequest = new Dictionary<string, object>();
transferRequest.Add("on_hold",true);
transferRequest.Add("on_hold_until",1679691505);   
              
Transfer transfer = client.Transfer.Fetch(transferId).Edit(transferRequest);
```

**Parameters:**

| Name          | Type    | Description                                 |
|---------------|---------|---------------------------------------------|
| transferId (mandatory)   | string      | The id of the transfer to be fetched  |
| on_hold (mandatory)   | boolean      | Possible values is `true` or `false`  |
| on_hold_until   | integer      | Timestamp, in Unix, that indicates until when the settlement of the transfer must be put on hold |

**Response:**
```json
{
    "entity": "collection",
    "count": 1,
    "items": [
        {
            "id": "trf_JhemwjNekar9Za",
            "entity": "transfer",
            "status": "pending",
            "source": "pay_I7watngocuEY4P",
            "recipient": "acc_HjVXbtpSCIxENR",
            "amount": 100,
            "currency": "INR",
            "amount_reversed": 0,
            "notes": [],
            "linked_account_notes": [],
            "on_hold": true,
            "on_hold_until": null,
            "recipient_settlement_id": null,
            "created_at": 1655271313,
            "processed_at": null,
            "error": {
                "code": null,
                "description": null,
                "reason": null,
                "field": null,
                "step": null,
                "id": "trf_JhemwjNekar9Za",
                "source": null,
                "metadata": null
            }
        }
    ]
}
```

-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/route/#transfers/)**