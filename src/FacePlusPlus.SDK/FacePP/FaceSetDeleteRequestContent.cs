using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceSetDeleteRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "faceset/delete";

        /// <summary>
        /// face set token
        /// </summary>
        public string FaceSet_Token { get; set; }

        /// <summary>
        /// unique custom id, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Outer_Id { get; set; }

        /// <summary>
        /// check face set whether is empty
        /// <list type="1">yes</list>
        /// <list type="0">no</list>
        /// </summary>        
        public int? Check_Empty { get; set; }

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

            if (Check_Empty.HasValue)
            {
                content.Add("check_empty", new StringContent(Check_Empty.Value.ToString()));
            }
        }
    }
}
