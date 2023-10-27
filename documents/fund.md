## Funds

### Create a fund account
```C#
Dictionary<string, object> fundAccountRequest = new Dictionary<string, object>();
fundAccountRequest.Add("customer_id", "cust_Z6t7VFTb9xHeOs");
fundAccountRequest.Add("account_type", "bank_account");
Dictionary<string, object> bankAccount = new Dictionary<string, object>();
bankAccount.Add("name","Gaurav Kumar");
bankAccount.Add("account_number","11214311215411");
bankAccount.Add("ifsc","HDFC0000053");
fundAccountRequest.Add("bank_account", bankAccount);

FundAccount fundaccount = client.FundAccount.Create(fundAccountRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| customerId*   | string      | The id of the customer to be fetched  |
| account_type* | string      | The bank_account to be linked to the customer ID  |
| bank_account* | object      | All keys listed [here](https://razorpay.com/docs/payments/customers/customer-fund-account-api/#create-a-fund-account) are supported |

**Response:**
```json
{
  "id":"fa_Aa00000000001",
  "entity":"fund_account",
  "customer_id":"cust_Aa000000000001",
  "account_type":"bank_account",
  "bank_account":{
    "name":"Gaurav Kumar",
    "account_number":"11214311215411",
    "ifsc":"HDFC0000053",
    "bank_name":"HDFC Bank"
  },
  "active":true,
  "created_at":1543650891
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all fund accounts

```C#
Dictionary<string, object> fundAccountRequest = new Dictionary<string, object>();
fundAccountRequest.Add("customer_id","cust_Z6t7VFTb9xHeOs");

List<FundAccount> fundaccount = client.FundAccount.All(fundAccountRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| customerId*   | string      | The id of the customer to be fetched  |

**Response:**
```json
{
    "entity": "collection",
    "count": 2,
    "items": [
        {
            "id": "fa_Z6t7VFTb9xHeOs",
            "entity": "fund_account",
            "customer_id": "cust_Z6t7VFTb9xHeOs",
            "account_type": "bank_account",
            "bank_account": {
                "ifsc": "HDFC0000053",
                "bank_name": "HDFC Bank",
                "name": "Gaurav Kumar",
                "notes": [],
                "account_number": "11214311215411"
            },
            "batch_id": null,
            "active": true,
            "created_at": 1654154246
        }
    ]
}
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/payments/customers/customer-fund-account-api/)**