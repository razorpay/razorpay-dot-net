## Device Activity

### Create device activity (Initiate Checkout)

```csharp
var activityData = new Dictionary<string, object>
{
    ["device_id"] = "2841158834",            // Required for DeviceMode.Wireless, optional for DeviceMode.Wired
    ["action"] = "initiate_checkout",        // Required: Action type
    ["notes"] = new Dictionary<string, object>  // Optional: Additional notes
    {
        ["key1"] = "value1",
        ["key2"] = "value2"
    },
    ["initiate_checkout"] = new Dictionary<string, object>  // Required for initiate_checkout
    {
        ["name"] = "Acme Corp",              // Required: Business name
        ["amount"] = 19900,                  // Required: Amount in paise (₹199.00)
        ["currency"] = "INR",                // Required: Currency code
        ["description"] = "POS Transaction", // Required: Transaction description
        ["type"] = "in_person",              // Optional: Transaction type
        ["order_id"] = "order_R7vqkfqG3Iw02m", // Required: Order reference
        ["prefill"] = new Dictionary<string, object>  // Optional: Customer prefill data
        {
            ["name"] = "Gaurav Kumar",
            ["email"] = "gaurav.kumar@example.com",
            ["contact"] = "9000090000",
            ["method"] = "upi"                // Optional: "upi"|"card"|"netbanking"|"wallet"
        }
    }
};

DeviceActivity response = client.DeviceActivity.Create(DeviceMode.Wired, activityData);
```

**Example without prefill (all fields optional):**

```csharp
var minimalActivityData = new Dictionary<string, object>
{
    ["device_id"] = "2841158834",
    ["action"] = "initiate_checkout",
    ["initiate_checkout"] = new Dictionary<string, object>
    {
        ["name"] = "Acme Corp",
        ["amount"] = 19900,
        ["currency"] = "INR", 
        ["description"] = "POS Transaction",
        ["type"] = "in_person",
        ["order_id"] = "order_R7vqkfqG3Iw02m"
        // prefill is optional and can be omitted entirely
    }
};

DeviceActivity response = client.DeviceActivity.Create(DeviceMode.Wired, minimalActivityData);
```

**Parameters:**

| Name          | Type   | Description                                                                    |
|---------------|--------|--------------------------------------------------------------------------------|
| device_id     | string | Device identifier. Required for wireless mode, optional for wired mode        |
| action*       | string | Action type. Possible values: `initiate_checkout`, `close_checkout`           |
| notes         | object | A key-value pair for additional information                                    |
| initiate_checkout* | object | Required when action is `initiate_checkout`. Contains checkout details       |
| DeviceMode*   | enum   | Device communication mode. Values: `DeviceMode.Wired`, `DeviceMode.Wireless` |

**initiate_checkout Object Parameters:**

| Name          | Type   | Description                                                                    |
|---------------|--------|--------------------------------------------------------------------------------|
| name*         | string | Business name                                                                  |
| amount*       | integer| Amount in paise (₹199.00 = 19900)                                            |
| currency*     | string | Currency code (e.g., "INR")                                                   |
| description*  | string | Transaction description                                                        |
| type*         | string | Transaction type (e.g., "in_person")                                          |
| order_id*     | string | Order reference ID                                                             |
| prefill       | object | Optional customer prefill data (name, email, contact, method)                 |

**prefill Object Parameters:**

| Name          | Type   | Description                                                                    |
|---------------|--------|--------------------------------------------------------------------------------|
| name          | string | Optional customer name                                                         |
| email         | string | Optional customer email address                                                |
| contact       | string | Optional customer contact number                                               |
| method        | string | Optional payment method: "upi", "card", "netbanking", "wallet"                |

**Success Response:**

```csharp
// Access response data
var activityId = response["id"];                    // "pda_NVTKa9PL0yessI"
var entity = response["entity"];                    // "device.activity"
var deviceId = response["device_id"];               // "2841158834"
var action = response["action"];                    // "initiate_checkout"
var status = response["status"];                    // "processing"
var error = response["error"];                      // null

// Access nested initiate_checkout data
var initiateCheckout = response["initiate_checkout"] as Dictionary<string, object>;
var name = initiateCheckout["name"];                // "Acme Corp"
var amount = initiateCheckout["amount"];            // 19900
```

**JSON Response Format:**
```json
{
  "id": "pda_NVTKa9PL0yessI",
  "entity": "device.activity",
  "device_id": "2841158834",
  "action": "initiate_checkout",
  "initiate_checkout": {
    "name": "Acme Corp",
    "amount": 19900,
    "currency": "INR",
    "description": "POS Transaction",
    "order_id": "order_R7vqkfqG3Iw02m",
    "prefill": {
      "name": "Gaurav Kumar",
      "email": "gaurav.kumar@example.com",
      "contact": "9000090000",
      "method": "upi"
    }
  },
  "status": "processing",
  "error": null
}
```

**Failure Response:**

```csharp
// On failure, check status and error
var status = response["status"];                    // "failed"
var error = response["error"] as Dictionary<string, object>;
var errorCode = error["code"];                      // "BAD_REQUEST_ERROR"
var errorReason = error["reason"];                  // "device_not_connected"
```

**Status Values:**
- `"processing"` - Checkout is being processed
- `"completed"` - Checkout completed successfully  
- `"failed"` - Checkout failed with error details

---

### Create device activity (Close Checkout)

```csharp
var closeData = new Dictionary<string, object>
{
    ["device_id"] = "2841158834",
    ["action"] = "close_checkout"
};

DeviceActivity response = client.DeviceActivity.Create(DeviceMode.Wireless, closeData);
```

**Parameters:**

| Name          | Type   | Description                                                                    |
|---------------|--------|--------------------------------------------------------------------------------|
| device_id     | string | Device identifier. Required for wireless mode, optional for wired mode        |
| action*       | string | Action type: `close_checkout`                                                  |
| DeviceMode*   | enum   | Device communication mode. Values: `DeviceMode.Wired`, `DeviceMode.Wireless` |

**Success Response:**

```csharp
var activityId = response["id"];                    // "pda_NVTKa9PL0yessJ"
var entity = response["entity"];                    // "device.activity" 
var deviceId = response["device_id"];               // "2841158834"
var action = response["action"];                    // "close_checkout"
var status = response["status"];                    // "completed"
var error = response["error"];                      // null
```

**JSON Response Format:**
```json
{
  "id": "pda_NVTKa9PL0yessJ",
  "entity": "device.activity", 
  "device_id": "2841158834",
  "action": "close_checkout",
  "status": "completed",
  "error": null
}
```

**Failure Response:**

```csharp
var status = response["status"];                    // "failed"
var error = response["error"] as Dictionary<string, object>;
var errorCode = error["code"];                      // "BAD_REQUEST_ERROR"
var errorReason = error["reason"];                  // "checkout_not_found"
```

---

## Authentication

Device Activity APIs use **public authentication** (access token). The SDK automatically handles this when using `client.DeviceActivity.*` methods.

**Authentication Type:** Public Authentication
- Uses access token from your Razorpay credentials
- More secure for device-specific operations
- Automatically handled by the SDK

---

## Device Modes

### Wired Mode
- **DeviceMode**: `DeviceMode.Wired`
- **device_id**: Optional
- Direct device connection

### Wireless Mode  
- **DeviceMode**: `DeviceMode.Wireless`
- **device_id**: Required
- Wireless device communication

---

## Error Handling

```csharp
using Razorpay.Api.Errors;

try
{
    var response = client.DeviceActivity.Create(DeviceMode.Wired, activityData);
}
catch (BadRequestError ex)
{
    Console.WriteLine($"Bad Request: {ex.Message}");
    Console.WriteLine($"Error Code: {ex.ErrorCode}");
    Console.WriteLine($"Field: {ex.Field}");
}
catch (GatewayError ex)
{
    Console.WriteLine($"Gateway Error: {ex.Message}");
    // Implement retry logic
}
catch (ServerError ex)
{
    Console.WriteLine($"Server Error: {ex.Message}");
    // Implement retry after delay
}
```

**Common Errors:**

| Error | Description | Solution |
|-------|-------------|----------|
| `BadRequestError` | Invalid DeviceMode parameter | Use only `DeviceMode.Wired` or `DeviceMode.Wireless` |
| `BadRequestError` | Missing device_id in wireless mode | Include device_id when using wireless mode |
| `GatewayError` | Network connectivity issues | Check connection and retry |

**API Error Responses:**

| Error Code | Reason | Description | Solution |
|------------|--------|-------------|----------|
| `BAD_REQUEST_ERROR` | `device_not_connected` | Device is not connected | Check device connection and try again |
| `BAD_REQUEST_ERROR` | `checkout_not_found` | Checkout session not found | Verify checkout was initiated before closing |

---

## Example Usage

```csharp
using System;
using System.Collections.Generic;
using Razorpay.Api;
using Razorpay.Api.Errors;

class Program
{
    static void Main(string[] args)
    {
        // Initialize client
        var client = new RazorpayClient("http://localhost:8080", "key_id", "key_secret");

        try
        {
            // Step 1: Initiate checkout
            var activityData = new Dictionary<string, object>
            {
                ["device_id"] = "2841158834",
                ["action"] = "initiate_checkout",
                ["notes"] = new Dictionary<string, object>
                {
                    ["merchant_id"] = "12345"
                },
                ["initiate_checkout"] = new Dictionary<string, object>
                {
                    ["name"] = "Acme Corp",
                    ["amount"] = 19900,
                    ["currency"] = "INR",
                    ["description"] = "POS Transaction",
                    ["type"] = "in_person",
                    ["order_id"] = "order_R7vqkfqG3Iw02m",
                    ["prefill"] = new Dictionary<string, object>
                    {
                        ["name"] = "Gaurav Kumar",
                        ["email"] = "gaurav.kumar@example.com",
                        ["contact"] = "9000090000",
                        ["method"] = "upi"
                    }
                }
            };

            var activity = client.DeviceActivity.Create(DeviceMode.Wired, activityData);
            var activityId = activity["id"];
            Console.WriteLine($"Checkout initiated: {activityId}");

            // Step 2: Close checkout when done
            var closeData = new Dictionary<string, object>
            {
                ["device_id"] = "2841158834",
                ["action"] = "close_checkout"
            };

            var closeResponse = client.DeviceActivity.Create(DeviceMode.Wired, closeData);
            Console.WriteLine("Checkout closed successfully");
        }
        catch (BadRequestError ex)
        {
            Console.WriteLine($"Bad Request Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
```

---

## Integration with Order APIs

Device Activity APIs work seamlessly with Order APIs for complete POS integration:

```csharp
// Create order first
var orderData = new Dictionary<string, object>
{
    ["amount"] = 50000,
    ["currency"] = "INR",
    ["receipt"] = "order_001"
};

var order = client.Order.Create(orderData);

// Initiate device checkout using the order
var checkoutData = new Dictionary<string, object>
{
    ["device_id"] = "2841158834",
    ["action"] = "initiate_checkout",
    ["notes"] = new Dictionary<string, object>
    {
        ["order_id"] = order["id"]
    },
    ["initiate_checkout"] = new Dictionary<string, object>
    {
        ["name"] = "Acme Corp",
        ["amount"] = order["amount"],
        ["currency"] = order["currency"],
        ["description"] = "POS Transaction",
        ["type"] = "in_person",
        ["order_id"] = order["id"],
        ["prefill"] = new Dictionary<string, object>
        {
            ["method"] = "upi"
        }
    }
};

var checkout = client.DeviceActivity.Create(DeviceMode.Wired, checkoutData);

// Checkout initiated successfully
Console.WriteLine($"Order: {order["id"]}, Activity: {checkout["id"]}");
``` 

------------------------------------------------------------------------------------------------------- 