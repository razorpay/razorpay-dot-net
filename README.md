Razorpay .NET SDK
=================  
Razorpay client .NET Api. The api follows the following practices
* Namespaced under Razorpay.Api .
* Client throws exceptions instead of returning errors.
* Options are passed as Dictionary instead of multiple arguments wherever possible.
* All request and responses are communicated over JSON.
* A minimum of .Net 4.0 is required.

Installation
--------
If you are using nuget package manager:

`
Install-Package Razorpay
`
=======

else  
* Download Nuget package from [here](https://www.nuget.org/packages/Razorpay)
* Package supports only .Net 4.0 and .net 4.5, Add the required version as reference to your project.

Usage
-----
### Initialize
```cs
RazorpayClient client = new RazorpayClient(key, secret); 
```
                          OR
```cs
RazorpayClient client = new RazorpayClient(baseUrl, key, secret); 
```

### Get Payments
```cs
Dictionary<string, object> options = new Dictionary<string,object>();

options.Add("from", startTime); // start time is a unix timestamp, you can get unix timestamp using                                // Utils.ToUnixTimestamp  method

List<Payment> payments = client.Payment.All(options);
```


### Get Payment using Id
```cs
Payment payment = client.Payment.Fetch(id);
```

### Capture a payment
```cs
Dictionary<string, object> options = new Dictionary<string,object>();

options.Add("amount", amountToBeCaptured); 

Payment payment = payment.Capture(options);
```

### Refund a payment
```cs
Refund refund = payment.createRefund();
```

### Fetch All Refunds for a payment
```cs
List<Refund> refunds = payment.getAllRefunds();
```

### Fetch One Refund for a payment using refund id
```cs
Refund refund = payment.fetchRefund(id);
```

### Accessing the payment attributes
```cs
paymentAmount = payment["amount"];
```

### Create an order
```cs
Dictionary<string, object> options = new Dictionary<string,object>();

options.Add("amount", TransactionAmount); 
options.Add("currency", "INR"); 
options.Add("receipt", "MerchantTransactionId"); 
options.Add("payment_capture", 1); 

Order order = Order.Create(options);
```

### Create a customer
```cs
Dictionary<string, object> options = new Dictionary<string,object>();

options.Add("name", "customer name"); 
options.Add("contact", "9999999999"); 
options.Add("email", "foo@example.com"); 
options.Add("fail_existing", 0); 

Customer customer = Customer.Create(options);
```

Development
-------
* Open solution in visual studio 2013, it should build fine

Ubuntu
------

### Compiling using Mono
* Download the 'Newtonsoft.Json' nuget package.
```
nuget install Newtonsoft.Json -Version 7.0.1 -OutputDirectory packages
```

* Download the 'NUnit' nuget package.
```
nuget install NUnit -Version 3.6.1 -OutputDirectory packages
```

* Create a bin folder in the root directory

```
mkdir bin
```

* Compile the source code into a library  

```
mcs -t:library -lib:"/usr/lib/mono/4.5" -r:"System.dll,System.Net.dll,System.Net.Http.dll,System.Core.dll,System.Xml.dll,System.Xml.Linq.dll,System.Core.dll,./packages/Newtonsoft.Json.7.0.1/lib/net45/Newtonsoft.Json.dll" -out:"bin/RazorpayClient.dll" ./src/**/*.cs -lib:/usr/lib/mono/2.0
```

* copy Dependency dll

```
cp packages/Newtonsoft.Json.7.0.1/lib/net45/Newtonsoft.Json.dll ./bin
cp packages/NUnit.3.6.1/lib/net45/nunit.framework.dll ./bin
```

* Compile test exe

```
mcs -t:exe -lib:"/usr/lib/mono/4.5,./bin" -r:"RazorpayClient.dll,Newtonsoft.Json.dll,nunit.framework.dll" -out:"bin/RazorpayApiTest.exe" ./test/*.cs
```

* Run Test exe  

```
mono bin/RazorpayApiTest.exe [key] [secret]
```


### Compiling using xbuild
Run xbuild (in the root directory where sln file exist)


### FAQ 

1. In case the last command fails with "invalid cert received from server", run below commands
    * yes | certmgr -ssl -m https://go.microsoft.com
    * yes | certmgr -ssl -m https://nugetgallery.blob.core.windows.net
    * yes | certmgr -ssl -m https://myget.org
    * yes | certmgr -ssl -m https://nuget.org
    * mozroots --import --sync --quiet

