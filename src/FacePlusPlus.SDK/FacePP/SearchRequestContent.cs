using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class SearchRequestContent : FacePPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "search";

        Stream Image_File = null;

        public string Face_Token { get; set; }

        public string Image_Url { get; set; }

        public byte[] Image_Base64 { get; set; }

        internal string Image_Path { get; set; }

        public string FaceSet_Token { get; set; }

        public string Outer_Id { get; set; }

        public int Return_Result_Count { get; set; }

        /// <summary>
        /// special rectangle: top, left, width, height
        /// </summary>
        public string Face_Rectangle { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrEmpty(Face_Token))
            {
                content.Add("face_token", new StringContent(Face_Token));
            }
            else
            {
                Image_File = content.AddAndGetStream(Image_Path);
            }

            if (Image_File == null && Image_Base64 != null && Image_Base64.Length > 0)
            {
                //var imageContent = new ByteArrayContent(sc.ReadAsByteArrayAsync().Result);
                //imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                //content.Add(imageContent, "image_file", "myfile.jpg");
                content.Add("image_base64", new ByteArrayContent(Image_Base64));
            }

            if (Image_File == null && Image_Base64 == null && !string.IsNullOrWhiteSpace(Image_Url))
            {
                content.Add("image_url", new StringContent(Image_Url));
            }

            if (!string.IsNullOrWhiteSpace(FaceSet_Token))
            {
                content.Add("faceset_token", new StringContent(FaceSet_Token));
            }

            if (!string.IsNullOrWhiteSpace(Outer_Id))
            {
                content.Add("outer_id", new StringContent(Outer_Id));
            }

            if (!string.IsNullOrWhiteSpace(Face_Rectangle))
            {
                content.Add("face_rectangle", new StringContent(Face_Rectangle));
            }

            if (Return_Result_Count < 1 || Return_Result_Count > 5)
            {
                Return_Result_Count = 1;
            }
            content.Add("return_result_count", new StringContent(Return_Result_Count.ToString()));

            if (!content.ContainsKey("face_token") && !content.ContainsKey("image_file") && !content.ContainsKey("image_base64") && !content.ContainsKey("image_url"))
            {
                throw new HttpRequestException("any of face_token, image_file, image_base64 and image_url at least");
            }

            if (!content.ContainsKey("faceset_token") && !content.ContainsKey("outer_id"))
            {
                throw new HttpRequestException("either faceset_token or outer_id at least");
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
