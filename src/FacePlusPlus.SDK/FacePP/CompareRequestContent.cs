using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class CompareRequestContent : FacePPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "compare";

        Stream Image_File1 = null;

        Stream Image_File2 = null;

        public string Face_Token1 { get; set; }

        public string Image_Url1 { get; set; }

        public byte[] Image_Base64_1 { get; set; }

        internal string Image_Path1 { get; set; }

        public string Face_Rectangle1 { get; set; }

        public string Face_Token2 { get; set; }

        public string Image_Url2 { get; set; }

        public byte[] Image_Base64_2 { get; set; }

        internal string Image_Path2 { get; set; }

        public string Face_Rectangle2 { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrEmpty(Face_Token1))
            {
                content.Add("face_token1", new StringContent(Face_Token1));
            }
            else
            {
                Image_File1 = content.AddAndGetStream(Image_Path1, "image_file1");
            }

            if (Image_File1 == null && Image_Base64_1 != null && Image_Base64_1.Length > 0)
            {
                content.Add("image_base64_1", new ByteArrayContent(Image_Base64_1));
            }

            if (Image_File1 == null && Image_Base64_1 == null && !string.IsNullOrWhiteSpace(Image_Url1))
            {
                content.Add("image_url", new StringContent(Image_Url1));
            }

            if (!string.IsNullOrWhiteSpace(Face_Rectangle1))
            {
                content.Add("face_rectangle1", new StringContent(Face_Rectangle1));
            }

            if (!content.ContainsKey("face_token1") && !content.ContainsKey("image_file1") && !content.ContainsKey("image_base64_1") && !content.ContainsKey("image_url1"))
            {
                throw new HttpRequestException("any of face_token1, image_file1, image_base64_1 and image_url1 at least");
            }

            if (!string.IsNullOrEmpty(Face_Token2))
            {
                content.Add("face_token2", new StringContent(Face_Token2));
            }
            else
            {
                Image_File2 = content.AddAndGetStream(Image_Path2, "image_file2");
            }

            if (Image_File2 == null && Image_Base64_2 != null && Image_Base64_2.Length > 0)
            {
                content.Add("image_base64_2", new ByteArrayContent(Image_Base64_2));
            }

            if (Image_File2 == null && Image_Base64_2 == null && !string.IsNullOrWhiteSpace(Image_Url2))
            {
                content.Add("image_url2", new StringContent(Image_Url2));
            }

            if (!string.IsNullOrWhiteSpace(Face_Rectangle2))
            {
                content.Add("face_rectangle2", new StringContent(Face_Rectangle2));
            }

            if (!content.ContainsKey("face_token2") && !content.ContainsKey("image_file2") && !content.ContainsKey("image_base64_2") && !content.ContainsKey("image_url2"))
            {
                throw new HttpRequestException("any of face_token2, image_file2, image_base64_2 and image_url2 at least");
            }
        }

        public void Dispose()
        {
            if (Image_File1 != null)
            {
                Image_File1.Close();
            }

            if (Image_File2 != null)
            {
                Image_File2.Close();
            }
        }
    }
}
