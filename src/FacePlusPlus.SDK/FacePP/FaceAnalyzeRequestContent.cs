using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceAnalyzeRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "face/analyze";

        /// <summary>
        /// face tokens, comma-separated, 5 at most
        /// </summary>
        public string Face_Tokens { get; set; }

        /// <summary>
        /// whether return landmark
        /// <list type="2">106 attributes</list>
        /// <list type="1">83 attributes</list>
        /// <list type="0">none</list>
        /// </summary>        
        public int? Return_Landmark { get; set; }

        /// <summary>
        /// return attributes list
        /// none or gender,age,smiling,headpose,facequality,blur,eyestatus,emotion,ethnicity,beauty,mouthstatus,eyegaze,skinstatus
        /// </summary>
        public string Return_Attributes { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrWhiteSpace(Face_Tokens))
            {
                content.Add("face_tokens", new StringContent(Face_Tokens));
            }
            else
            {
                throw new HttpRequestException("face_tokens is required");
            }

            if (Return_Landmark.HasValue)
            {
                content.Add("return_landmark", new StringContent(Return_Landmark.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(Return_Attributes))
            {
                content.Add("return_attributes", new StringContent(Return_Attributes));
            }

            if (!content.ContainsKey("return_landmark") && !content.ContainsKey("return_attributes"))
            {
                throw new HttpRequestException("any of return_landmark and return_attributes at least");
            }
        }
    }
}
