using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class BeautifyRequestContent : FacePPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "beautify";

        public override string Version => "beta";

        Stream Image_File = null;

        public string Image_Url { get; set; }

        public byte[] Image_Base64 { get; set; }

        internal string Image_Path { get; set; }

        /// <summary>
        /// whitening level (0-100)
        /// </summary>        
        public int? Whitening { get; set; }

        /// <summary>
        /// smoothing level (0-100)
        /// </summary>
        public int? Smoothing { get; set; }

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

            if (Whitening.HasValue)
            {
                if (Whitening.Value > 100)
                {
                    Whitening = 100;
                }
                if (Whitening.Value < 0)
                {
                    Whitening = 0;
                }
                content.Add("whitening", new StringContent(Whitening.ToString()));
            }

            if (Smoothing.HasValue)
            {
                if (Smoothing.Value > 100)
                {
                    Smoothing = 100;
                }
                if (Smoothing.Value < 0)
                {
                    Smoothing = 0;
                }
                content.Add("smoothing", new StringContent(Smoothing.ToString()));
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
