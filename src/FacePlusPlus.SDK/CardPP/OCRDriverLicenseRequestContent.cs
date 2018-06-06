using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.CardPP
{
    class OCRDriverLicenseRequestContent : CardPPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "ocrdriverlicense";

        public override string Version => "v2";

        Stream Image_File = null;

        public string Image_Url { get; set; }

        //public byte[] Image_Base64 { get; set; }

        internal string Image_Path { get; set; }

        /// <summary>
        /// whether return ocr score
        /// <list type="1">yes</list>
        /// <list type="0">no</list>
        /// </summary>        
        public int? Return_Score { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            Image_File = content.AddAndGetStream(Image_Path);

            //if (Image_File == null && Image_Base64 != null && Image_Base64.Length > 0)
            //{
            //    content.Add("image_base64", new ByteArrayContent(Image_Base64));
            //}

            if (Image_File == null && !string.IsNullOrWhiteSpace(Image_Url))
            {
                content.Add("image_url", new StringContent(Image_Url));
            }

            if (Return_Score.HasValue)
            {
                content.Add("return_score", new StringContent(Return_Score.ToString()));
            }

            if (!content.ContainsKey("image_file") && !content.ContainsKey("image_url"))
            {
                throw new HttpRequestException("any of image_file and image_url at least");
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
