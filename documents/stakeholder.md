## Stakeholders

### Create an Stakeholder
```C#
string accountId = "acc_ua2tBezhcEBvap";

Dictionary<string, object> StakeRequest = new Dictionary<string, object>();
StakeRequest.Add("email", "gauriagain.kumar@example.org");
StakeRequest.Add("percentage_ownership", 10);
StakeRequest.Add("name", "Gaurav Kumar");

Dictionary<string, object> relationship = new Dictionary<string, object>();
relationship.Add("director", true);
relationship.Add("executive", false);

StakeRequest.Add("relationship", relationship);

Dictionary<string, object> phone = new Dictionary<string, object>();
phone.Add("primary", "9999999999");
phone.Add("secondary", "9999999999");

StakeRequest.Add("phone", phone);

Dictionary<string, object> residential = new Dictionary<string, object>();
residential.Add("street", "507, Koramangala 6th block");
residential.Add("city", "Bengaluru");
residential.Add("state", "Karnataka");
residential.Add("postal_code", "560047");
residential.Add("country", "IN");

Dictionary<string, object> addresses = new Dictionary<string, object>();
addresses.Add("residential", residential);
StakeRequest.Add("addresses", addresses);


Dictionary<string, object> kyc = new Dictionary<string, object>();
kyc.Add("pan", "AVOPB1111K");

StakeRequest.Add("kyc", kyc);

Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("random_key_by_partner", "random_value");

StakeRequest.Add("notes", notes);

Stakeholder stakeholder = client.Stakeholder.Create(accountId, StakeRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| email (mandatory) | string      | The sub-merchant's business email address.  |
| name (mandatory)          | string      |  The stakeholder's name as per the PAN card. The maximum length is 255 characters.   |
| percentage_ownership | float | The stakeholder's ownership of the business in percentage. Only two decimal places are allowed. For example, `87.55`. The maximum length is 100 characters. |
| relationship         | boolean      | The stakeholder's relationship with the account’s business. |
| phone         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/stakeholder/#create-a-stakeholder) are supported |         
| addresses         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/stakeholder/#create-a-stakeholder) are supported |    
| kyc         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/stakeholder/#create-a-stakeholder) are supported |      
| notes | object  | A key-value pair  |   

**Response:**
```json
{
  "entity": "stakeholder",
  "relationship": {
    "director": true
  },
  "phone": {
    "primary": "7474747474",
    "secondary": "7474747474"
  },
  "notes": {
    "random_key_by_partner": "random_value"
  },
  "kyc": {
    "pan": "AVOPB1111K"
  },
  "id": "sth_GLGgm8fFCKc92m",
  "name": "Gaurav Kumar",
  "email": "gaurav.kumar@example.com",
  "percentage_ownership": 10,
  "addresses": {
    "residential": {
      "street": "506, Koramangala 1st block",
      "city": "Bengaluru",
      "state": "Karnataka",
      "postal_code": "560034",
      "country": "IN"
    }
  }
}
```

-------------------------------------------------------------------------------------------------------

### Edit Account
```C#
Dictionary<string, object> StakeRequest = new Dictionary<string, object>();
StakeRequest.Add("percentage_ownership", 10);
StakeRequest.Add("name", "Gaurav Kumar");

Dictionary<string, object> relationship = new Dictionary<string, object>();
relationship.Add("director", true);
relationship.Add("executive", false);

StakeRequest.Add("relationship", relationship);

Dictionary<string, object> phone = new Dictionary<string, object>();
phone.Add("primary", "9999999999");
phone.Add("secondary", "9999999999");

StakeRequest.Add("phone", phone);

Dictionary<string, object> residential = new Dictionary<string, object>();
residential.Add("street", "507, Koramangala 6th block");
residential.Add("city", "Bengaluru");
residential.Add("state", "Karnataka");
residential.Add("postal_code", "560047");
residential.Add("country", "IN");

Dictionary<string, object> addresses = new Dictionary<string, object>();
addresses.Add("residential", residential);
StakeRequest.Add("addresses", addresses);


Dictionary<string, object> kyc = new Dictionary<string, object>();
kyc.Add("pan", "AVOPB1111K");

StakeRequest.Add("kyc", kyc);

Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("random_key_by_partner", "random_value");

StakeRequest.Add("notes", notes);

string accountId = "acc_ua2tBezhcEBvap";
string stakeholderId = "sth_ua2tBezhcEBvap";

Stakeholder stakeholder = client.Stakeholder.Fetch(accountId, stakeholderId).Edit(accountId, StakeRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| accountId (mandatory) | string   | The unique identifier of a sub-merchant account generated by Razorpay.  |
| stakeholderId (mandatory) | string      | The unique identifier of the stakeholder whose details are to be fetched. |
| name          | string      |  The stakeholder's name as per the PAN card. The maximum length is 255 characters.   |
| percentage_ownership | float | The stakeholder's ownership of the business in percentage. Only two decimal places are allowed. For example, `87.55`. The maximum length is 100 characters. |
| relationship         | boolean      | The stakeholder's relationship with the account’s business. |
| phone         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/stakeholder/#update-a-stakeholder) are supported |         
| addresses         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/stakeholder/#update-a-stakeholder) are supported |    
| kyc         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/stakeholder/#update-a-stakeholder) are supported |      
| notes | object  | A key-value pair  |   

**Response:**
```json
{
  "id": "acc_ua2tBezhcEBvap",
  "type": "standard",
  "status": "created",
  "email": "gauri@example.org",
  "profile": {
    "category": "healthcare",
    "subcategory": "clinic",
    "addresses": {
      "registered": {
        "street1": "507, Koramangala 1st block",
        "street2": "MG Road-1",
        "city": "Bengalore",
        "state": "KARNATAKA",
        "postal_code": "560034",
        "country": "IN"
      }
    }
  },
  "notes": [],
  "created_at": 1610603081,
  "phone": "9000090000",
  "reference_id": "randomId",
  "business_type": "partnership",
  "legal_business_name": "Acme Corp",
  "customer_facing_business_name": "ABCD Ltd"
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all accounts
```C#
string accountId = "acc_ua2tBezhcEBvap";

List<Stakeholder> stakeholder = client.Stakeholder.All(accountId);

```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| accountId (mandatory) | string   | The unique identifier of a sub-merchant account generated by Razorpay.  |

**Response:**
```json
{
  "entity": "collection",
  "items": [
    {
      "id": "GZ13yPHLJof9IE",
      "entity": "stakeholder",
      "relationship": {
        "director": true
      },
      "phone": {
        "primary": "9000090000",
        "secondary": "9000090000"
      },
      "notes": {
        "random_key_by_partner": "random_value"
      },
      "kyc": {
        "pan": "AVOPB1111K"
      },
      "name": "Gaurav Kumar",
      "email": "gaurav.kumar@acme.org",
      "percentage_ownership": 10,
      "addresses": {
        "residential": {
          "street": "506, Koramangala 1st block",
          "city": "Bengaluru",
          "state": "Karnataka",
          "postal_code": "560034",
          "country": "in"
        }
      }
    }
  ],
  "count": 1
}
```

-------------------------------------------------------------------------------------------------------

### Fetch an stakeholder
```C#
string accountId = "acc_ua2tBezhcEBvap";

string stakeholderId = "sth_ua2tBezhcEBvap";

Stakeholder stakeholder = client.Stakeholder.Fetch(accountId, stakeholderId);
```

**Parameters:**

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| accountId (mandatory) | string      | The unique identifier of a sub-merchant account generated by Razorpay.  |
| stakeholderId (mandatory) | string      | The unique identifier of the stakeholder whose details are to be fetched. |

**Response:**
```json
{
  "entity": "stakeholder",
  "relationship": {
    "director": true
  },
  "phone": {
    "primary": "9000090000",
    "secondary": "9000090000"
  },
  "notes": {
    "random_key_by_partner": "random_value2"
  },
  "kyc": {
    "pan": "AVOPB1111J"
  },
  "id": "sth_ua2tBezhcEBvap",
  "name": "Gauri Kumar",
  "email": "gauri@example.com",
  "percentage_ownership": 20,
  "addresses": {
    "residential": {
      "street": "507, Koramangala 1st block",
      "city": "Bangalore",
      "state": "Karnataka",
      "postal_code": "560035",
      "country": "in"
    }
  }
}
```

-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/partners/stakeholder)**