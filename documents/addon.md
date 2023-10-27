## Addons

### Create an addon

```C#
string subscriptionId = "sub_Z6t7VFTb9xHeOs";

Dictionary<string, object> addonRequest = new Dictionary<string, object>();
Dictionary<string, object> items = new Dictionary<string, object>();
items.Add("name", "Extra appala (papadum)");
items.Add("amount", "3000");
items.Add("currency", "INR");
items.Add("description", "1 extra oil fried appala with meals");
addonRequest.Add("item", items);
addonRequest.Add("quantity", 2);

Addon addon = client.Subscription.Fetch(subscriptionId).CreateAddon(addonRequest);
```

**Parameters:**

| Name            | Type      | Description                                      |
|-----------------|-----------|--------------------------------------------------|
| subscriptionId (mandatory) | boolean | The subscription ID to which the add-on is being added. |
| items (mandatory)          | object | Details of the add-on you want to create. |
| quantity (mandatory)       | integer | This specifies the number of units of the add-on to be charged to the customer. |

**Response:**
```json
{
  "id":"ao_00000000000001",
  "entity":"addon",
  "item":{
    "id":"item_00000000000001",
    "active":true,
    "name":"Extra appala (papadum)",
    "description":"1 extra oil fried appala with meals",
    "amount":30000,
    "unit_amount":30000,
    "currency":"INR",
    "type":"addon",
    "unit":null,
    "tax_inclusive":false,
    "hsn_code":null,
    "sac_code":null,
    "tax_rate":null,
    "tax_id":null,
    "tax_group_id":null,
    "created_at":1581597318,
    "updated_at":1581597318
  },
  "quantity":2,
  "created_at":1581597318,
  "subscription_id":"sub_00000000000001",
  "invoice_id":null
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all addons

```C#
Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.Add("count","1");

List<Addon> addon = client.Addon.All(paramRequest);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|---------------------------------------------------|
| from  |  timestamp | timestamp after which the payments were created  |
| to    |  timestamp | timestamp before which the payments were created |
| count |  integer   | number of payments to fetch (default: 10)        |
| skip  |  integer   | number of payments to be skipped (default: 0)    |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "ao_00000000000002",
      "entity": "addon",
      "item": {
        "id": "item_00000000000002",
        "active": true,
        "name": "Extra sweet",
        "description": "1 extra sweet of the day with meals",
        "amount": 90000,
        "unit_amount": 90000,
        "currency": "INR",
        "type": "addon",
        "unit": null,
        "tax_inclusive": false,
        "hsn_code": null,
        "sac_code": null,
        "tax_rate": null,
        "tax_id": null,
        "tax_group_id": null,
        "created_at": 1581597318,
        "updated_at": 1581597318
      },
      "quantity": 1,
      "created_at": 1581597318,
      "subscription_id": "sub_00000000000001",
      "invoice_id": "inv_00000000000001"
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch an addon

```C#
String addonId = "ao_00000000000001";

Addon addon = client.Addon.Fetch(addonId);
```

**Parameters:**

| Name     | Type    | Description     |
|----------|---------|------------------------------------|
| addonId (mandatory) | string | addon id to be fetched            |

**Response:**
```json
{
  "id":"ao_00000000000001",
  "entity":"addon",
  "item":{
    "id":"item_00000000000001",
    "active":true,
    "name":"Extra appala (papadum)",
    "description":"1 extra oil fried appala with meals",
    "amount":30000,
    "unit_amount":30000,
    "currency":"INR",
    "type":"addon",
    "unit":null,
    "tax_inclusive":false,
    "hsn_code":null,
    "sac_code":null,
    "tax_rate":null,
    "tax_id":null,
    "tax_group_id":null,
    "created_at":1581597318,
    "updated_at":1581597318
  },
  "quantity":2,
  "created_at":1581597318,
  "subscription_id":"sub_00000000000001",
  "invoice_id":null
}
```
-------------------------------------------------------------------------------------------------------

### Delete an addon

```C#
string addonId = "ao_00000000000001";

List<Addon> addon = client.Addon.Fetch(addonId).Delete();
```

**Parameters:**

| Name     | Type    | Description                                                                  |
|----------|---------|------------------------------------------------------------------------------|
| addonId (mandatory) | string | addon id to be deleted |

**Response:**
```json
[]
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/subscriptions/#add-ons)**