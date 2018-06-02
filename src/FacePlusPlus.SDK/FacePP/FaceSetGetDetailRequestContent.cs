using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceSetGetDetailRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "faceset/getdetail";

        /// <summary>
        /// face set token
        /// </summary>
        public string FaceSet_Token { get; set; }

        /// <summary>
        /// unique custom id, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Outer_Id { get; set; }

        /// <summary>
        /// sequence in face set, [1, 1000], maybe "next" value in lastest response
        /// </summary>
        public int? Start { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrWhiteSpace(Outer_Id))
            {
                content.Add("outer_id", new StringContent(Outer_Id));
            }

            if (!string.IsNullOrWhiteSpace(FaceSet_Token))
            {
                content.Add("faceset_token", new StringContent(FaceSet_Token));
            }

            if (!content.ContainsKey("faceset_token") && !content.ContainsKey("outer_id"))
            {
                throw new HttpRequestException("either faceset_token or outer_id at least");
            }

            if (Start.HasValue)
            {
                content.Add("start", new StringContent(Start.Value.ToString()));
            }
        }
    }
}
