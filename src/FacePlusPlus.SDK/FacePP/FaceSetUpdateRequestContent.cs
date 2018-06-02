using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceSetUpdateRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "faceset/update";

        /// <summary>
        /// face set token
        /// </summary>
        public string FaceSet_Token { get; set; }

        /// <summary>
        /// unique custom id, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Outer_Id { get; set; }

        /// <summary>
        /// name of face set, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Display_Name { get; set; }

        /// <summary>
        /// unique custom id, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string New_Outer_Id { get; set; }

        /// <summary>
        /// custom tags, comma-separated, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// custom information, 16 KB at most, exclude: ^@,&=*'"
        /// </summary>
        public string User_Data { get; set; }

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

            if (!string.IsNullOrWhiteSpace(Display_Name))
            {
                content.Add("display_name", new StringContent(Display_Name));
            }

            if (!string.IsNullOrWhiteSpace(New_Outer_Id))
            {
                content.Add("new_outer_id", new StringContent(New_Outer_Id));
            }

            if (!string.IsNullOrWhiteSpace(Tags))
            {
                content.Add("tags", new StringContent(Tags));
            }

            if (!string.IsNullOrWhiteSpace(User_Data))
            {
                content.Add("user_data", new StringContent(User_Data));
            }

            if (!content.ContainsKey("display_name") && !content.ContainsKey("new_outer_id") && !content.ContainsKey("tags") && !content.ContainsKey("user_data"))
            {
                throw new HttpRequestException("any of display_name, new_outer_id, tags and user_data at least");
            }
        }
    }
}
