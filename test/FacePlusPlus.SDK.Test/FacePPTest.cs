using Xunit;

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
            var attrs = "gender,age,smiling,headpose,facequality,blur,eyestatus,emotion,ethnicity,beauty,mouthstatus,eyegaze,skinstatus";
            var response = client.Face_Detect(null, image_url: "https://www.faceplusplus.com.cn/scripts/demoScript/images/demo-pic1.jpg", return_attributes: attrs, return_landmark: 2);
            Assert.NotNull(response.Request_Id);
            Assert.NotEmpty(response.Faces);
        }
    }
}
