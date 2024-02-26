# Changelog

## Version 3.1.1 - 2024-02-27
##### feat: Added support for OAuth APIs and using access token for authentication mechanism.

* Added Support for Oauth APIs
* Added support for access token based authentication mechanism
* Added support for onboarding signature generation
* Updated Documentation


## Version 3.1.0 - 2023-10-31
  ##### feat: Added new API endpoints and implemented response feature in the Delete API.

* Added Support for Account onboarding
* Added Support for `FetchCardDetails`, `RequestCardReference` on Card API
* Added Support for `All` on Customer API
* Added Support for FundAccount API
* Added Support for Item Api
* Added Support for `All`, `Edit`, `Cancel`, `NotifyBy`, `CreateRegistrationLink`, `Issue`, `Delete` on Invoice API
* Added Support for `Edit` on Order API
* Added Support for `BankTransfers`, `Edit`, `FetchPaymentDowntime`, `FetchPaymentDowntimeById`, `CreateJsonPayment`, `CreateRecurringPayment`, `OtpGenerate`, `OtpResend`, `OtpSubmit`, `CreateUpi`, `ValidateUpi` on Payment API
* Added Support for PaymentLink API
* Added Support for Product configuration API
* Added Support for QrCode API
* Added Support for `Edit` on Refund API
* Added Support for Settlement API
* Added Support for stakeholders API
* Added Support for `Cancel`, `CreateAddon`, `Edit`, `FetchPendingUpdate`, `CancelPendingUpdate`, `Pause`, `Resume`, `DeleteOffer` on Subscriprition API
* Added Support for token sharing API
* Added Support for `All` on Transfers API
* Added Support for `AddReceiver`, `AddAllowedPayers` on VirtualAccount API
* Added Support for Webhooks API
* Added Support for PaymentLink & Subscription verification
* Added Documentation API's


## Version 3.0.2 - 2022-10-17
  #### [Bugfix]: Fixed HTTP protocol verbs according this [`doc`](https://learn.microsoft.com/en-us/dotnet/api/system.net.httpwebrequest.method?view=net-6.0#remarks)

## Version 3.0.1 - 2020-01-29
 #### Added
* Transfers fixes
* Support for custom headers in all requests
* Support for setting base URL for Razorpay APIs to a custom value

## Version 2.2 - 2017-11-28
 #### Adds support for new entities
* Add supports for cruds on subscriptions, virtual accounts, plans and addon entities 