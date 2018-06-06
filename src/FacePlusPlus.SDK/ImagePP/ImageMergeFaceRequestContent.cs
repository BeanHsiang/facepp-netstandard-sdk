using FacePlusPlus.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.ImagePP
{
    class ImageMergeFaceRequestContent : ImagePPRequestContent<MultipartFormDataContent>, IDisposable
    {
        public override string Name => "mergeface";

        Stream Template_File = null;

        Stream Merge_File = null;

        public string Template_Url { get; set; }

        public byte[] Template_Base64 { get; set; }

        internal string Template_Path { get; set; }

        public string Template_Rectangle { get; set; }

        public string Merge_Url { get; set; }

        public byte[] Merge_Base64 { get; set; }

        internal string Merge_Path { get; set; }

        public string Merge_Rectangle { get; set; }

        public int? Merge_Rate { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            Template_File = content.AddAndGetStream(Template_Path, "template_file");

            if (Template_File == null && Template_Base64 != null && Template_Base64.Length > 0)
            {
                content.Add("template_base64", new ByteArrayContent(Template_Base64));
            }

            if (Template_File == null && Template_Base64 == null && !string.IsNullOrWhiteSpace(Template_Url))
            {
                content.Add("template_url", new StringContent(Template_Url));
            }

            if (!content.ContainsKey("template_file") && !content.ContainsKey("template_base64") && !content.ContainsKey("template_url"))
            {
                throw new HttpRequestException("any of template_file, template_base64 and template_url at least");
            }

            if (!string.IsNullOrWhiteSpace(Template_Rectangle))
            {
                content.Add("template_rectangle", new StringContent(Template_Rectangle));
            }
            else
            {
                throw new HttpRequestException("template_rectangle is required");
            }

            Merge_File = content.AddAndGetStream(Merge_Path, "merge_file");

            if (Merge_File == null && Merge_Base64 != null && Merge_Base64.Length > 0)
            {
                content.Add("merge_base64", new ByteArrayContent(Merge_Base64));
            }

            if (Merge_File == null && Merge_Base64 == null && !string.IsNullOrWhiteSpace(Merge_Url))
            {
                content.Add("merge_url", new StringContent(Merge_Url));
            }

            if (!content.ContainsKey("merge_file") && !content.ContainsKey("merge_base64") && !content.ContainsKey("merge_url"))
            {
                throw new HttpRequestException("any of merge_file, merge_base64 and merge_url at least");
            }

            if (!string.IsNullOrWhiteSpace(Merge_Rectangle))
            {
                content.Add("merge_rectangle", new StringContent(Merge_Rectangle));
            }

            if (Merge_Rate.HasValue)
            {
                content.Add("merge_rate", new StringContent(Merge_Rate.Value.ToString()));
            }
        }

        public void Dispose()
        {
            if (Template_File != null)
            {
                Template_File.Close();
            }

            if (Merge_File != null)
            {
                Merge_File.Close();
            }
        }
    }
}
