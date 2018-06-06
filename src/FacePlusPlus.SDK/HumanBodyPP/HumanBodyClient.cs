using System.Net.Http;
using System.Threading.Tasks;

namespace FacePlusPlus
{
    public partial class APIClient
    {
        #region HumanBodyPP

        /// <summary>
        /// HumanBody Detect Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_attributes">return attributes list</param>
        /// <returns></returns>
        public async Task<HumanBodyPP.HumanBodyDetectResponseContent> HumanBody_DetectAsync(string image_path, byte[] image_base64 = null, string image_url = "", string return_attributes = "")
        {
            using (var request = new HumanBodyPP.HumanBodyDetectRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url,
                Return_Attributes = return_attributes
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, HumanBodyPP.HumanBodyDetectResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// HumanBody Detect
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_attributes">return attributes list</param>
        /// <returns></returns>
        public HumanBodyPP.HumanBodyDetectResponseContent HumanBody_Detect(string image_path, byte[] image_base64 = null, string image_url = "", string return_attributes = "")
        {
            var response = HumanBody_DetectAsync(image_path, image_base64, image_url, return_attributes);
            return response.Result;
        }

        /// <summary>
        /// HumanBody Segment Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public async Task<HumanBodyPP.HumanBodySegmentResponseContent> HumanBody_SegmentAsync(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            using (var request = new HumanBodyPP.HumanBodySegmentRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, HumanBodyPP.HumanBodySegmentResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// HumanBody Segment
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public HumanBodyPP.HumanBodySegmentResponseContent HumanBody_Segment(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            var response = HumanBody_SegmentAsync(image_path, image_base64, image_url);
            return response.Result;
        }

        /// <summary>
        /// HumanBody Gesture Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_gesture">whether return all gestures</param>
        /// <returns></returns>
        public async Task<HumanBodyPP.HumanBodyGestureResponseContent> HumanBody_GestureAsync(string image_path, byte[] image_base64 = null, string image_url = "", string return_gesture = "")
        {
            using (var request = new HumanBodyPP.HumanBodyGestureRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url,
                Return_Gesture = return_gesture
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, HumanBodyPP.HumanBodyGestureResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// HumanBody Gesture
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_gesture">whether return all gestures</param>
        /// <returns></returns>
        public HumanBodyPP.HumanBodyGestureResponseContent HumanBody_Gesture(string image_path, byte[] image_base64 = null, string image_url = "", string return_gesture = "")
        {
            var response = HumanBody_GestureAsync(image_path, image_base64, image_url, return_gesture);
            return response.Result;
        }


        #endregion
    }
}
