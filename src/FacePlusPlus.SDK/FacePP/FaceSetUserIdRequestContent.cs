using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceSetUserIdRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "face/setuserid";

        /// <summary>
        /// face token
        /// </summary>
        public string Face_Token { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        public string User_Id { get; set; }

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

            if (!string.IsNullOrWhiteSpace(User_Id))
            {
                content.Add("user_id", new StringContent(User_Id));
            }
            else
            {
                throw new HttpRequestException("user_id is required");
            }
        }
    }
}
