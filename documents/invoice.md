## Invoices

### Create Invoice

Request #1
In this example, an invoice is created using the customer and item details. Here, the customer and item are created while creating the invoice.
```C#
Dictionary<string, object> invoiceRequest = new Dictionary<string, object>();
invoiceRequest.Add("type", "invoice");
invoiceRequest.Add("description", "Invoice for the month of January 2020");
invoiceRequest.Add("partial_payment", true);
Dictionary<string, object> customer = new Dictionary<string, object>();
customer.Add("name", "Gaurav Kumar");
customer.Add("contact", "9999999999");
customer.Add("email", "gaurav.kumar@example.com");
Dictionary<string, object> billingAddress = new Dictionary<string, object>();
billingAddress.Add("line1", "Ground & 1st Floor, SJR Cyber Laskar");
billingAddress.Add("line2", "Hosur Road");
billingAddress.Add("zipcode", "560068");
billingAddress.Add("city", "Bengaluru");
billingAddress.Add("state", "Karnataka");
billingAddress.Add("country", "in");
customer.Add("billing_address", billingAddress);
Dictionary<string, object> shippingAddress = new Dictionary<string, object>();
shippingAddress.Add("line1", "Ground & 1st Floor, SJR Cyber Laskar");
shippingAddress.Add("line2", "Hosur Road");
shippingAddress.Add("zipcode", "560068");
shippingAddress.Add("city", "Bengaluru");
shippingAddress.Add("state", "Karnataka");
shippingAddress.Add("country", "in");
customer.Add("shipping_address", shippingAddress);
invoiceRequest.Add("customer", customer);
List<Dictionary<string, object>> lines = new List<Dictionary<string, object>>();
Dictionary<string, object> lineItems = new Dictionary<string, object>();
lineItems.Add("name", "Master Cloud ComAdding in 30 Days");
lineItems.Add("description", "Book by Ravena Ravenclaw");
lineItems.Add("amount", 399);
lineItems.Add("currency", "INR");
lineItems.Add("quantity", 1);
lines.Add(lineItems);
invoiceRequest.Add("line_items", lines);
invoiceRequest.Add("email_notify", 1);
invoiceRequest.Add("sms_notify", 1);
invoiceRequest.Add("currency", "INR");
invoiceRequest.Add("expire_by", 1580479824);

Invoice invoice = client.Invoice.Create(invoiceRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|type (mandatory)          | string | entity type (here its invoice)                                               |
|description        | string  | A brief description of the invoice.                      |
|customer_id           | string  | customer id for which invoice need be raised   |
|draft           | string  |  Invoice is created in draft state when value is set to `1`   |
| customer*     | object | All parameters listed [here](https://razorpay.com/docs/api/payments/invoices/#create-an-invoice) are supported           |
| line_items    | array | All parameters listed [here](https://razorpay.com/docs/api/payments/invoices/#create-an-invoice) are supported |
|expire_by           | integer  | Details of the line item that is billed in the invoice.  |
|sms_notify           | boolean  | Details of the line item that is billed in the invoice.  |
|email_notify           | boolean  | Details of the line item that is billed in the invoice.  |
|partial_payment | boolean  | Indicates whether customers can make partial payments on the invoice . Possible values: true - Customer can make partial payments. false (default) - Customer cannot make partial payments. |
| currency*   | string  | The currency of the payment (defaults to INR)  |


Request #2
In this example, an invoice is created using existing `customer_id` and `item_id`
```C#
Dictionary<string, object> invoiceRequest = new Dictionary<string, object>();
invoiceRequest.Add("type", "invoice");
invoiceRequest.Add("date", "1589994898");
invoiceRequest.Add("customer_id","cust_Z6t7VFTb9xHeOs");
List<Dictionary<string, object>> lines = new List<Dictionary<string, object>>();
Dictionary<string, object> lineItems = new Dictionary<string, object>();
lineItems.Add("item_id","item_Z6t7VFTb9xHeOs");
lines.Add(lineItems);
invoiceRequest.Add("line_items",lines);

Invoice invoice = client.Invoice.Create(invoiceRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|type (mandatory)          | string | entity type (here its invoice)                                               |
|description        | string  | A brief description of the invoice.                      |
|customer_id           | string  | customer id for which invoice need be raised                     |
| customer (mandatory)     | array | All parameters listed [here](https://razorpay.com/docs/api/payments/invoices/#create-an-invoice) are supported           |
| line_items    | array | All parameters listed [here](https://razorpay.com/docs/api/payments/invoices/#create-an-invoice) are supported |
| sms_notify  | boolean  | SMS notifications are to be sent by Razorpay (default : 1)  |
| currency (mandatory)  (conditionally mandatory) | string  | The 3-letter ISO currency code for the payment. Currently, only `INR` is supported. |
| email_notify | boolean  | Email notifications are to be sent by Razorpay (default : 1)  |
| expire_by    | integer | The timestamp, in Unix format, till when the customer can make the authorization payment. |

**Response:**

For create invoice response please click [here](https://razorpay.com/docs/api/invoices/#create-an-invoice)

-------------------------------------------------------------------------------------------------------

### Fetch all invoices

```C#
List<Invoice> invoice = client.Invoice.All();
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
|type          | string | entity type (here its invoice)                                               |
|payment_id        | string  | The unique identifier of the payment made by the customer against the invoice.                      |
|customer_id           | string  | The unique identifier of the customer.                     |
|receipt           | string  |  The unique receipt number that you entered for internal purposes.                     |

**Response:**

For fetch all invoice response please click [here](https://razorpay.com/docs/api/invoices/#fetch-multiple-invoices)

-------------------------------------------------------------------------------------------------------

### Fetch invoice

```C#
string invoiceId = "inv_Z6t7VFTb9xHeOs";

Invoice invoice = client.Invoice.Fetch(invoiceId);
```

**Parameters:**

| Name       | Type    | Description                                                                  |
|------------|---------|------------------------------------------------------------------------------|
| invoiceId (mandatory) | string | The id of the invoice to be fetched                         |

**Response:**
```json
{
  "id": "inv_Z6t7VFTb9xHeOs",
  "entity": "invoice",
  "receipt": null,
  "invoice_number": null,
  "customer_id": "cust_Z6t7VFTb9xHeOs",
  "customer_details": {
    "id": "cust_Z6t7VFTb9xHeOs",
    "name": "Gaurav Kumar",
    "email": "gaurav.kumar@example.com",
    "contact": "9999999999",
    "gstin": null,
    "billing_address": {
      "id": "addr_Z6t7VFTb9xHeOs",
      "type": "billing_address",
      "primary": true,
      "line1": "Ground & 1st Floor, SJR Cyber Laskar",
      "line2": "Hosur Road",
      "zipcode": "560068",
      "city": "Bengaluru",
      "state": "Karnataka",
      "country": "in"
    },
    "shipping_address": {
      "id": "addr_Z6t7VFTb9xHeOs",
      "type": "shipping_address",
      "primary": true,
      "line1": "Ground & 1st Floor, SJR Cyber Laskar",
      "line2": "Hosur Road",
      "zipcode": "560068",
      "city": "Bengaluru",
      "state": "Karnataka",
      "country": "in"
    },
    "customer_name": "Gaurav Kumar",
    "customer_email": "gaurav.kumar@example.com",
    "customer_contact": "9999999999"
  },
  "order_id": "order_Z6t7VFTb9xHeOs",
  "line_items": [
    {
      "id": "li_Z6t7VFTb9xHeOs",
      "item_id": null,
      "ref_id": null,
      "ref_type": null,
      "name": "Master Cloud Computing in 30 Days",
      "description": "Book by Ravena Ravenclaw",
      "amount": 399,
      "unit_amount": 399,
      "gross_amount": 399,
      "tax_amount": 0,
      "taxable_amount": 399,
      "net_amount": 399,
      "currency": "INR",
      "type": "invoice",
      "tax_inclusive": false,
      "hsn_code": null,
      "sac_code": null,
      "tax_rate": null,
      "unit": null,
      "quantity": 1,
      "taxes": []
    }
  ],
  "payment_id": null,
  "status": "issued",
  "expire_by": 1589765167,
  "issued_at": 1579765167,
  "paid_at": null,
  "cancelled_at": null,
  "expired_at": null,
  "sms_status": "pending",
  "email_status": "pending",
  "date": 1579765167,
  "terms": null,
  "partial_payment": true,
  "gross_amount": 399,
  "tax_amount": 0,
  "taxable_amount": 399,
  "amount": 399,
  "amount_paid": 0,
  "amount_due": 399,
  "currency": "INR",
  "currency_symbol": "₹",
  "description": "Invoice for the month of January 2020",
  "notes": [],
  "comment": null,
  "short_url": "https://rzp.io/i/2wxV8Xs",
  "view_less": true,
  "billing_start": null,
  "billing_end": null,
  "type": "invoice",
  "group_taxes_discounts": false,
  "created_at": 1579765167
}
```
-------------------------------------------------------------------------------------------------------

### Update invoice

```C#
string invoiceId = "inv_Z6t7VFTb9xHeOs";

Dictionary<string, object> invoiceRequest = new Dictionary<string, object>();
List<Dictionary<string, object>> lines = new List<Dictionary<string, object>>();
Dictionary<string, object> lineItems = new Dictionary<string, object>();
lineItems.Add("id", "li_Z6t7VFTb9xHeOs");
lineItems.Add("name", "Book / English August - Updated name and quantity");
lineItems.Add("quantity", 1);
Dictionary<string, object> lineItems1 = new Dictionary<string, object>();
lineItems1.Add("name", "Book / A Wild Sheep Chase");
lineItems1.Add("amount", "200");
lineItems1.Add("currency", "INR");
lineItems1.Add("quantity", 1);
lines.Add(lineItems);
lines.Add(lineItems1);
invoiceRequest.Add("line_items", lines);
Dictionary<string, object> notes = new Dictionary<string, object>();
notes.Add("updated-key", "An updated note.");
invoiceRequest.Add("notes", notes);

Invoice invoice = client.Invoice.Fetch(invoiceId).Edit(invoiceRequest);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| invoiceId (mandatory)          | string | The id of the invoice to be fetched                         |

**Response:**
For update invoice response please click [here](https://razorpay.com/docs/api/invoices/#update-an-invoice)

-------------------------------------------------------------------------------------------------------

### Issue an invoice

```C#
string invoiceId = "inv_DAweOiQ7amIUVd";

Invoice invoice = client.Invoice.Fetch(invoiceId).Issue();
```

**Parameters:**

| Name       | Type    | Description                                                                  |
|------------|---------|------------------------------------------------------------------------------|
| invoiceId (mandatory) | string | The id of the invoice to be issued                         |

**Response:**
```json
{
  "id": "inv_DAweOiQ7amIUVd",
  "entity": "invoice",
  "receipt": "#0961",
  "invoice_number": "#0961",
  "customer_id": "cust_DAtUWmvpktokrT",
  "customer_details": {
    "id": "cust_DAtUWmvpktokrT",
    "name": "Gaurav Kumar",
    "email": "gaurav.kumar@example.com",
    "contact": "9977886633",
    "gstin": null,
    "billing_address": {
      "id": "addr_DAtUWoxgu91obl",
      "type": "billing_address",
      "primary": true,
      "line1": "318 C-Wing, Suyog Co. Housing Society Ltd.",
      "line2": "T.P.S Road, Vazira, Borivali",
      "zipcode": "400092",
      "city": "Mumbai",
      "state": "Maharashtra",
      "country": "in"
    },
    "shipping_address": null,
    "customer_name": "Gaurav Kumar",
    "customer_email": "gaurav.kumar@example.com",
    "customer_contact": "9977886633"
  },
  "order_id": "order_DBG3P8ZgDd1dsG",
  "line_items": [
    {
      "id": "li_DAweOizsysoJU6",
      "item_id": null,
      "name": "Book / English August - Updated name and quantity",
      "description": "150 points in Quidditch",
      "amount": 400,
      "unit_amount": 400,
      "gross_amount": 400,
      "tax_amount": 0,
      "taxable_amount": 400,
      "net_amount": 400,
      "currency": "INR",
      "type": "invoice",
      "tax_inclusive": false,
      "hsn_code": null,
      "sac_code": null,
      "tax_rate": null,
      "unit": null,
      "quantity": 1,
      "taxes": []
    },
    {
      "id": "li_DAwjWQUo07lnjF",
      "item_id": null,
      "name": "Book / A Wild Sheep Chase",
      "description": null,
      "amount": 200,
      "unit_amount": 200,
      "gross_amount": 200,
      "tax_amount": 0,
      "taxable_amount": 200,
      "net_amount": 200,
      "currency": "INR",
      "type": "invoice",
      "tax_inclusive": false,
      "hsn_code": null,
      "sac_code": null,
      "tax_rate": null,
      "unit": null,
      "quantity": 1,
      "taxes": []
    }
  ],
  "payment_id": null,
  "status": "issued",
  "expire_by": 1567103399,
  "issued_at": 1566974805,
  "paid_at": null,
  "cancelled_at": null,
  "expired_at": null,
  "sms_status": null,
  "email_status": null,
  "date": 1566891149,
  "terms": null,
  "partial_payment": false,
  "gross_amount": 600,
  "tax_amount": 0,
  "taxable_amount": 600,
  "amount": 600,
  "amount_paid": 0,
  "amount_due": 600,
  "currency": "INR",
  "currency_symbol": "₹",
  "description": "This is a test invoice.",
  "notes": {
    "updated-key": "An updated note."
  },
  "comment": null,
  "short_url": "https://rzp.io/i/K8Zg72C",
  "view_less": true,
  "billing_start": null,
  "billing_end": null,
  "type": "invoice",
  "group_taxes_discounts": false,
  "created_at": 1566906474,
  "idempotency_key": null
}
```
-------------------------------------------------------------------------------------------------------

### Delete an invoice

```C#
string invoiceId = "inv_DAweOiQ7amIUVd";

List<Invoice> invoice = client.Invoice.Fetch(invoiceId).Delete();
```

**Parameters:**

| Name       | Type    | Description                                                                  |
|------------|---------|------------------------------------------------------------------------------|
| invoiceId (mandatory) | string | The id of the invoice to be deleted                         |

**Response:**
```
[]
```
-------------------------------------------------------------------------------------------------------

### Cancel an invoice

```C#
string invoiceId = "inv_DAweOiQ7amIUVd";

Invoice invoice = client.Invoice.Fetch(invoiceId).Cancel();
```

**Parameters:**

| Name       | Type    | Description                                                                  |
|------------|---------|------------------------------------------------------------------------------|
| invoiceId (mandatory) | string | The id of the invoice to be cancelled                         |

**Response:**
```json
{
  "id": "inv_E7q0tqkxBRzdau",
  "entity": "invoice",
  "receipt": null,
  "invoice_number": null,
  "customer_id": "cust_E7q0trFqXgExmT",
  "customer_details": {
    "id": "cust_E7q0trFqXgExmT",
    "name": "Gaurav Kumar",
    "email": "gaurav.kumar@example.com",
    "contact": "9972132594",
    "gstin": null,
    "billing_address": {
      "id": "addr_E7q0ttqh4SGhAC",
      "type": "billing_address",
      "primary": true,
      "line1": "Ground & 1st Floor, SJR Cyber Laskar",
      "line2": "Hosur Road",
      "zipcode": "560068",
      "city": "Bengaluru",
      "state": "Karnataka",
      "country": "in"
    },
    "shipping_address": {
      "id": "addr_E7q0ttKwVA1h2V",
      "type": "shipping_address",
      "primary": true,
      "line1": "Ground & 1st Floor, SJR Cyber Laskar",
      "line2": "Hosur Road",
      "zipcode": "560068",
      "city": "Bengaluru",
      "state": "Karnataka",
      "country": "in"
    },
    "customer_name": "Gaurav Kumar",
    "customer_email": "gaurav.kumar@example.com",
    "customer_contact": "9972132594"
  },
  "order_id": "order_E7q0tvRpC0WJwg",
  "line_items": [
    {
      "id": "li_E7q0tuPNg84VbZ",
      "item_id": null,
      "ref_id": null,
      "ref_type": null,
      "name": "Master Cloud Computing in 30 Days",
      "description": "Book by Ravena Ravenclaw",
      "amount": 399,
      "unit_amount": 399,
      "gross_amount": 399,
      "tax_amount": 0,
      "taxable_amount": 399,
      "net_amount": 399,
      "currency": "INR",
      "type": "invoice",
      "tax_inclusive": false,
      "hsn_code": null,
      "sac_code": null,
      "tax_rate": null,
      "unit": null,
      "quantity": 1,
      "taxes": []
    }
  ],
  "payment_id": null,
  "status": "cancelled",
  "expire_by": null,
  "issued_at": 1579765167,
  "paid_at": null,
  "cancelled_at": 1579768206,
  "expired_at": null,
  "sms_status": "sent",
  "email_status": "sent",
  "date": 1579765167,
  "terms": null,
  "partial_payment": false,
  "gross_amount": 399,
  "tax_amount": 0,
  "taxable_amount": 399,
  "amount": 399,
  "amount_paid": 0,
  "amount_due": 399,
  "currency": "INR",
  "currency_symbol": "₹",
  "description": null,
  "notes": [],
  "comment": null,
  "short_url": "https://rzp.io/i/2wxV8Xs",
  "view_less": true,
  "billing_start": null,
  "billing_end": null,
  "type": "invoice",
  "group_taxes_discounts": false,
  "created_at": 1579765167,
  "idempotency_key": null
}
```
-------------------------------------------------------------------------------------------------------

### Send notification

```C#
string invoiceId = "inv_DAweOiQ7amIUVd";

string medium = "sms";

Invoice invoice = client.Invoice.Fetch(invoiceId).NotifyBy(medium);
```

**Parameters:**

| Name            | Type    | Description                                                                  |
|-----------------|---------|------------------------------------------------------------------------------|
| invoiceId (mandatory)          | string | The id of the invoice to be notified                         |
| medium (mandatory)          | string | `sms`/`email`, Medium through which notification should be sent.                         |

**Response:**
```json
{
    "success": true
}
```
-------------------------------------------------------------------------------------------------------

**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/invoices)**