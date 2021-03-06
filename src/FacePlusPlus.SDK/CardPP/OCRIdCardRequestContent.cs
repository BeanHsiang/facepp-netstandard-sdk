﻿using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.CardPP
{
    class OCRIdCardRequestContent : CardPPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "ocridcard";

        public override string Version => "v1";

        Stream Image_File = null;

        public string Image_Url { get; set; }

        public byte[] Image_Base64 { get; set; }

        internal string Image_Path { get; set; }

        /// <summary>
        /// whether return legality ocr result
        /// <list type="1">yes</list>
        /// <list type="0">no</list>
        /// </summary>        
        public int? Legality { get; set; }

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

            if (Legality.HasValue)
            {
                content.Add("legality", new StringContent(Legality.ToString()));
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
