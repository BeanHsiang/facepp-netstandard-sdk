![Face++][LOGO]

[![nuget][nuget-badge]][NUGET] [![version][version-badge]][CHANGELOG] [![license][license-badge]][LICENSE]

-----------------------------------------------------------------------------

Face++ SDK for .NET Standard
============================

This is Face++ SDK for .NET Standard version.

The official website: 
* [Face++ EN](https://www.faceplusplus.com/)
* [Face++ CN](https://www.faceplusplus.com.cn/)


API Doc: 
* [Face++ Doc EN](https://console.faceplusplus.com/documents/7079083)
* [Face++ Doc CN](https://console.faceplusplus.com.cn/documents/5671787)


## Getting Started

### Install Package

Package Manager:

    Install-Package FacePlusPlus.SDK -Version 1.3.0

.NET CLI:

    dotnet add package FacePlusPlus.SDK --version 1.3.0

### Set API key and secret

```csharp
const string API_Key = "Your App API KEY";
const string API_Secret = "Your App API Secret";
```

### Face Detect via Image File

```csharp
var client = new APIClient(API_Key, API_Secret);
var response = client.Face_Detect("/image/file/path");
Assert.NotNull(response.Request_Id);
Assert.NotEmpty(response.Faces);
```

### Face Detect via Image Url

```csharp
var client = new APIClient(API_Key, API_Secret);
var response = client.Face_Detect(null, image_Url: "image url");
Assert.NotNull(response.Request_Id);
Assert.NotEmpty(response.Faces);
```

[LOGO]: ./logo.png
[CHANGELOG]: ./CHANGELOG.md
[LICENSE]: ./LICENSE
[NUGET]: https://www.nuget.org/packages/FacePlusPlus.SDK
[nuget-badge]: https://img.shields.io/badge/nuget-1.3.0-blue.svg
[version-badge]: https://img.shields.io/badge/version-1.3.0-blue.svg
[license-badge]: https://img.shields.io/badge/license-MIT-blue.svg
