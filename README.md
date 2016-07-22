[![Build Status](https://travis-ci.org/Rebilly/Rebilly-NET-SDK.svg?branch=master)](https://travis-ci.org/Rebilly/Rebilly-NET-SDK) [![ryans-packages MyGet Build Status](https://www.myget.org/BuildSource/Badge/ryans-packages?identifier=230f6a0f-a009-47e3-bd45-c3297ea6b53c)](https://www.myget.org/)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/Rebilly/Rebilly-NET-SDK/master/LICENSE.md)

# Rebilly .NET SDK (Pre-Release)
The **Rebilly NET SDK** makes it easy for developers to access
[Rebilly REST APIs](https://www.rebilly.com/api/documentation/) from their .NET code.

## Installation

There are two ways to download and install the Rebilly NET SDK.

  1. From the [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console)

  ```
  Install-Package Rebilly.dll -Pre
  ```

  2. Build from the source

  *Clone the Rebilly .NET SDK Repo:
  ```
  git clone https://github.com/Rebilly/Rebilly-NET-SDK.git
  ```
  
  or download it here:
  ```
  https://github.com/Rebilly/Rebilly-NET-SDK/archive/master.zip
  ```
  
  * Locate Rebilly.sln and open in Visual Studio 2013+.
  * It should build without any dependencies.
  

## Requirements

* .NET Framework 4.5+

## Quick Examples

Create a Rebilly Client

```csharp
using Rebilly;

// Ceate a Rebilly client.
var RebillyClient = new Client(apiKey: "YOUR API Key", baseUrl: Client.SandboxHost);
```

Create a Customer

```csharp
  var RebillyClient = new Client(apiKey: "YOUR API KEY", baseUrl: Client.SandboxHost);
  
  var CreateCustomer = new Customer()
  {
      Email = Guid.NewGuid().ToString() + "@gmail.com",
      FirstName = "Bill",
      LastName = "Smith",
      IpAddress = "123.123.133.133"
  };
  
  try
  {
      var NewCustomer = RebillyClient.Customers().Create(CreateCustomer);
  }
  catch(RebillyException ex)
  {
      Console.WriteLine("An error has occurred: " + ex.ToString());
  }
```

## Documentation

Read [https://www.rebilly.com/api/documentation/](https://www.rebilly.com/api/documentation/) for more details.



