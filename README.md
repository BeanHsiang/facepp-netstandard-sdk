![Face++][LOGO]

[![version][version-badge]][CHANGELOG] [![license][license-badge]][LICENSE]

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

[LOGO]: https://www.faceplusplus.com.cn/images/cn/header/face-cn.png
[CHANGELOG]: ./CHANGELOG.md
[LICENSE]: ./LICENSE
[fork]: https://help.github.com/articles/fork-a-repo/
[version-badge]: https://img.shields.io/badge/version-1.0.0-blue.svg
[license-badge]: https://img.shields.io/badge/license-MIT-blue.svg