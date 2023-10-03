## Account

### Create an Account
```C#
Dictionary<string, object> accountRequest = new Dictionary<string, object>();
accountRequest.Add("email", "gauriagain_n21.kumar@example.org");
accountRequest.Add("phone", "9000090000");
accountRequest.Add("legal_business_name", "Acme Corp");
accountRequest.Add("business_type", "partnership");
accountRequest.Add("customer_facing_business_name", "Example");
Dictionary<string, object> profile = new Dictionary<string, object>();
profile.Add("category", "healthcare");
profile.Add("subcategory", "clinic");
profile.Add("description", "Healthcare E-commerce platform");

Dictionary<string, object> operation = new Dictionary<string, object>();
operation.Add("street1", "507, Koramangala 6th block");
operation.Add("street2", "507, Koramangala");
operation.Add("city", "Bengaluru");
operation.Add("state", "Karnataka");
operation.Add("postal_code", "560047");
operation.Add("country", "IN");

Dictionary<string, object> registered = new Dictionary<string, object>();
registered.Add("street1", "507, Koramangala 1th block");
registered.Add("street2", "MG Road");
registered.Add("city", "Bengaluru");
registered.Add("state", "Karnataka");
registered.Add("postal_code", "560034");
registered.Add("country", "IN");

Dictionary<string, object> addresses = new Dictionary<string, object>();
addresses.Add("operation", operation);
addresses.Add("registered", registered);

profile.Add("addresses", addresses);
profile.Add("business_model", "Online Clothing ( men, women, ethnic, modern ) fashion and lifestyle, accessories, t-shirt, shirt, track pant, shoes.");

Dictionary<string, object> legalInfo = new Dictionary<string, object>();
legalInfo.Add("pan", "AAACL1234C");
legalInfo.Add("gst", "18AABCU9603R1ZM");

accountRequest.Add("profile", profile);
accountRequest.Add("legal_info", legalInfo);

Dictionary<string, object> brand = new Dictionary<string, object>();
brand.Add("color", "FFFFFF");

accountRequest.Add("brand", brand);

Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("internal_ref_id", "123123");

accountRequest.Add("notes", notes);
accountRequest.Add("contact_name", "Gaurav Kumar");

Dictionary<string, object> contactInfo = new Dictionary<string, object>();
Dictionary<string, object> chargeback = new Dictionary<string, object>();
chargeback.Add("email", "cb@example.org");

Dictionary<string, object> refund = new Dictionary<string, object>();
refund.Add("email", "cb@example.org");

Dictionary<string, object> support = new Dictionary<string, object>();
support.Add("email", "support@example.org");
support.Add("phone", "9999999998");
support.Add("policy_url", "https://www.google.com");

contactInfo.Add("chargeback", chargeback);
contactInfo.Add("refund", refund);
contactInfo.Add("support", support);
accountRequest.Add("contact_info", contactInfo);

Dictionary<string, object> apps = new Dictionary<string, object>();
List<string> url = new List<string>();
url.Add("https://www.example.org");

apps.Add("websites", url);
Dictionary<string, object> android_details = new Dictionary<string, object>();
android_details.Add("url", "playstore.example.org");
android_details.Add("name", "Example");
List<Dictionary<string, object>> android = new List<Dictionary<string, object>>();
android.Add(android_details);
apps.Add("android", android);

Dictionary<string, object> ios_details = new Dictionary<string, object>();
ios_details.Add("url", "appstore.example.org");
ios_details.Add("name", "Example");
List<Dictionary<string, object>> ios = new List<Dictionary<string, object>>();
ios.Add(ios_details);
apps.Add("ios", ios);
accountRequest.Add("apps", apps);

Account payment = client.Account.Create(accountRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| email  (mandatory)        | string      | The sub-merchant's business email address.  |
| phone  (mandatory)          | integer      | The sub-merchant's business phone number. The minimum length is 8 characters and the maximum length is 15.                       |
| legal_business_name  (mandatory)      | string | The name of the sub-merchant's business. For example, Acme Corp. The minimum length is 4 characters and the maximum length is 200.          |
| customer_facing_business_name | string | The sub-merchant billing label as it appears on the Razorpay Dashboard. The minimum length is 1 character and the maximum length is 255. |
| business_type         | string      | The type of business operated by the sub-merchant.Possible value is `proprietorship`, `partnership`, `private_limited`, `public_limited`, `llp`, `ngo`, `trust`, `society`, `not_yet_registered`, `huf` |
| reference_id         | string      |  Partner's external account reference id. The minimum length is 1 character and the maximum length is 512. |
| profile         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#create-an-account) are supported |         
| legal_info         | object      | All keys listed [here](hhttps://razorpay.com/docs/api/partners/account-onboarding/#create-an-account) are supported |
| brand         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#create-an-account) are supported |
| notes | object  | A key-value pair  |
| contact_name (mandatory) | string  | The name of the contact. The minimum length is 4 and the maximum length is 255 characters. |
| contact_info | object  | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#create-an-account) are supported |     
| apps | object  | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#create-an-account) are supported |     


**Response:**
```json
{
  "id": "acc_ua2tBezhcEBvap",
  "type": "standard",
  "status": "created",
  "email": "gauriagain.kumar@example.org",
  "profile": {
    "category": "healthcare",
    "subcategory": "clinic",
    "addresses": {
      "registered": {
        "street1": "507, Koramangala 1st block",
        "street2": "MG Road",
        "city": "Bengaluru",
        "state": "KARNATAKA",
        "postal_code": 560034,
        "country": "IN"
      },
      "operation": {
        "street1": "507, Koramangala 6th block",
        "street2": "Kormanagalo",
        "city": "Bengaluru",
        "state": "KARNATAKA",
        "country": "IN",
        "postal_code": 560047
      }
    },
    "business_model": "Online Clothing ( men, women, ethnic, modern ) fashion and lifestyle, accessories, t-shirt, shirt, track pant, shoes."
  },
  "notes": {
    "internal_ref_id": "123123"
  },
  "created_at": 1611136837,
  "phone": "9000090000",
  "business_type": "partnership",
  "legal_business_name": "Acme Corp",
  "customer_facing_business_name": "Example",
  "legal_info": {
    "pan": "AAACL1234C",
    "gst": "18AABCU9603R1ZM"
  },
  "apps": {
    "websites": [
      "https://www.example.org"
    ],
    "android": [
      {
        "url": "playstore.example.org",
        "name": "Example"
      }
    ],
    "ios": [
      {
        "url": "appstore.example.org",
        "name": "Example"
      }
    ]
  },
  "brand": {
    "color": "#FFFFFF"
  },
  "contact_info": {
    "chargeback": {
      "email": "cb@example.org",
      "phone": null,
      "policy_url": null
    },
    "refund": {
      "email": "cb@example.org",
      "phone": null,
      "policy_url": null
    },
    "support": {
      "email": "support@example.org",
      "phone": "9999999998",
      "policy_url": "https://www.google.com"
    }
  }
}
```

-------------------------------------------------------------------------------------------------------

### Edit Account
```C#
string accountId = "acc_ua2tBezhcEBvap";

Dictionary<string, object> accountRequest = new Dictionary<string, object>();
accountRequest.Add("customer_facing_business_name", "Example");

Account account = client.Account.Fetch(accountId).Edit(accountRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| phone          | integer      | The sub-merchant's business phone number. The minimum length is 8 characters and the maximum length is 15.                       |
| legal_business_name      | string | The name of the sub-merchant's business. For example, Acme Corp. The minimum length is 4 characters and the maximum length is 200.          |
| customer_facing_business_name | string | The sub-merchant billing label as it appears on the Razorpay Dashboard. The minimum length is 1 character and the maximum length is 255. |
| profile         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#update-an-account) are supported |         
| legal_info         | object      | All keys listed [here](hhttps://razorpay.com/docs/api/partners/account-onboarding/#update-an-account) are supported |
| brand         | object      | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#update-an-account) are supported |
| notes | object  | A key-value pair  |
| contact_name (mandatory) | string  | The name of the contact. The minimum length is 4 and the maximum length is 255 characters. |
| contact_info | object  | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#update-an-account) are supported |     
| apps | object  | All keys listed [here](https://razorpay.com/docs/api/partners/account-onboarding/#update-an-account) are supported |     

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

### Delete an account
```C#
string accountId = "acc_ua2tBezhcEBvap";

Account account = client.Account.Fetch(accountId).Delete();

```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| accountId (mandatory) | string   | The unique identifier of a sub-merchant account that must be deleted.  |

**Response:**
```json
{
  "id": "acc_ua2tBezhcEBvap",
  "type": "standard",
  "status": "suspended",
  "email": "gaurav.kumar@acme.org",
  "profile": {
    "category": "healthcare",
    "subcategory": "clinic",
    "addresses": {
      "registered": {
        "street1": "507, Koramangala 1st block",
        "street2": "MG Road",
        "city": "Bengaluru",
        "state": "KARNATAKA",
        "postal_code": "560034",
        "country": "IN"
      },
      "operation": {
        "street1": "507, Koramangala 1st block",
        "street2": "MG Road",
        "city": "Bengaluru",
        "state": "KARNATAKA",
        "country": "IN",
        "postal_code": "560034"
      }
    },
    "business_model": "Online Clothing ( men, women, ethnic, modern ) fashion and lifestyle, accessories, t-shirt, shirt, track pant, shoes."
  },
  "notes": {
    "internal_ref_id": "123123"
  },
  "created_at": 1612425180,
  "suspended_at": 1612425235,
  "phone": "9000090000",
  "reference_id": "account_CodeRandom",
  "business_type": "partnership",
  "legal_business_name": "Acme Corp Pvt Ltd",
  "customer_facing_business_name": "Acme",
  "legal_info": {
    "pan": "AAACL1234C",
    "gst": "18AABCU9603R1ZM"
  },
  "apps": {
    "websites": [
      "https://www.acme.org"
    ],
    "android": [
      {
        "url": "playstore.acme.org",
        "name": "Acme"
      }
    ],
    "ios": [
      {
        "url": "appstore.acme.org",
        "name": "Acme"
      }
    ]
  },
  "brand": {
    "color": "#FFFFFF"
  },
  "contact_name": "Gaurav Kumar",
  "contact_info": {
    "chargeback": {
      "email": "cb@acme.org",
      "phone": "9000090000",
      "policy_url": "https://www.google.com"
    },
    "refund": {
      "email": "cb@acme.org",
      "phone": "9898989898",
      "policy_url": "https://www.google.com"
    },
    "support": {
      "email": "support@acme.org",
      "phone": "9898989898",
      "policy_url": "https://www.google.com"
    }
  }
}
```

-------------------------------------------------------------------------------------------------------

### Fetch an account
```C#
string accountId = "acc_ua2tBezhcEBvap";

Account account = client.Account.Fetch(accountId);
```

**Parameters:**

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| accountId (mandatory) | string      | The unique identifier of a sub-merchant account generated by Razorpay.  |

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
  "customer_facing_business_name": "Example Pvt. Ltd."
}
```

-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/partners/account-onboarding/)**