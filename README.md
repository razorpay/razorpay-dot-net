# Razorpay .NET SDK
  
Razorpay client .NET Api. The api follows the following practices
* Namespaced under Razorpay.Api .
* Client throws exceptions instead of returning errors.
* Options are passed as Dictionary instead of multiple arguments wherever possible.
* All requests and responses are communicated over JSON.
* A minimum of .Net 4.0 is required.


## Installation

Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/dotnet/core/tools/)

```sh
nuget install Razorpay
```

else  
* Download Nuget package from [here](https://www.nuget.org/packages/Razorpay)
* **Package supports .NET Framework 4.7+, .NET Standard 2.0, .NET 6.0+**
* **For .NET Framework 4.0/4.5**: Manual compilation required (see Legacy Framework Support section below)

Usage
-----

`RazorpayClient` can be instantiated via two ways:

### Using Private Auth
Instantiate `RazorpayClient` with `key_id` & `key_secret`. You can obtain the keys from the dashboard app https://dashboard.razorpay.com/#/app/keys
```C#
RazorpayClient client = new RazorpayClient(key, secret); 
```

#### Add custom headers to request (optional)
```C#
client.addHeader(string,string);
```

### Using Access Token
Instantiate `RazorpayClient` with `access_token`. The `access_token` can be obtained only in case if you are a platform partner. For more information, refer page - https://razorpay.com/docs/partners/platform/.
```C#
RazorpayClient client = new RazorpayClient(access_token); 
```

#### Add custom headers to request (optional)
```C#
client.addHeader(string,string);
```

## Supported Resources
- [Addon](documents/addon.md)

- [Account](documents/account.md)

- [Cards](documents/card.md)

- [Customer](documents/customers.md)

- [Emandate](documents/emandate.md)

- [Fund](documents/fund.md)

- [Invoice](documents/invoice.md)

- [Item](documents/item.md)

- [Order](documents/order.md)

- [Payments](documents/payment.md)

- [Product Configuration](documents/product.md)

- [Paper NACH](documents/papernach.md)

- [Payment Verification](documents/paymentVerfication.md)

- [Payment Links](documents/paymentlink.md)

- [Plan](documents/plan.md)

- [QR Code](documents/qrcode.md)

- [Refunds](documents/refund.md)

- [Route](documents/transfers.md)

- [Register Emandate and Charge First Payment Together](documents/registerEmandate.md)

- [Register NACH and Charge First Payment Together](documents/registerNach.md)

- [Settlements](documents/Settlement.md)

- [Stakeholder](documents/stakeholder.md)

- [Subscriptions](documents/subscription.md)

- [Token](documents/token.md)

- [Smart Collect](documents/virtualAccount.md)

- [Webhook](documents/webhook.md)

- [OAuth Token Client](documents/oAuthTokenClient.md)

- [Dispute](documents/dispute.md)
---

## Development

### Quick Start
The project now uses a unified multi-targeting approach. Simply:

```bash
# Restore dependencies
dotnet restore

# Build all target frameworks
dotnet build --configuration Release

# Create NuGet package
dotnet pack --configuration Release
```

### Target Frameworks Supported
- .NET Framework 4.7, 4.8
- .NET Standard 2.0 ⭐ (New - maximum compatibility)
- .NET 6.0, 8.0

> **📢 Important Note:** We do not provide pre-built DLLs for .NET Framework 4.0 and 4.5 in our NuGet package. These frameworks are legacy (2010-2012) and most applications have migrated to newer versions. However, you can still use Razorpay with these frameworks by compiling the source code manually.

### Legacy Framework Support (.NET 4.0, 4.5)
**Not included in NuGet package** - For .NET Framework 4.0 and 4.5 support, you can manually compile the source code:

#### Manual Compilation for .NET 4.0/4.5
```bash
# 1. Install required NuGet packages
nuget install Newtonsoft.Json -Version 13.0.3 -OutputDirectory packages
nuget install Portable.BouncyCastle -Version 1.9.0 -OutputDirectory packages

# 2. Compile for .NET 4.0
csc /target:library /out:Razorpay-net40.dll /reference:packages/Newtonsoft.Json.13.0.3/lib/net40/Newtonsoft.Json.dll /reference:packages/Portable.BouncyCastle.1.9.0/lib/net40/BouncyCastle.Crypto.dll /reference:System.dll /reference:System.Core.dll /reference:System.Net.dll /reference:System.Net.Http.dll /reference:Microsoft.CSharp.dll src/**/*.cs

# 3. Compile for .NET 4.5  
csc /target:library /out:Razorpay-net45.dll /reference:packages/Newtonsoft.Json.13.0.3/lib/net45/Newtonsoft.Json.dll /reference:packages/Portable.BouncyCastle.1.9.0/lib/net40/BouncyCastle.Crypto.dll /reference:System.dll /reference:System.Core.dll /reference:System.Net.dll /reference:System.Net.Http.dll /reference:Microsoft.CSharp.dll src/**/*.cs
```

**Note:** .NET Standard 2.0 provides better compatibility and is recommended over .NET Framework 4.0/4.5.

### IDE Support
* **Visual Studio 2022**: Open `Razorpay.sln` - it will build all target frameworks
* **VS Code**: Use the integrated terminal with the dotnet CLI commands above
* **JetBrains Rider**: Full multi-targeting support

### CI/CD
The project includes GitHub Actions workflow that:
- Builds all target frameworks on both Linux and Windows
- Runs tests (if available)
- Creates NuGet packages
- Publishes to NuGet on master branch (if configured)

## Ubuntu


### Compiling using Mono
* Download the 'Newtonsoft.Json' nuget package.
```
nuget install Newtonsoft.Json -Version 13.0.3 -OutputDirectory packages
```

* Download the 'Portable.BouncyCastle' nuget package.
```
nuget install Portable.BouncyCastle -Version 1.9.0 -OutputDirectory packages
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
mcs -t:library -lib:"/usr/lib/mono/4.5" -r:"System.dll,System.Net.dll,System.Net.Http.dll,System.Core.dll,System.Xml.dll,System.Xml.Linq.dll,System.Core.dll,./packages/Newtonsoft.Json.13.0.3/lib/net45/Newtonsoft.Json.dll,./packages/Portable.BouncyCastle.1.9.0/lib/net40/BouncyCastle.Crypto.dll" -out:"bin/RazorpayClient.dll" ./src/**/*.cs -lib:/usr/lib/mono/2.0
```

* copy Dependency dll

```
cp packages/Newtonsoft.Json.13.0.3/lib/net45/Newtonsoft.Json.dll ./bin
cp packages/Portable.BouncyCastle.1.9.0/lib/net40/BouncyCastle.Crypto.dll ./bin
cp packages/NUnit.3.6.1/lib/net45/nunit.framework.dll ./bin
```

* Compile test exe

```
mcs -t:exe -lib:"/usr/lib/mono/4.5,./bin" -r:"RazorpayClient.dll,Newtonsoft.Json.dll,BouncyCastle.Crypto.dll,nunit.framework.dll" -out:"bin/RazorpayApiTest.exe" ./test/*.cs
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
