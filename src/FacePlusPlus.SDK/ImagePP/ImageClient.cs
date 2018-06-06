using System.Net.Http;
using System.Threading.Tasks;

namespace FacePlusPlus
{
    public partial class APIClient
    {
        #region ImagePP

        /// <summary>
        /// Image Recognize Text Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public async Task<ImagePP.ImageRecognizeTextResponseContent> Image_RecognizeTextAsync(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            using (var request = new ImagePP.ImageRecognizeTextRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, ImagePP.ImageRecognizeTextResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// Image Recognize Text
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public ImagePP.ImageRecognizeTextResponseContent Image_RecognizeText(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            var response = Image_RecognizeTextAsync(image_path, image_base64, image_url);
            return response.Result;
        }

        /// <summary>
        /// Image License Plate Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public async Task<ImagePP.ImageLicensePlateResponseContent> Image_LicensePlateAsync(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            using (var request = new ImagePP.ImageLicensePlateRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, ImagePP.ImageLicensePlateResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// Image License Plate
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public ImagePP.ImageLicensePlateResponseContent Image_LicensePlate(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            var response = Image_LicensePlateAsync(image_path, image_base64, image_url);
            return response.Result;
        }

        /// <summary>
        /// Image_Merge Face Async
        /// </summary>
        /// <param name="template_path">path of template image file</param>
        /// <param name="merge_path">path of merge image file</param>
        /// <param name="template_rectangle">template rectangle</param>
        /// <param name="template_base64">byte array of template image file base, encoded by base64</param>
        /// <param name="template_url">url of template image file</param>
        /// <param name="merge_rectangle">merge rectangle</param>
        /// <param name="merge_base64">byte array of merge image file base, encoded by base64</param>
        /// <param name="merge_url">url of merge image file</param>
        /// <param name="merge_rate">merge rate</param>
        /// <returns></returns>
        public async Task<ImagePP.ImageMergeFaceResponseContent> Image_MergeFaceAsync(string template_path, string merge_path, string template_rectangle, byte[] template_base64 = null, string template_url = "", string merge_rectangle = "", byte[] merge_base64 = null, string merge_url = "", int? merge_rate = null)
        {
            using (var request = new ImagePP.ImageMergeFaceRequestContent()
            {
                Template_Path = template_path,
                Template_Base64 = template_base64,
                Template_Url = template_url,
                Template_Rectangle = template_rectangle,
                Merge_Path = merge_path,
                Merge_Base64 = merge_base64,
                Merge_Url = merge_url,
                Merge_Rectangle = merge_rectangle,
                Merge_Rate = merge_rate
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, ImagePP.ImageMergeFaceResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// Image_Merge Face
        /// </summary>
        /// <param name="template_path">path of template image file</param>
        /// <param name="merge_path">path of merge image file</param>
        /// <param name="template_rectangle">template rectangle</param>
        /// <param name="template_base64">byte array of template image file base, encoded by base64</param>
        /// <param name="template_url">url of template image file</param>
        /// <param name="merge_rectangle">merge rectangle</param>
        /// <param name="merge_base64">byte array of merge image file base, encoded by base64</param>
        /// <param name="merge_url">url of merge image file</param>
        /// <param name="merge_rate">merge rate</param>
        /// <returns></returns>
        public ImagePP.ImageMergeFaceResponseContent Image_MergeFace(string template_path, string merge_path, string template_rectangle, byte[] template_base64 = null, string template_url = "", string merge_rectangle = "", byte[] merge_base64 = null, string merge_url = "", int? merge_rate = null)
        {
            var response = Image_MergeFaceAsync(template_path, merge_path, template_rectangle, template_base64, template_url, merge_rectangle, merge_base64, merge_url, merge_rate);
            return response.Result;
        }

        /// <summary>
        /// Image Detect Scene And Object Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public async Task<ImagePP.ImageDetectSceneAndObjectResponseContent> Image_DetectSceneAndObjectAsync(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            using (var request = new ImagePP.ImageDetectSceneAndObjectRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, ImagePP.ImageDetectSceneAndObjectResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// Image Detect Scene And Object
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public ImagePP.ImageDetectSceneAndObjectResponseContent Image_DetectSceneAndObject(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            var response = Image_DetectSceneAndObjectAsync(image_path, image_base64, image_url);
            return response.Result;
        }

        #endregion
    }
}
