﻿using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.HumanBodyPP
{
    class HumanBodyDetectRequestContent : HumanBodyPPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "detect";

        Stream Image_File = null;

        public string Image_Url { get; set; }

        public byte[] Image_Base64 { get; set; }

        internal string Image_Path { get; set; }

        /// <summary>
        /// return attributes list
        /// none or gender,upper_body_cloth,lower_body_cloth
        /// </summary>
        public string Return_Attributes { get; set; }

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

            if (!string.IsNullOrWhiteSpace(Return_Attributes))
            {
                content.Add("return_attributes", new StringContent(Return_Attributes));
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
