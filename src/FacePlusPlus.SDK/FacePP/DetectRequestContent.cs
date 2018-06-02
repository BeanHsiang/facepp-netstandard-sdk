using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class DetectRequestContent : FacePPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "detect";

        Stream Image_File = null;

        public string Image_Url { get; set; }

        public byte[] Image_Base64 { get; set; }

        internal string Image_Path { get; set; }

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

        /// <summary>
        /// whether detect all faces, else only five faces
        /// <list type="1">yes</list>
        /// <list type="0">no</list>
        /// </summary>
        public int? Calculate_All { get; set; }

        /// <summary>
        /// special rectangle: top, left, width, height
        /// </summary>
        public string Face_Rectangle { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            Image_File = content.AddAndGetStream(Image_Path);

            if (Image_File == null && Image_Base64 != null && Image_Base64.Length > 0)
            {
                content.Add("image_base64", new ByteArrayContent(Image_Base64));
            }

            if (Image_File == null && Image_Base64 == null && !string.IsNullOrWhiteSpace(Image_Url))
            {
                content.Add("image_url", new StringContent(Image_Url));
            }

            if (Return_Landmark.HasValue)
            {
                content.Add("return_landmark", new StringContent(Return_Landmark.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(Return_Attributes))
            {
                content.Add("return_attributes", new StringContent(Return_Attributes));
            }

            if (Calculate_All.HasValue)
            {
                content.Add("calculate_all", new StringContent(Calculate_All.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(Face_Rectangle))
            {
                content.Add("face_rectangle", new StringContent(Face_Rectangle));
            }

            if (!content.ContainsKey("image_file") && !content.ContainsKey("image_base64") && !content.ContainsKey("image_url"))
            {
                throw new HttpRequestException("any of image_file, image_base64 and image_url at least");
            }
        }

        public void Dispose()
        {
            if (Image_File != null)
            {
                Image_File.Close();
            }
        }
    }
}
