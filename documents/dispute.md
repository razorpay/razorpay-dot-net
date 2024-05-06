## Dispute

### Fetch All Disputes

```C#
List<Dispute> disputes = client.Dispute.All();
```

**Response:**
```json
{
  "entity": "collection",
  "count": 1,
  "items": [
    {
      "id": "disp_Esz7KAitoYM7PJ",
      "entity": "dispute",
      "payment_id": "pay_EsyWjHrfzb59eR",
      "amount": 10000,
      "currency": "INR",
      "amount_deducted": 0,
      "reason_code": "pre_arbitration",
      "respond_by": 1590604200,
      "status": "open",
      "phase": "pre_arbitration",
      "created_at": 1590059211,
      "evidence": {
        "amount": 10000,
        "summary": null,
        "shipping_proof": null,
        "billing_proof": null,
        "cancellation_proof": null,
        "customer_communication": null,
        "proof_of_service": null,
        "explanation_letter": null,
        "refund_confirmation": null,
        "access_activity_log": null,
        "refund_cancellation_policy": null,
        "term_and_conditions": null,
        "others": null,
        "submitted_at": null
      }
    }
  ]
}
```
-------------------------------------------------------------------------------------------------------

### Fetch a Dispute

```C#
String disputeId = "disp_0000000000000";

Dispute dispute = client.Dispute.Fetch(disputeId);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| disputeId*  | string | The unique identifier of the dispute.  |

**Response:**
```json
{
  "id": "disp_AHfqOvkldwsbqt",
  "entity": "dispute",
  "payment_id": "pay_EsyWjHrfzb59eR",
  "amount": 10000,
  "currency": "INR",
  "amount_deducted": 0,
  "reason_code": "pre_arbitration",
  "respond_by": 1590604200,
  "status": "open",
  "phase": "pre_arbitration",
  "created_at": 1590059211,
  "evidence": {
    "amount": 10000,
    "summary": "goods delivered",
    "shipping_proof": null,
    "billing_proof": null,
    "cancellation_proof": null,
    "customer_communication": null,
    "proof_of_service": null,
    "explanation_letter": null,
    "refund_confirmation": null,
    "access_activity_log": null,
    "refund_cancellation_policy": null,
    "term_and_conditions": null,
    "others": null,
    "submitted_at": null
  }
}
```
-------------------------------------------------------------------------------------------------------
### Accept a Dispute

```C#
String disputeId = "disp_0000000000000";
Dispute dispute = client.Dispute.Fetch(disputeId).Accept();
```
**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| disputeId*  | string | The unique identifier of the dispute.  |

**Response:**
```json
{
  "id": "disp_AHfqOvkldwsbqt",
  "entity": "dispute",
  "payment_id": "pay_EsyWjHrfzb59eR",
  "amount": 10000,
  "currency": "INR",
  "amount_deducted": 10000,
  "reason_code": "pre_arbitration",
  "respond_by": 1590604200,
  "status": "lost",
  "phase": "pre_arbitration",
  "created_at": 1590059211,
  "evidence": {
    "amount": 10000,
    "summary": null,
    "shipping_proof": null,
    "billing_proof": null,
    "cancellation_proof": null,
    "customer_communication": null,
    "proof_of_service": null,
    "explanation_letter": null,
    "refund_confirmation": null,
    "access_activity_log": null,
    "refund_cancellation_policy": null,
    "term_and_conditions": null,
    "others": null,
    "submitted_at": null
  }
}
```

-------------------------------------------------------------------------------------------------------
### Contest a Dispute

```C#
// Use this API sample code for draft

String disputeId = "disp_0000000000000";

Dictionary<string, object> disputeRequest = new Dictionary<string, object>();
disputeRequest.Add("amount",5000);
disputeRequest.Add("summary","goods delivered");
List<string> shipping_proof = new List<string>();
shipping_proof.Add("doc_EFtmUsbwpXwBH9");
shipping_proof.Add("doc_EFtmUsbwpXwBH8");
disputeRequest.Add("shipping_proof", shipping_proof);
List<Dictionary<string, object>> others = new List<Dictionary<string, object>>();
Dictionary<string, object> otherParam = new Dictionary<string, object>();
otherParam.Add("type","receipt_signed_by_customer");
List<string> doc = new List<string>();
doc.Add("doc_EFtmUsbwpXwBH1");
doc.Add("doc_EFtmUsbwpXwBH7");
otherParam.Add("document_ids",doc);
others.Add(otherParam);
disputeRequest.Add("others", others);
disputeRequest.Add("action", "submit");

Dispute dispute = client.Dispute.Fetch(disputeId).Contest(disputeRequest);
```

**Parameters:**

| Name  | Type      | Description                                      |
|-------|-----------|--------------------------------------------------|
| disputeId*  | string | The unique identifier of the dispute.  |
| amount  | integer | The amount being contested. If the contest amount is not mentioned, we will assume it to be a full dispute contest.  |
| summary  | string | The explanation provided by you for contesting the dispute. It can have a maximum length of 1000 characters. |
| shipping_proof  | array | List of document ids which serves as proof that the product was shipped to the customer at their provided address. It should show their complete shipping address, if possible. |
| others  | array | All keys listed [here](https://razorpay.com/docs/api/disputes/contest) are supported |

```C#
// Use this API sample code for submit

String disputeId = "disp_0000000000000";

Dictionary<string, object> disputeRequest = new Dictionary<string, object>();
List<string> billing_proof = new List<string>();
billing_proof.Add("doc_EFtmUsbwpXwBH9");
billing_proof.Add("doc_EFtmUsbwpXwBH8");
disputeRequest.Add("billing_proof", billing_proof);
disputeRequest.Add("action", "submit");

Dispute dispute = client.Dispute.Fetch(disputeId).Contest(disputeRequest);
```

**Response:**
```json
// Draft
{
  "id": "disp_AHfqOvkldwsbqt",
  "entity": "dispute",
  "payment_id": "pay_EsyWjHrfzb59eR",
  "amount": 10000,
  "currency": "INR",
  "amount_deducted": 0,
  "reason_code": "chargeback",
  "respond_by": 1590604200,
  "status": "open",
  "phase": "chargeback",
  "created_at": 1590059211,
  "evidence": {
    "amount": 5000,
    "summary": "goods delivered",
    "shipping_proof": [
      "doc_EFtmUsbwpXwBH9",
      "doc_EFtmUsbwpXwBH8"
    ],
    "billing_proof": null,
    "cancellation_proof": null,
    "customer_communication": null,
    "proof_of_service": null,
    "explanation_letter": null,
    "refund_confirmation": null,
    "access_activity_log": null,
    "refund_cancellation_policy": null,
    "term_and_conditions": null,
    "others": [
      {
        "type": "receipt_signed_by_customer",
        "document_ids": [
          "doc_EFtmUsbwpXwBH1",
          "doc_EFtmUsbwpXwBH7"
        ]
      }
    ],
    "submitted_at": null
  }
}

//Submit 
{
  "id": "disp_AHfqOvkldwsbqt",
  "entity": "dispute",
  "payment_id": "pay_EsyWjHrfzb59eR",
  "amount": 10000,
  "currency": "INR",
  "amount_deducted": 0,
  "reason_code": "chargeback",
  "respond_by": 1590604200,
  "status": "under_review",
  "phase": "chargeback",
  "created_at": 1590059211,
  "evidence": {
    "amount": 5000,
    "summary": "goods delivered",
    "shipping_proof": [
      "doc_EFtmUsbwpXwBH9",
      "doc_EFtmUsbwpXwBH8"
    ],
    "billing_proof": [
      "doc_EFtmUsbwpXwBG9",
      "doc_EFtmUsbwpXwBG8"
    ],
    "cancellation_proof": null,
    "customer_communication": null,
    "proof_of_service": null,
    "explanation_letter": null,
    "refund_confirmation": null,
    "access_activity_log": null,
    "refund_cancellation_policy": null,
    "term_and_conditions": null,
    "others": [
      {
        "type": "receipt_signed_by_customer",
        "document_ids": [
          "doc_EFtmUsbwpXwBH1",
          "doc_EFtmUsbwpXwBH7"
        ]
      }
    ],
    "submitted_at": 1590603200
  }
}
```
-------------------------------------------------------------------------------------------------------
**PN: * indicates mandatory fields**
<br>
<br>
**For reference click [here](https://razorpay.com/docs/api/documents)**