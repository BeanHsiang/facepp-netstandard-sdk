using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceSetRemoveFaceRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "faceset/removeface";

        /// <summary>
        /// face tokens, comma-separated, 1000 at most, "RemoveAllFaceTokens" means remove all
        /// </summary>
        public string Face_Tokens { get; set; }

        /// <summary>
        /// face set token
        /// </summary>
        public string FaceSet_Token { get; set; }

        /// <summary>
        /// unique custom id, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Outer_Id { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrWhiteSpace(Face_Tokens))
            {
                content.Add("face_tokens", new StringContent(Face_Tokens));
            }

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
        }
    }
}
