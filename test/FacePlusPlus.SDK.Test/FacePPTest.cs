using System;
using Xunit;
using FacePlusPlus;
using System.IO;

namespace FacePlusPlus.SDK.Test
{
    public class FacePPTest
    {
        const string API_Key = "";
        const string API_Secret = "";

        [Fact]
        public void TestDetectImageFile()
        {
            var client = new APIClient(API_Key, API_Secret);
            var response = client.Face_Detect(@"E:\Project\FacePlusPlus\data\demo.jpg");
            Assert.NotNull(response.Request_Id);
            Assert.NotEmpty(response.Faces);
        }

        [Fact]
        public void TestDetectImageUrl()
        {
            var client = new APIClient(API_Key, API_Secret);
            var response = client.Face_Detect(null, image_Url: "https://www.faceplusplus.com.cn/scripts/demoScript/images/demo-pic1.jpg");
            Assert.NotNull(response.Request_Id);
            Assert.NotEmpty(response.Faces);
        }
    }
}
