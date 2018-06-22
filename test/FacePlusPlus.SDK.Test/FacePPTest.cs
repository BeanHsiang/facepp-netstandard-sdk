using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace FacePlusPlus.SDK.Test
{
    public class TestBase
    {
        protected readonly string API_Key = "";
        protected readonly string API_Secret = "";

        public static IConfigurationRoot Config { get; private set; }

        public TestBase()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("app.json")
           .Build();

            API_Key = config["facepp:API_Key"];
            API_Secret = config["facepp:API_Secret"];
        }
    }

    public class FacePPTest : TestBase
    {
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
            var attrs = "gender,age,smiling,headpose,facequality,blur,eyestatus,emotion,ethnicity,beauty,mouthstatus,eyegaze,skinstatus";
            var response = client.Face_Detect(null, image_url: "https://www.faceplusplus.com.cn/scripts/demoScript/images/demo-pic1.jpg", return_attributes: attrs, return_landmark: 2);
            Assert.NotNull(response.Request_Id);
            Assert.NotEmpty(response.Faces);
        }

        [Fact]
        public void TestGetFaceSets()
        {
            var client = new APIClient(API_Key, API_Secret);
            var response = client.FaceSet_GetFaceSets();
            Assert.NotNull(response.Request_Id);
        }

        [Fact]
        public void TestDeleteFaceSets()
        {
            var client = new APIClient(API_Key, API_Secret);
            var response = client.FaceSet_Delete("e990bf901a8ce077230d734af047071a", check_empty: 0);
            Assert.NotNull(response.Request_Id);
        }
    }
}