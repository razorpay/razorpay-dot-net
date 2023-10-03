## items

### Create item

```C#
Dictionary<string, object> itemRequest = new Dictionary<string, object>();
itemRequest.Add("name", "Book / English August");
itemRequest.Add("description", "An indian story, Booker prize winner.");
itemRequest.Add("amount", 20000);
itemRequest.Add("currency", "INR");

Item item = client.Item.Create(itemRequest);
```

**Parameters:**

| Name        | Type    | Description                                                                  |
|-------------|---------|------------------------------------------------------------------------------|
| name*       | string | Name of the item.                    |
| description | string  | A brief description of the item.  |
| amount*     | integer  | Amount of the order to be paid     |
| currency*   | string  | Currency of the order. Currently only `INR` is supported.    |

**Response:**
```json
{
    "id": "item_JnjKnSWxjILdWu",
    "active": true,
    "name": "Book / English August",
    "description": "An indian story, Booker prize winner.",
    "amount": 20000,
    "unit_amount": 20000,
    "currency": "INR",
    "type": "invoice",
    "unit": null,
    "tax_inclusive": false,
    "hsn_code": null,
    "sac_code": null,
    "tax_rate": null,
    "tax_id": null,
    "tax_group_id": null,
    "created_at": 1656597363
}
```

-------------------------------------------------------------------------------------------------------

### Fetch all items

```C#
Dictionary<string, object> itemRequest = new Dictionary<string, object>();
itemRequest.Add("count","1");

List<Item> item = client.Item.All();
```
**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| from  | timestamp | timestamp after which the item were created  |
| to    | timestamp | timestamp before which the item were created |
| count | integer   | number of item to fetch (default: 10)        |
| skip  | integer   | number of item to be skipped (default: 0)    |
| active   | boolean  | Possible values is `0` or `1` |

**Response:**
```json
{
    "entity": "collection",
    "count": 1, 
    "items": [
        {
            "id": "item_JnjKnSWxjILdWu",
            "active": true,
            "name": "Book / English August",
            "description": "An indian story, Booker prize winner.",
            "amount": 20000,
            "unit_amount": 20000,
            "currency": "INR",
            "type": "invoice",
            "unit": null,
            "tax_inclusive": false,
            "hsn_code": null,
            "sac_code": null,
            "tax_rate": null,
            "tax_id": null,
            "tax_group_id": null,
            "created_at": 1656597363
        }
    ]
}

```
-------------------------------------------------------------------------------------------------------
### Fetch particular item

```C#
string itemId = "item_7Oxp4hmm6T4SCn";

Item item = client.Item.Fetch(itemId);
```
**Parameters**

| Name    | Type   | Description                         |
|---------|--------|-------------------------------------|
| itemId* | string | The id of the item to be fetched |

**Response:**
```json
{
    "id": "item_JnjKnSWxjILdWu",
    "active": true,
    "name": "Book / English August",
    "description": "An indian story, Booker prize winner.",
    "amount": 20000,
    "unit_amount": 20000,
    "currency": "INR",
    "type": "invoice",
    "unit": null,
    "tax_inclusive": false,
    "hsn_code": null,
    "sac_code": null,
    "tax_rate": null,
    "tax_id": null,
    "tax_group_id": null,
    "created_at": 1656597363
}
```

-------------------------------------------------------------------------------------------------------

### Update item

```C#
string itemId = "item_7Oy8OMV6BdEAac";

Dictionary<string, object> itemRequest = new Dictionary<string, object>();
itemRequest.Add("name", "Book / Ignited Minds - Updated name!");
itemRequest.Add("description", "An indian story, Booker prize winner.");
itemRequest.Add("amount", 20000);
itemRequest.Add("currency", "INR");
itemRequest.Add("active", true);

Item payment = client.Item.Fetch(itemId).Edit(itemRequest);
```
**Parameters**

| Name        | Type   | Description                         |
|-------------|--------|-------------------------------------|
| ItemId*     | string | The id of the item to be fetched |
| name        | string | Name of the item.                    |
| description | string  | A brief description of the item.  |
| amount      | integer  | Amount of the order to be paid     |
| currency    | string  | Currency of the order. Currently only `INR` is supported.    |
| active      | boolean  | Possible values is `0` or `1` |

**Response:**

```json
{
    "id": "item_JnjKnSWxjILdWu",
    "active": true,
    "name": "Book / Ignited Minds - Updated name!",
    "description": "New descirption too.",
    "amount": 20000,
    "unit_amount": 20000,
    "currency": "INR",
    "type": "invoice",
    "unit": null,
    "tax_inclusive": false,
    "hsn_code": null,
    "sac_code": null,
    "tax_rate": null,
    "tax_id": null,
    "tax_group_id": null,
    "created_at": 1656597363
}
```
-------------------------------------------------------------------------------------------------------
### Delete item

```C#
string itemId = "item_7Oy8OMV6BdEAac";

List<Item> payment = client.Item.Fetch(itemId).Delete();
```
**Parameters**

| Name     | Type   | Description                         |
|----------|--------|-------------------------------------|
| itemId* | string | The id of the item to be fetched |

**Response:**

```json
[]
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/items)**