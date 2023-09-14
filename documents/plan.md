## Plans

### Create plan

```C#
Dictionary<string, object> planRequest = new Dictionary<string, object>();
planRequest.Add("period", "weekly");
planRequest.Add("interval", 1);
Dictionary<string, object> item = new Dictionary<string, object>();
item.Add("name", "Test plan - Weekly");
item.Add("amount", 69900);
item.Add("currency", "INR");
item.Add("description", "Description for the test plan");
planRequest.Add("item", item);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
planRequest.Add("notes", notes);

Plan plan = client.Plan.Create(planRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| period (mandatory)          | string | Used together with `interval` to define how often the customer should be charged.Possible values:<br>1.`daily` <br>2.`weekly`<br>3.`monthly` <br>4.`yearly`  |
| interval (mandatory)          | string | Used together with `period` to define how often the customer should be charged  |
| items (mandatory)          | object | Details of the plan. For more details please refer [here](https://razorpay.com/docs/api/subscriptions/#create-a-plan) |
| notes          | object | Notes you can enter for the contact for future reference.   |

**Response:**
```json
{
  "id":"plan_00000000000001",
  "entity":"plan",
  "interval":1,
  "period":"weekly",
  "item":{
    "id":"item_00000000000001",
    "active":true,
    "name":"Test plan - Weekly",
    "description":"Description for the test plan - Weekly",
    "amount":69900,
    "unit_amount":69900,
    "currency":"INR",
    "type":"plan",
    "unit":null,
    "tax_inclusive":false,
    "hsn_code":null,
    "sac_code":null,
    "tax_rate":null,
    "tax_id":null,
    "tax_group_id":null,
    "created_at":1580219935,
    "updated_at":1580219935
  },
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "created_at":1580219935
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all plans

```C#
Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.Add("count","1");

List<Plan> plan = client.Plan.All(paramRequest);
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
      "id": "plan_00000000000001",
      "entity": "plan",
      "interval": 1,
      "period": "weekly",
      "item": {
        "id": "item_00000000000001",
        "active": true,
        "name": "Test plan - Weekly",
        "description": "Description for the test plan - Weekly",
        "amount": 69900,
        "unit_amount": 69900,
        "currency": "INR",
        "type": "plan",
        "unit": null,
        "tax_inclusive": false,
        "hsn_code": null,
        "sac_code": null,
        "tax_rate": null,
        "tax_id": null,
        "tax_group_id": null,
        "created_at": 1580220492,
        "updated_at": 1580220492
      },
      "notes": {
        "notes_key_1": "Tea, Earl Grey, Hot",
        "notes_key_2": "Tea, Earl Grey… decaf."
      },
      "created_at": 1580220492
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch particular plan

```C#
String planId = "plan_00000000000001";

Plan plan = client.Plan.Fetch(planId);
```

**Parameters:**

| Name   | Type      | Description                                      |
|--------|-----------|--------------------------------------------------|
| planId (mandatory) | string | The id of the plan to be fetched  |

**Response:**
```json
{
  "id":"plan_00000000000001",
  "entity":"plan",
  "interval":1,
  "period":"weekly",
  "item":{
    "id":"item_00000000000001",
    "active":true,
    "name":"Test plan - Weekly",
    "description":"Description for the test plan - Weekly",
    "amount":69900,
    "unit_amount":69900,
    "currency":"INR",
    "type":"plan",
    "unit":null,
    "tax_inclusive":false,
    "hsn_code":null,
    "sac_code":null,
    "tax_rate":null,
    "tax_id":null,
    "tax_group_id":null,
    "created_at":1580220492,
    "updated_at":1580220492
  },
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "created_at":1580220492
}
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/subscriptions/#plans)**