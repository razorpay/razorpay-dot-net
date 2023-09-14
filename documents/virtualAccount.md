## Virtual account

### Create a virtual account
```C#
Dictionary<string, object> virtualRequest = new Dictionary<string, object>();
string[] types = { "bank_account" };
Dictionary<string, object> typesParam = new Dictionary<string, object>();
typesParam.Add("types", types);
virtualRequest.Add("receivers", typesParam);
virtualRequest.Add("description", "Virtual Account created for Raftar Soft");
virtualRequest.Add("customer_id", "cust_JDdNazagOgg9Ig");
virtualRequest.Add("close_by", 1681615838);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("project_name", "Banking Software");
virtualRequest.Add("notes", notes);

VirtualAccount virtualaccount = client.VirtualAccount.Create(virtualRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| receivers (mandatory)    | object      | All parameters listed [here](https://razorpay.com/docs/api/payments/smart-collect/#create-virtual-account) are supported |
| description  | string      | A brief description of the virtual account.                    |
| customer_id  | string      | Unique identifier of the customer to whom the virtual account must be tagged.                    |
| close_by  | integer      | UNIX timestamp at which the virtual account is scheduled to be automatically closed.                  |
| notes  | integer      | Any custom notes you might want to add to the virtual account can be entered here.                  |

**Response:**
```json
{
  "id":"va_Z6t7VFTb9xHeOs",
  "name":"Acme Corp",
  "entity":"virtual_account",
  "status":"active",
  "description":"Virtual Account created for Raftar Soft",
  "amount_expected":null,
  "notes":{
    "project_name":"Banking Software"
  },
  "amount_paid":0,
  "customer_id":"cust_Z6t7VFTb9xHeOs",
  "receivers":[
    {
      "id":"ba_Z6t7VFTb9xHeOs",
      "entity":"bank_account",
      "ifsc":"RATN0VAAPIS",
      "bank_name": "RBL Bank",
      "name":"Acme Corp",
      "notes":[],
      "account_number":"2223330099089860"
    }
  ],
  "close_by":1681615838,
  "closed_at":null,
  "created_at":1574837626
}
```

-------------------------------------------------------------------------------------------------------

### Create a virtual account with TPV

```C#

Dictionary<string, object> virtualRequest = new Dictionary<string, object>();
List<string> types = new List<string>();
Dictionary<string, object> typesParam = new Dictionary<string, object>();
types.Add("bank_account");
typesParam.Add("types", types);
virtualRequest.Add("receivers", typesParam);
List<Dictionary<string, object>> allowedPayer = new List<Dictionary<string, object>>();
Dictionary<string, object> allowedPayerParams = new Dictionary<string, object>();
allowedPayerParams.Add("type", "bank_account");
Dictionary<string, object> bankAccount = new Dictionary<string, object>();
bankAccount.Add("ifsc", "UTIB0000013");
bankAccount.Add("account_number", "914010012345679");
allowedPayer.Add(allowedPayerParams);
allowedPayerParams.Add("bank_account", bankAccount);
virtualRequest.Add("allowed_payers", allowedPayer);
virtualRequest.Add("description", "Virtual Account created for Raftar Soft");
virtualRequest.Add("customer_id", "cust_JDdNazagOgg9Ig");
virtualRequest.Add("close_by", 1681615838);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("project_name", "Banking Software");
virtualRequest.Add("notes", notes);

VirtualAccount virtualaccount = client.VirtualAccount.Create(virtualRequest);

```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| receivers (mandatory)    | object      | Array that defines what receivers are available for this Virtual Account                        |
| allowed_payers (mandatory)  | object      | All parameters listed [here](https://razorpay.com/docs/api/smart-collect-tpv/#create-virtual-account) are supported |
| description  | string      | A brief description of the virtual account.                    |
| customer_id  | string      | Unique identifier of the customer to whom the virtual account must be tagged.                    |
| notes  | integer      | Any custom notes you might want to add to the virtual account can be entered here.                  |

**Response:**
```json
{
  "id":"va_Z6t7VFTb9xHeOs",
  "name":"Acme Corp",
  "entity":"virtual_account",
  "status":"active",
  "description":"Virtual Account created for Raftar Soft",
  "amount_expected":null,
  "notes":{
    "project_name":"Banking Software"
  },
  "amount_paid":0,
  "customer_id":"cust_Z6t7VFTb9xHeOs",
  "receivers":[
    {
      "id":"ba_Z6t7VFTb9xHeOs",
      "entity":"bank_account",
      "ifsc":"RATN0VAAPIS",
      "bank_name": "RBL Bank",
      "name":"Acme Corp",
      "notes":[],
      "account_number":"2223330099089860"
    }
  ],
  "allowed_payers": [
    {
      "type": "bank_account",
      "id":"ba_Z6t7VFTb9xHeOs",
      "bank_account": {
        "ifsc": "UTIB0000013",
        "account_number": "914010012345679"
      }
    },
    {
      "type": "bank_account",
      "id":"ba_Z6t7VFTb9xHeOs",
      "bank_account": {
        "ifsc": "UTIB0000014",
        "account_number": "914010012345680"
      }
    }
  ],
  "close_by":1681615838,
  "closed_at":null,
  "created_at":1574837626
}
```

-------------------------------------------------------------------------------------------------------

### Create static/dynamic qr

```C#
Dictionary<string, object> virtualRequest = new Dictionary<string, object>();
List<string> types = new List<string>();
Dictionary<string, object> typesParam = new Dictionary<string, object>();
types.Add("qr_code");
typesParam.Add("types",types);
virtualRequest.Add("receivers",typesParam);
virtualRequest.Add("description","Virtual Account created for Raftar Soft");
virtualRequest.Add("amount_expected",100);
virtualRequest.Add("close_by",1681615838);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("project_name","Banking Software");
virtualRequest.Add("notes", notes);

VirtualAccount virtualaccount = instance.virtualAccounts.create(virtualRequest);

```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| receivers (mandatory)    | array      | Array that defines what receivers are available for this Virtual Account                        |
| description  | string      | A brief description of the payment.   |
| amount_expected  | integer   | The maximum amount you expect to receive in this virtual account. Pass `69999` for ₹699.99.   |
| customer_id  | string      | Unique identifier of the customer to whom the virtual account must be tagged.                    |
| notes       | object | All keys listed [here](https://razorpay.com/docs/payments/payments/payment-methods/bharatqr/api/#create) are supported   |

**Response:**
```json
{
  "id": "va_Z6t7VFTb9xHeOs",
  "name": "Acme Corp",
  "entity": "virtual_account",
  "status": "active",
  "description": "First Payment by BharatQR",
  "amount_expected": null,
  "notes": {
    "reference_key": "reference_value"
  },
  "amount_paid": 0,
  "customer_id": "cust_Z6t7VFTb9xHeOs",
  "receivers": [
    {
      "id": "qr_Z6t7VFTb9xHeOs",
      "entity": "qr_code",
      "reference": "AgdeP8aBgZGckl",
      "short_url": "https://rzp.io/i/PLs03pOc"
    }
  ],
  "close_by": null,
  "closed_at": null,
  "created_at": 1607938184
}
```
-------------------------------------------------------------------------------------------------------

### Fetch virtual account by id

```C#
string virtualId = "va_Z6t7VFTb9xHeOs";

VirtualAccount virtualaccount = client.VirtualAccount.Fetch(virtualId);
```

**Parameters:**

| Name       | Type        | Description                                 |
|------------|-------------|---------------------------------------------|
| virtualId (mandatory) | string      | The id of the virtual to be updated  |

**Response:**

For fetch virtual account by id response please click [here](https://razorpay.com/docs/api/smart-collect/#fetch-a-virtual-account-by-id)
-------------------------------------------------------------------------------------------------------

### Fetch all virtual account
```C#
Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("count","1");

List<VirtualAccount> virtualaccount = client.VirtualAccount.All(param);
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
  "count": 1,
  "items": [
    {
      "id": "va_Z6t7VFTb9xHeOs",
      "name": "Acme Corp",
      "entity": "virtual_account",
      "status": "closed",
      "description": "Virtual Account created for M/S ABC Exports",
      "amount_expected": 2300,
      "notes": {
        "material": "teakwood"
      },
      "amount_paid": 239000,
      "customer_id": "cust_Z6t7VFTb9xHeOs",
      "receivers": [
        {
          "id": "ba_Di5gbQsGn0QSz3",
          "entity": "bank_account",
          "ifsc": "RATN0VAAPIS",
          "bank_name": "RBL Bank",
          "name": "Acme Corp",
          "notes": [],
          "account_number": "1112220061746877"
        }
      ],
      "close_by": 1574427237,
      "closed_at": 1574164078,
      "created_at": 1574143517
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch payments for a virtual account
```C#
string virtualId = "va_Z6t7VFTb9xHeOs";

Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("count","1");
        
List<Payment> virtualaccount = client.VirtualAccount.Fetch(virtualId).Payments(param);
```

**Parameters:**

| Name       | Type      | Description                                      |
|------------|-----------|--------------------------------------------------|
| virtualId (mandatory) | string    | The id of the virtual to be updated  |
| from       | timestamp | timestamp after which the payments were created  |
| to         | timestamp | timestamp before which the payments were created |
| count      | integer   | number of payments to fetch (default: 10)        |
| skip       | integer   | number of payments to be skipped (default: 0)    |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "pay_Z6t7VFTb9xHeOs",
      "entity": "payment",
      "amount": 239000,
      "currency": "INR",
      "status": "captured",
      "order_id": null,
      "invoice_id": null,
      "international": false,
      "method": "bank_transfer",
      "amount_refunded": 0,
      "refund_status": null,
      "captured": true,
      "description": "",
      "card_id": null,
      "bank": null,
      "wallet": null,
      "vpa": null,
      "email": "saurav.kumar@example.com",
      "contact": "+919999999999",
      "customer_id": "cust_Z6t7VFTb9xHeOs",
      "notes": [],
      "fee": 2820,
      "tax": 430,
      "error_code": null,
      "error_description": null,
      "created_at": 1574143644
    }
  ]
}
```

-------------------------------------------------------------------------------------------------------

### Fetch payment details using id and transfer method
```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

BankTransfer virtualaccount = client.Payment.Fetch(paymentId).BankTransfers();
```

**Parameters:**

| Name       | Type      | Description                         |
|------------|-----------|-------------------------------------|
| paymentId (mandatory) | string    | The id of the payment to be updated |

**Response:**
```json
{
  "id": "bt_Z6t7VFTb9xHeOs",
  "entity": "bank_transfer",
  "payment_id": "pay_Z6t7VFTb9xHeOs",
  "mode": "NEFT",
  "bank_reference": "157414364471",
  "amount": 239000,
  "payer_bank_account": {
    "id": "ba_Di5iqSxtYrTzPU",
    "entity": "bank_account",
    "ifsc": "UTIB0003198",
    "bank_name": "Axis Bank",
    "name": "Acme Corp",
    "notes": [],
    "account_number": "765432123456789"
  },
  "virtual_account_id": "va_Z6t7VFTb9xHeOs",
  "virtual_account": {
    "id": "va_Z6t7VFTb9xHeOs",
    "name": "Acme Corp",
    "entity": "virtual_account",
    "status": "closed",
    "description": "Virtual Account created for M/S ABC Exports",
    "amount_expected": 2300,
    "notes": {
      "material": "teakwood"
    },
    "amount_paid": 239000,
    "customer_id": "cust_Z6t7VFTb9xHeOs",
    "receivers": [
      {
        "id": "ba_Z6t7VFTb9xHeOs",
        "entity": "bank_account",
        "ifsc": "RATN0VAAPIS",
        "bank_name": "RBL Bank",
        "name": "Acme Corp",
        "notes": [],
        "account_number": "1112220061746877"
      }
    ],
    "close_by": 1574427237,
    "closed_at": 1574164078,
    "created_at": 1574143517
  }
}
```
-------------------------------------------------------------------------------------------------------

### Refund payments made to a virtual account
```C#
string paymentId = "pay_Z6t7VFTb9xHeOs";

Dictionary<string, object> refundRequest = new Dictionary<string, object>();
refundRequest.Add("amount", 100);
refundRequest.Add("speed", "normal");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
refundRequest.Add("notes", notes);
refundRequest.Add("receipt", "Receipt No. #32");

Refund refund = client.Payment.Fetch(paymentId).Refund(refundRequest);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| paymentId (mandatory)  | string    | The id of the payment to be updated  |
|  amount       | integer      | The amount to be captured (should be equal to the authorized amount, in paise) |                       |
|  speed        | string      | Here, it must be normal                |
|  notes        | array       | A key-value pair                |
|  receipt      | string      | A unique identifier provided by you for your internal reference. |

**Response:**
```json
{
  "id": "rfnd_Z6t7VFTb9xHeOs",
  "entity": "refund",
  "amount": 100,
  "currency": "INR",
  "payment_id": "pay_Z6t7VFTb9xHeOs",
  "notes": {
    "key_1": "value1",
    "key_2": "value2"
  },
  "receipt": null,
  "acquirer_data": {
    "rrn": null
  },
  "created_at": 1579522301
}
```
-------------------------------------------------------------------------------------------------------

### Add receiver to an existing virtual account
```C#
string virtualId = "va_Z6t7VFTb9xHeOs";

Dictionary<string, object> virtualRequest = new Dictionary<string, object>();
List<string> types = new List<string>();
types.Add("vpa");
virtualRequest.Add("types", types);
Dictionary<string, object> vpa = new Dictionary<string, object>();
vpa.Add("descriptor", "gaurikumar");
virtualRequest.Add("vpa", vpa);

VirtualAccount refund = client.VirtualAccount.Fetch(virtualId).AddReceiver(virtualRequest);
```

**Parameters:**

| Name       | Type      | Description                                      |
|------------|-----------|--------------------------------------------------|
| virtualId (mandatory) | string    | The id of the virtual to be updated  |
| types (mandatory)     | object | The receiver type to be added to the virtual account. Possible values are `vpa` or `bank_account`  |
| vpa        | object | This is to be passed only when `vpa` is passed as the receiver types. |

**Response:**

For add receiver to an existing virtual account response please click [here](https://razorpay.com/docs/api/smart-collect/#add-receiver-to-an-existing-virtual-account)

-------------------------------------------------------------------------------------------------------

### Add an Allowed Payer Account
```C#
String virtualId = "va_Z6t7VFTb9xHeOs";

Dictionary<string, object> virtualRequest = new Dictionary<string, object>();
virtualRequest.Add("type", "bank_account");
Dictionary<string, object> vpa = new Dictionary<string, object>();
vpa.Add("ifsc", "UTIB0000013");
vpa.Add("account_number", "914012112345679");
virtualRequest.Add("bank_account", vpa);

VirtualAccount refund = client.VirtualAccount.Fetch("va_MaxCJzVjbKRBAr").AddAllowedPayers(virtualRequest);
```

**Parameters:**

| Name          | Type      | Description                                      |
|---------------|-----------|--------------------------------------------------|
| virtualId (mandatory)    | string    | The id of the virtual to be updated  |
| type (mandatory)        | object | The receiver type to be added to the virtual account. Possible values are `vpa` or `bank_account`  |
| bank_account (mandatory) | object | Indicates the bank account details such as `ifsc` and `account_number` |

**Response:**
```json
{
  "id":"va_Z6t7VFTb9xHeOs",
  "name":"Acme Corp",
  "entity":"virtual_account",
  "status":"active",
  "description":"Virtual Account created for Raftar Soft",
  "amount_expected":null,
  "notes":{
    "project_name":"Banking Software"
  },
  "amount_paid":0,
  "customer_id":"cust_Z6t7VFTb9xHeOs",
  "receivers":[
    {
      "id":"ba_Z6t7VFTb9xHeOs",
      "entity":"bank_account",
      "ifsc":"RATN0VAAPIS",
      "bank_name": "RBL Bank",
      "name":"Acme Corp",
      "notes":[],
      "account_number":"2223330099089860"
    }
  ],
  "allowed_payers": [
    {
      "type": "bank_account",
      "id":"ba_Z6t7VFTb9xHeOs",
      "bank_account": {
        "ifsc": "UTIB0000013",
        "account_number": "914010012345679"
      }
    }
  ],
  "close_by":1681615838,
  "closed_at":null,
  "created_at":1574837626
}
```
-------------------------------------------------------------------------------------------------------
### Close virtual account
```C#
string virtualId = "va_Z6t7VFTb9xHeOs";

VirtualAccount virtulaccount = client.VirtualAccount.Fetch("va_MaxCJzVjbKRBAr").Close();
```

**Parameters:**

| Name       | Type      | Description                                      |
|------------|-----------|--------------------------------------------------|
| virtualId (mandatory) | string    | The id of the virtual to be updated  |

**Response:**

For close virtual account response please click [here](https://razorpay.com/docs/api/smart-collect/#close-a-virtual-account)

-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/smart-collect/api/)**