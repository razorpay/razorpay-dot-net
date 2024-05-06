## Customer

### Create customer
```C#

Dictionary<string, object> customerRequest = new Dictionary<string, object>();
customerRequest.Add("name", "Gaurav Kumar");
customerRequest.Add("contact", "9123456780");
customerRequest.Add("email", "gaurav.kumar@example.com");
customerRequest.Add("fail_existing", "0");
customerRequest.Add("gstin", "29XAbbA4369J1PA");
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("notes_key_1", "Tea, Earl Grey, Hot");
notes.Add("notes_key_2", "Tea, Earl Grey… decaf.");
customerRequest.Add("notes", notes);

Customer customer = client.Customer.Create(customerRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| name (mandatory)          | string      | Name of the customer                        |
| email        | string      | Email of the customer                       |
| contact      | string      | Contact number of the customer              |
| fail_existing | string | If a customer with the same details already exists, the request throws an exception by default. Possible value is `0` or `1`|
| gstin         | string      | Customer's GST number, if available. For example, 29XAbbA4369J1PA  |
| notes         | object      | A key-value pair                            |

**Response:**
```json
{
  "id" : "cust_1Aa00000000004",
  "entity": "customer",
  "name" : "Gaurav Kumar",
  "email" : "gaurav.kumar@example.com",
  "contact" : "9123456780",
  "gstin": "29XAbbA4369J1PA",
  "notes":{
    "notes_key_1":"Tea, Earl Grey, Hot",
    "notes_key_2":"Tea, Earl Grey… decaf."
  },
  "created_at ": 1234567890
}
```

-------------------------------------------------------------------------------------------------------

### Edit customer
```C#
string customerId = "cust_1Aa00000000003";

Dictionary<string, object> customerRequest = new Dictionary<string, object>();
customerRequest.Add("name", "Gaurav Kumar K");
customerRequest.Add("contact", "9999999999");
customerRequest.Add("email", "gaurav.kumar@example.com");

Customer card = client.Customer.Fetch(customerId).Edit(customerRequest);
```

**Parameters:**

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| CustomerId (mandatory) | string      | The id of the customer to be updated  |
| email       | string      | Email of the customer                       |
| name        | string      | Name of the customer                        |
| contact     | string      | Contact number of the customer              |

**Response:**
```json
{
  "id": "cust_1Aa00000000003",
  "entity": "customer",
  "name": "Gaurav Kumar",
  "email": "Gaurav.Kumar@example.com",
  "contact": "9000000000",
  "gstin": null,
  "notes": {
    "notes_key_1": "Tea, Earl Grey, Hot",
    "notes_key_2": "Tea, Earl Grey… decaf."
  },
  "created_at": 1582033731
}
```
-------------------------------------------------------------------------------------------------------

### Fetch all customer
```C#
Dictionary<string, object> paramRequest = new Dictionary<string, object>();
paramRequest.Add("count","1");

List<Customer> card = client.Customer.All(paramRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| count | integer   | number of payments to fetch (default: 10)        |
| skip  | integer   | number of payments to be skipped (default: 0)    |

**Response:**
```json
{
  "entity":"collection",
  "count":1,
  "items":[
    {
      "id":"cust_1Aa00000000001",
      "entity":"customer",
      "name":"Gaurav Kumar",
      "email":"gaurav.kumar@example.com",
      "contact":"9876543210",
      "gstin":"29XAbbA4369J1PA",
      "notes":{
        "note_key_1":"September",
        "note_key_2":"Make it so."
      },
      "created_at ":1234567890
    }
  ]
}
```

-------------------------------------------------------------------------------------------------------

### Fetch a customer
```C#
string customerId = "cust_1Aa00000000001";

Customer customer = client.Customer.Fetch("cust_M462yViJrhNrQc");
```

**Parameters:**

| Name        | Type        | Description                                 |
|-------------|-------------|---------------------------------------------|
| customerId (mandatory) | string      | The id of the customer to be fetched  |

**Response:**
```json
{
  "id" : "cust_1Aa00000000001",
  "entity": "customer",
  "name" : "Saurav Kumar",
  "email" : "Saurav.kumar@example.com",
  "contact" : "+919000000000",
  "gstin":"29XAbbA4369J1PA",
  "notes" : [],
  "created_at ": 1234567890
}
```

-------------------------------------------------------------------------------------------------------

### Add Bank Account of Customer

```C#
string customerId = "cust_N5mywh91sXB69O";

Dictionary<string, object> customerRequest = new Dictionary<string, object>();
customerRequest.Add("ifsc_code", "UTIB0000194");
customerRequest.Add("account_number", "9160100000000001");
customerRequest.Add("beneficiary_name", "Pratheek");
customerRequest.Add("beneficiary_address1", "address 1");
customerRequest.Add("beneficiary_address2", "address 2");
customerRequest.Add("beneficiary_address3", "address 3");
customerRequest.Add("beneficiary_address4", "address 4");
customerRequest.Add("beneficiary_email", "random@email.com");
customerRequest.Add("beneficiary_mobile", "9999999999");
customerRequest.Add("beneficiary_city", "Bangalore");
customerRequest.Add("beneficiary_state", "KA");
customerRequest.Add("beneficiary_country", "IN");

BankAccount refund = client.Customer.Fetch(customerId).AddBankAccount(customerRequest);
```

**Parameters:**

| Name                 | Type     | Description                                                   |
|----------------------|----------|---------------------------------------------------------------|
| customerId*          | string   | Unique identifier of the customer.                            |
| account_number       | string   | Customer's bank account number.                               |
| beneficiary_name     | string   | The name of the beneficiary associated with the bank account. |
| beneficiary_address1 | string   | The virtual payment address.                                  |
| beneficiary_email    | string   | Email address of the beneficiary.                             |
| beneficiary_mobile   | integer  | Mobile number of the beneficiary.                             |
| beneficiary_city     | string   | The name of the city of the beneficiary.                      |
| beneficiary_state    | string   | The state of the beneficiary.                                 |
| beneficiary_pin      | interger | The pin code of the beneficiary's address.                    |
| ifsc_code            | string   | The IFSC code of the bank branch associated with the account. |

**Response:**
```json
{
  "id" : "cust_1Aa00000000001",
  "entity": "customer",
  "name" : "Saurav Kumar",
  "email" : "Saurav.kumar@example.com",
  "contact" : "+919000000000",
  "gstin":"29XAbbA4369J1PA",
  "notes" : [],
  "created_at ": 1234567890
}
```

-------------------------------------------------------------------------------------------------------

### Delete Bank Account of Customer

```C#
string customerId = "cust_N5mywh91sXB69O"

String bankAccountId = "ba_N6aM8uo64IzxHu"

Customer refund = client.Customer.Fetch(customerId).DeleteBankAccount(bankAccountId);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| customerId*   | string      | Unique identifier of the customer.          |
| bankAccountId | string      | The bank_id that needs to be deleted.       |

**Response:**
```json
{
    "id": "ba_Evg09Ll05SIPSD",
    "ifsc": "ICIC0001207",
    "bank_name": "ICICI Bank",
    "name": "Test R4zorpay",
    "account_number": "XXXXXXXXXXXXXXX0434",
    "status": "deleted"
}
```

-------------------------------------------------------------------------------------------------------

### Eligibility Check API

```C#
Dictionary<string, object> customerRequest = new Dictionary<string, object>();
customerRequest.Add("inquiry","affordability");
customerRequest.Add("amount", 500);
customerRequest.Add("currency","INR");
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("id","elig_xxxxxxxxxxxxx");
customer.Add("contact","+919999999999");
customer.Add("ip","105.106.107.108");
customer.Add("referrer","https://merchansite.com/example/paybill");
customer.Add("user_agent","Mozilla/5.0");
customerRequest.Add("customer",customer);

Customer refund = client.Customer.RequestEligibilityCheck(customerRequest);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| inquiry  | string      | List of methods or instruments on which eligibility check is required.  |
| amount*  | string      | The amount for which the order was created, in currency subunits.  |
| currency*  | string      | A three-letter ISO code for the currency in which you want to accept the payment.  |
| customer*  | object      | Customer details. [here](https://razorpay.com/docs/payments/payment-gateway/affordability/eligibility-check/#eligibility-check-api)  |
| instruments  | object | Payment instruments on which an eligibility check is required. [here](https://razorpay.com/docs/payments/payment-gateway/affordability/eligibility-check/#eligibility-check-api)  |


**Response:**
```json
{
  "amount": "500000",
  "customer": {
    "id": "KkBhM9EC1Y0HTm",
    "contact": "+919999999999"
  },
  "instruments": [
    {
      "method": "emi",
      "issuer": "HDFC",
      "type": "debit",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "eligible"
      }
    },
    {
      "method": "paylater",
      "provider": "getsimpl",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "eligible"
      }
    },
    {
      "method": "paylater",
      "provider": "icic",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "eligible"
      }
    },
    {
      "method": "cardless_emi",
      "provider": "walnut369",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "ineligible",
        "error": {
          "code": "GATEWAY_ERROR",
          "description": "The customer has not been approved by the partner.",
          "source": "business",
          "step": "inquiry",
          "reason": "user_not_approved"
        }
      }
    },
    {
      "method": "cardless_emi",
      "provider": "zestmoney",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "ineligible",
        "error": {
          "code": "GATEWAY_ERROR",
          "description": "The customer has exhausted their credit limit.",
          "source": "business",
          "step": "inquiry",
          "reason": "credit_limit_exhausted"
        }
      }
    },
    {
      "method": "paylater",
      "provider": "lazypay",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "ineligible",
        "error": {
          "code": "GATEWAY_ERROR",
          "description": "The order amount is less than the minimum transaction amount.",
          "source": "business",
          "step": "inquiry",
          "reason": "min_amt_required"
        }
      }
    }
  ]
}
```

-------------------------------------------------------------------------------------------------------

### Fetch Eligibility by id

```c#
String eligibilityId = "elig_xxxxxxxxxxxxx"
Customer refund = client.Customer.FetchEligibility(eligibilityId);
```

**Parameters:**

| Name          | Type        | Description                                 |
|---------------|-------------|---------------------------------------------|
| eligibilityId  | string      | The unique identifier of the eligibility request to be retrieved.  |

**Response:**
```json
{
  "instruments": [
    {
      "method": "paylater",
      "provider": "lazypay",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "eligible"
      }
    },
    {
      "method": "paylater",
      "provider": "getsimpl",
      "eligibility_req_id": "elig_xxxxxxxxxxxxx",
      "eligibility": {
        "status": "ineligible",
        "error": {
          "code": "GATEWAY_ERROR",
          "description": "The customer has exhausted their credit limit",
          "source": "gateway",
          "step": "inquiry",
          "reason": "credit_limit_exhausted"
        }
      }
    }
  ]
}
```

-------------------------------------------------------------------------------------------------------
**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/customers/)**