## Subscriptions

### Create subscription

```c#
Dictionary<string, object> subscriptionRequest = new Dictionary<string, object>();
subscriptionRequest.Add("plan_id", "plan_Z6t7VFTb9xHeOs");
subscriptionRequest.Add("total_count", 6);
subscriptionRequest.Add("quantity", 1);
subscriptionRequest.Add("customer_notify", 1);
subscriptionRequest.Add("start_at", 1580453311);
subscriptionRequest.Add("expire_by", 1580626111);
Dictionary<string, object> linesItem = new Dictionary<string, object>();
Dictionary<string, object> item = new Dictionary<string, object>();
item.Add("name", "Delivery charges");
item.Add("amount", 30000);
item.Add("currency", "INR");
linesItem.Add("item", item);
object[] addons = new object[]{ linesItem };
subscriptionRequest.Add("addons", addons);
subscriptionRequest.Add("offer_id", "offer_LFw2SqDBi8kf53");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
subscriptionRequest.Add("notes", notes);

Subscription subscription = client.Subscription.Create(subscriptionRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| plan_id (mandatory)          | string | The unique identifier for a plan that should be linked to the subscription.|
| total_count (mandatory)   | string | The number of billing cycles for which the customer should be charged  |
| customer_notify    | boolean | Indicates whether the communication to the customer would be handled by you or us |
| quantity    | integer | The number of times the customer should be charged the plan amount per invoice |
| start_at    | integer | The timestamp, in Unix format, for when the subscription should start. If not passed, the subscription starts immediately after the authorization payment. |
| expire_by    | integer | The timestamp, in Unix format, till when the customer can make the authorization payment. |
| addons    | object | Object that contains details of any upfront amount you want to collect as part of the authorization transaction. |
| notes          | object | Notes you can enter for the contact for future reference.   |
| offer_id   | string | The unique identifier of the offer that is linked to the subscription. |

**Response:**
```json
{
  "id": "sub_00000000000001",
  "entity": "subscription",
  "plan_id": "plan_00000000000001",
  "status": "created",
  "current_start": null,
  "current_end": null,
  "ended_at": null,
  "quantity": 1,
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "charge_at": 1580453311,
  "start_at": 1580626111,
  "end_at": 1583433000,
  "auth_attempts": 0,
  "total_count": 6,
  "paid_count": 0,
  "customer_notify": true,
  "created_at": 1580280581,
  "expire_by": 1580626111,
  "short_url": "https://rzp.io/i/z3b1R61A9",
  "has_scheduled_changes": false,
  "change_scheduled_at": null,
  "source": "api",
  "offer_id":"offer_Z6t7VFTb9xHeOs",
  "remaining_count": 5
}
```
-------------------------------------------------------------------------------------------------------

### Create subscription link

```C#
Dictionary<string, object> subscriptionRequest = new Dictionary<string, object>();
subscriptionRequest.Add("plan_id", "plan_Z6t7VFTb9xHeOs");
subscriptionRequest.Add("total_count", 12);
subscriptionRequest.Add("quantity", 1);
subscriptionRequest.Add("customer_notify", 1);
subscriptionRequest.Add("start_at", 1580453311);
subscriptionRequest.Add("expire_by", 1580626111);
List<Dictionary<string, object>> addons = new List<Dictionary<string, object>>();
Dictionary<string, object> linesItem = new Dictionary<string, object>();
Dictionary<string, object> item = new Dictionary<string, object>();
item.Add("name", "Delivery charges");
item.Add("amount", 30000);
item.Add("currency", "INR");
linesItem.Add("item", item);
addons.Add(linesItem);
subscriptionRequest.Add("addons", addons);
subscriptionRequest.Add("offer_id", "offer_Z6t7VFTb9xHeOs");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
subscriptionRequest.Add("notes", notes);
Dictionary<string, object> notifyInfo = new Dictionary<string, object>();
notifyInfo.Add("notify_phone", "9999999999");
notifyInfo.Add("notify_email", "gaurav.kumar@example.com");
subscriptionRequest.Add("notify_info", notifyInfo);

Subscription subscription = client.Subscription.Create(subscriptionRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| plan_id (mandatory)          | string | The unique identifier for a plan that should be linked to the subscription.|
| total_count (mandatory)   | string | The number of billing cycles for which the customer should be charged  |
| customer_notify    | boolean | Indicates whether the communication to the customer would be handled by you or us |
| quantity    | integer | The number of times the customer should be charged the plan amount per invoice |
| start_at    | integer | The timestamp, in Unix format, for when the subscription should start. If not passed, the subscription starts immediately after the authorization payment. |
| expire_by    | integer | The timestamp, in Unix format, till when the customer can make the authorization payment. |
| addons    | object | Object that contains details of any upfront amount you want to collect as part of the authorization transaction. |
| notes          | object | Notes you can enter for the contact for future reference.   |
| notify_info          | object | The customer's email and phone number to which notifications are to be sent. (PN: Use this object only if you have set the `customer_notify` parameter to 1. That is, Razorpay sends notifications to the customer.)  |
| offer_id   | string | The unique identifier of the offer that is linked to the subscription. |

**Response:**
```json
{
  "id":"sub_00000000000002",
  "entity":"subscription",
  "plan_id":"plan_00000000000001",
  "status":"created",
  "current_start":null,
  "current_end":null,
  "ended_at":null,
  "quantity":1,
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "charge_at":1580453311,
  "start_at":1580453311,
  "end_at":1587061800,
  "auth_attempts":0,
  "total_count":12,
  "paid_count":0,
  "customer_notify":true,
  "created_at":1580283117,
  "expire_by":1581013800,
  "short_url":"https://rzp.io/i/m0y0f",
  "has_scheduled_changes":false,
  "change_scheduled_at":null,
  "source": "api",
  "offer_id":"offer_Z6t7VFTb9xHeOs",
  "remaining_count":12
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all subscriptions

```C#
Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.Add("count","1");

List<Subscription> subscription = client.Subscription.All(paramRequest);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| from  | timestamp | timestamp after which the payments were created  |
| to    | timestamp | timestamp before which the payments were created |
| count | integer   | number of payments to fetch (default: 10)        |
| skip  | integer   | number of payments to be skipped (default: 0)    |
| plan_id  | string   | The unique identifier of the plan for which you want to retrieve all the subscriptions    |

**Response:**
```json

{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "sub_00000000000001",
      "entity": "subscription",
      "plan_id": "plan_00000000000001",
      "customer_id": "cust_D00000000000001",
      "status": "active",
      "current_start": 1577355871,
      "current_end": 1582655400,
      "ended_at": null,
      "quantity": 1,
      "notes": {
        "notes_key_1": "Tea, Earl Grey, Hot",
        "notes_key_2": "Tea, Earl Grey… decaf."
      },
      "charge_at": 1577385991,
      "offer_id": "offer_JHD834hjbxzhd38d",
      "start_at": 1577385991,
      "end_at": 1603737000,
      "auth_attempts": 0,
      "total_count": 6,
      "paid_count": 1,
      "customer_notify": true,
      "created_at": 1577356081,
      "expire_by": 1577485991,
      "short_url": "https://rzp.io/i/z3b1R61A9",
      "has_scheduled_changes": false,
      "change_scheduled_at": null,
      "remaining_count": 5
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch particular subscription

```C#
String subscriptionId = "sub_00000000000001";

Subscription subscription = client.Subscription.Fetch(subscriptionId);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| subscriptionId (mandatory)  | string | The id of the subscription to be fetched  |

**Response:**
```json
{
  "id": "sub_00000000000001",
  "entity": "subscription",
  "plan_id": "plan_00000000000001",
  "customer_id": "cust_D00000000000001",
  "status": "active",
  "current_start": 1577355871,
  "current_end": 1582655400,
  "ended_at": null,
  "quantity": 1,
  "notes":{
    "notes_key_1": "Tea, Earl Grey, Hot",
    "notes_key_2": "Tea, Earl Grey… decaf."
  },
  "charge_at": 1577385991,
  "start_at": 1577385991,
  "end_at": 1603737000,
  "auth_attempts": 0,
  "total_count": 6,
  "paid_count": 1,
  "customer_notify": true,
  "created_at": 1577356081,
  "expire_by": 1577485991,
  "short_url": "https://rzp.io/i/z3b1R61A9",
  "has_scheduled_changes": false,
  "change_scheduled_at": null,
  "source": "api",
  "offer_id":"offer_JHD834hjbxzhd38d",
  "remaining_count": 5
}
```

-------------------------------------------------------------------------------------------------------

### Cancel particular subscription

```C#
String subscriptionId = "sub_00000000000001";

Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("cancel_at_cycle_end", 1);

Subscription subscription = client.Subscription.Fetch(subscriptionId).Cancel(param);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| subscriptionId (mandatory)  | string | The id of the subscription to be cancelled  |
| cancel_at_cycle_end  | boolean | Possible values:<br>0 (default): Cancel the subscription immediately. <br> 1: Cancel the subscription at the end of the current billing cycle.  |

**Response:**
```json
{
  "id": "sub_00000000000001",
  "entity": "subscription",
  "plan_id": "plan_00000000000001",
  "customer_id": "cust_D00000000000001",
  "status": "cancelled",
  "current_start": 1580453311,
  "current_end": 1581013800,
  "ended_at": 1580288092,
  "quantity": 1,
  "notes":{
    "notes_key_1": "Tea, Earl Grey, Hot",
    "notes_key_2": "Tea, Earl Grey… decaf."
  },
  "charge_at": 1580453311,
  "start_at": 1577385991,
  "end_at": 1603737000,
  "auth_attempts": 0,
  "total_count": 6,
  "paid_count": 1,
  "customer_notify": true,
  "created_at": 1580283117,
  "expire_by": 1581013800,
  "short_url": "https://rzp.io/i/z3b1R61A9",
  "has_scheduled_changes": false,
  "change_scheduled_at": null,
  "source": "api",
  "offer_id":"offer_JHD834hjbxzhd38d",
  "remaining_count": 5
}
```
-------------------------------------------------------------------------------------------------------

### Update particular subscription

```C#

string subscriptionId = "sub_00000000000002";

Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("plan_id","plan_00000000000002");
param.Add("offer_id","offer_JHD834hjbxzhd38d");
param.Add("quantity",5);
param.Add("remaining_count",5);
param.Add("start_at",1496000432);
param.Add("schedule_change_at","now");
param.Add("customer_notify",1);
 
Subscription subscription = client.Subscription.Fetch(subscriptionId).Edit(param);
```

**Parameters:**

| Name            | Type      | Description                                      |
|-----------------|-----------|--------------------------------------------------|
| subscriptionId (mandatory) | string | The id of the subscription to be updated  |
| params          | object | All parameters listed [here](https://razorpay.com/docs/api/subscriptions/#update-a-subscription) for update   |

**Response:**
```json
{
  "id":"sub_00000000000002",
  "entity":"subscription",
  "plan_id":"plan_00000000000002",
  "customer_id":"cust_00000000000002",
  "status":"authenticated",
  "current_start":null,
  "current_end":null,
  "ended_at":null,
  "quantity":3,
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "charge_at":1580453311,
  "start_at":1580453311,
  "end_at":1606588200,
  "auth_attempts":0,
  "total_count":6,
  "paid_count":0,
  "customer_notify":true,
  "created_at":1580283807,
  "expire_by":1580626111,
  "short_url":"https://rzp.io/i/yeDkUKy",
  "has_scheduled_changes":false,
  "change_scheduled_at":null,
  "source": "api",
  "offer_id":"offer_Z6t7VFTb9xHeOs",
  "remaining_count":6
}
```

-------------------------------------------------------------------------------------------------------

### Fetch details of pending update

```C#
string subscriptionId = "sub_00000000000001";

Subscription subscription = client.Subscription.Fetch(subscriptionId).FetchPendingUpdate();
```

**Parameters:**

| Name            | Type      | Description                                      |
|-----------------|-----------|--------------------------------------------------|
| subscriptionId (mandatory) | string | The id of the subscription to fetch pending update  |

**Response:**
```json
{
  "id":"sub_00000000000001",
  "entity":"subscription",
  "plan_id":"plan_00000000000003",
  "customer_id":"cust_00000000000001",
  "status":"active",
  "current_start":1580284732,
  "current_end":1580841000,
  "ended_at":null,
  "quantity":25,
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "charge_at":1580841000,
  "start_at":1580284732,
  "end_at":1611081000,
  "auth_attempts":0,
  "total_count":6,
  "paid_count":1,
  "customer_notify":true,
  "created_at":1580284702,
  "expire_by":1580626111,
  "short_url":"https://rzp.io/i/fFWTkbf",
  "has_scheduled_changes":true,
  "change_scheduled_at":1557253800,
  "source": "api",
  "offer_id":"offer_JHD834hjbxzhd38d",
  "remaining_count":5
}
```
-------------------------------------------------------------------------------------------------------

### Cancel a update

```C#
string subscriptionId = "sub_00000000000001";

Subscription subscription = client.Subscription.Fetch(subscriptionId).CancelPendingUpdate();
```

**Parameters:**

| Name            | Type      | Description                                      |
|-----------------|-----------|--------------------------------------------------|
| subscriptionId* | string | The id of the subscription to be cancel an update  |

**Response:**
```json
{
  "id": "sub_00000000000001",
  "entity": "subscription",
  "plan_id": "plan_00000000000003",
  "customer_id": "cust_00000000000001",
  "status": "active",
  "current_start": 1580284732,
  "current_end": 1580841000,
  "ended_at": null,
  "quantity": 1,
  "notes": {
    "notes_key_1": "Tea, Earl Grey, Hot",
    "notes_key_2": "Tea, Earl Grey… decaf."
  },
  "charge_at": 1580841000,
  "start_at": 1580284732,
  "end_at": 1611081000,
  "auth_attempts": 0,
  "total_count": 6,
  "paid_count": 1,
  "customer_notify": true,
  "created_at": 1580284702,
  "expire_by": 1580626111,
  "short_url": "https://rzp.io/i/fFWTkbf",
  "has_scheduled_changes": false,
  "change_scheduled_at": 1527858600,
  "source": "api",
  "offer_id":"offer_JHD834hjbxzhd38d",
  "remaining_count": 5
}
```
-------------------------------------------------------------------------------------------------------

### Pause a subscription

```C#
string subscriptionId = "sub_00000000000001";

Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("pause_at","now");
        
Subscription subscription = client.Subscription.Fetch(subscriptionId).Pause(param);

```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| subscriptionId (mandatory)  | string | The id of the subscription to be paused  |
| pause_at  | string | To pause the subscription, possible values: `now`  |

**Response:**
```json
{
  "id": "sub_00000000000001",
  "entity": "subscription",
  "plan_id": "plan_00000000000001",
  "status": "paused",
  "current_start": null,
  "current_end": null,
  "ended_at": null,
  "quantity": 1,
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "charge_at": null,
  "start_at": 1580626111,
  "end_at": 1583433000,
  "auth_attempts": 0,
  "total_count": 6,
  "paid_count": 0,
  "customer_notify": true,
  "created_at": 1580280581,
  "paused_at": 1590280581,
  "expire_by": 1580626111,
  "pause_initiated_by": "self",
  "short_url": "https://rzp.io/i/z3b1R61A9",
  "has_scheduled_changes": false,
  "change_scheduled_at": null,
  "source": "api",
  "offer_id":"offer_JHD834hjbxzhd38d",
  "remaining_count": 6
}
```
-------------------------------------------------------------------------------------------------------

### Resume a subscription

```C#
string subscriptionId = "sub_00000000000001";

Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("resume_at","now");
             
Subscription subscription = client.Subscription.Fetch(subscriptionId).Resume(param);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| subscriptionId (mandatory)  | string | The id of the subscription to be resumed  |
| resume_at  | string | To resume the subscription, possible values: `now`  |

**Response:**
```json
{
  "id": "sub_00000000000001",
  "entity": "subscription",
  "plan_id": "plan_00000000000001",
  "status": "active",
  "current_start": null,
  "current_end": null,
  "ended_at": null,
  "quantity": 1,
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "charge_at": 1580453311,
  "start_at": 1580626111,
  "end_at": 1583433000,
  "auth_attempts": 0,
  "total_count": 6,
  "paid_count": 0,
  "customer_notify": true,
  "created_at": 1580280581,
  "paused_at": 1590280581,
  "expire_by": 1580626111,
  "pause_initiated_by": null,
  "short_url": "https://rzp.io/i/z3b1R61A9",
  "has_scheduled_changes": false,
  "change_scheduled_at": null,
  "source": "api",
  "offer_id":"offer_JHD834hjbxzhd38d",
  "remaining_count": 6
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all invoices for a subscription

```C#

Dictionary<string, object> param = new Dictionary<string, object>();
param.Add("subscription_id", "sub_Z6t7VFTb9xHeOs");
              
List<Invoice> subscription = client.Invoice.All(param);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| subscriptionId (mandatory)  | string | The id of the subscription to fetch invoices  |

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "inv_00000000000003",
      "entity": "invoice",
      "receipt": null,
      "invoice_number": null,
      "customer_id": "cust_00000000000001",
      "customer_details": {
        "id": "cust_00000000000001",
        "name": null,
        "email": "gaurav.kumar@example.com",
        "contact": "+919876543210",
        "gstin": null,
        "billing_address": null,
        "shipping_address": null,
        "customer_name": null,
        "customer_email": "gaurav.kumar@example.com",
        "customer_contact": "+919876543210"
      },
      "order_id": "order_00000000000002",
      "subscription_id": "sub_00000000000001",
      "line_items": [
        {
          "id": "li_00000000000003",
          "item_id": null,
          "ref_id": null,
          "ref_type": null,
          "name": "Monthly Plan",
          "description": null,
          "amount": 99900,
          "unit_amount": 99900,
          "gross_amount": 99900,
          "tax_amount": 0,
          "taxable_amount": 99900,
          "net_amount": 99900,
          "currency": "INR",
          "type": "plan",
          "tax_inclusive": false,
          "hsn_code": null,
          "sac_code": null,
          "tax_rate": null,
          "unit": null,
          "quantity": 1,
          "taxes": []
        }
      ],
      "payment_id": "pay_00000000000002",
      "status": "paid",
      "expire_by": null,
      "issued_at": 1593344888,
      "paid_at": 1593344889,
      "cancelled_at": null,
      "expired_at": null,
      "sms_status": null,
      "email_status": null,
      "date": 1593344888,
      "terms": null,
      "partial_payment": false,
      "gross_amount": 99900,
      "tax_amount": 0,
      "taxable_amount": 99900,
      "amount": 99900,
      "amount_paid": 99900,
      "amount_due": 0,
      "currency": "INR",
      "currency_symbol": "₹",
      "description": null,
      "notes": [],
      "comment": null,
      "short_url": "https://rzp.io/i/Ys4feGqEp",
      "view_less": true,
      "billing_start": 1594405800,
      "billing_end": 1597084200,
      "type": "invoice",
      "group_taxes_discounts": false,
      "created_at": 1593344888,
      "idempotency_key": null
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Delete offer linked to a subscription

```C#
string subscriptionId = "sub_I3GGEs7Xgmnozy";

string offerId = "offer_JCTD1XMlUmzF6Z";

Subscription subscription = client.Subscription.Fetch(subscriptionId).DeleteOffer(offerId);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| subscriptionId (mandatory)  | string | The id of the subscription to offer need to be deleted  |
| offerId*  | string | The id of the offer linked to subscription  |

**Response:**
```json
{
    "id": "sub_Z6t7VFTb9xHeOs",
    "entity": "subscription",
    "plan_id": "plan_Z6t7VFTb9xHeOs",
    "customer_id": "cust_Z6t7VFTb9xHeOs",
    "status": "active",
    "current_start": 1632914901,
    "current_end": 1635445800,
    "ended_at": null,
    "quantity": 1,
    "notes": [],
    "charge_at": 1635445800,
    "start_at": 1632914901,
    "end_at": 1645986600,
    "auth_attempts": 0,
    "total_count": 6,
    "paid_count": 1,
    "customer_notify": true,
    "created_at": 1632914246,
    "expire_by": 1635532200,
    "short_url": "https://rzp.io/i/SOvRWaYP81",
    "has_scheduled_changes": false,
    "change_scheduled_at": null,
    "source": "dashboard",
    "payment_method": "card",
    "offer_id": null,
    "remaining_count": 5
}
```
-------------------------------------------------------------------------------------------------------

### Authentication Transaction

Please refer this [doc](https://razorpay.com/docs/api/subscriptions/#authentication-transaction) for authentication of transaction


**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/subscriptions/#subscriptions)**