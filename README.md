# RSignSDK
### Overview
Unofficial SDK in .NET for [RSign](https://www.rsign.com/) by RPost. This library was created to provide an abstraction layer on top of the API provided by RPost in a convenient manner. It is built on .NET 4.0 because I needed to be able to drop it in to an older .NET application.

### Usage
Create an instance of the credentials class and supply it with your EmailId, Password and optionally a ReferenceKey from RPost. Provide the credentials to the API object and authentication will happen automatically when you make an API call to a resource that requires authentication.
```csharp
var credentials = new RSignAPICredentials
{
    "EmailId": "myRsignEmailId@domain.com",
    "Password": "abc123",
    "ReferenceKey": "optional"
};

IEnumerable<Font> fonts;

using (var api = new RSignAPI(credentials))
{
    fonts = api.GetFonts();
}

foreach (var font in fonts)
{
    Console.WriteLine(font.FontFamily);
}
