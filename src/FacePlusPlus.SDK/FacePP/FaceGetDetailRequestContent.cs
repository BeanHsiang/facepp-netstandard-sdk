using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceGetDetailRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "face/getdetail";

        /// <summary>
        /// face token
        /// </summary>
        public string Face_Token { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrWhiteSpace(Face_Token))
            {
                content.Add("face_token", new StringContent(Face_Token));
            }
            else
            {
                throw new HttpRequestException("face_token is required");
            }
        }
    }
}
