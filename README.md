# RSignSDK
### Overview
Unofficial SDK in .NET for [RSign](https://www.rsign.com/) by RPost. This library was created to provide an abstraction layer on top of the API provided by RPost in a convenient manner. It is built on .NET 4.0 because I needed to be able to drop it in to any .NET application.

### Usage
Create an instance of the credentials class and supply it with your EmailId, Password and optionally a ReferenceKey from RPost. Provide the credentials to the API object and authentication will happen automatically when you make an API call to a resource that requires authentication.
```csharp
var credentials = new RSignAPICredentials
{
    "EmailId": "myRsignEmailId@domain.com",
    "Password": "abc123",
    "ReferenceKey": "optional"
};

// Options are optional and have UK based defaults
var options = new RSignAPIOptions
{
    "CultureInfo" = "en-us"
};

byte[] fileBytes = ReadFile("contract.pdf");
string html = ReadEmailTemplate();

// Use RSignAPI(RSignCredentials) ctor for default options
using (var api = new RSignAPI(credentials, options))
{
    var envelopeId = api.Send(
        fileBytes,
        "Contract",
        "New Customer Document",
        "new.customer@email.com",
        "Mr. New Customer",
        "Welcome!",
        html);
    
    Console.WriteLine($"The signing request has been sent and responded with the identifier {envelopeId}");
}
