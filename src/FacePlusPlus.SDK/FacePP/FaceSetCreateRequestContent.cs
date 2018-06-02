using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceSetCreateRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "faceset/create";

        /// <summary>
        /// name of face set, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Display_Name { get; set; }

        /// <summary>
        /// unique custom id, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Outer_Id { get; set; }

        /// <summary>
        /// custom tags, comma-separated, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// face tokens, comma-separated, 5 at most
        /// </summary>
        public string Face_Tokens { get; set; }

        /// <summary>
        /// custom information, 16 KB at most, exclude: ^@,&=*'"
        /// </summary>
        public string User_Data { get; set; }

        /// <summary>
        /// whether merge the face toekn into face set if outer_id existed
        /// </summary>
        /// <list type="1">merge</list>
        /// <list type="0">return FACESET_EXIST error</list>
        public int Force_Merge { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrWhiteSpace(Display_Name))
            {
                content.Add("display_name", new StringContent(Display_Name));
            }

            if (!string.IsNullOrWhiteSpace(Outer_Id))
            {
                content.Add("outer_id", new StringContent(Outer_Id));
            }

            if (!string.IsNullOrWhiteSpace(Tags))
            {
                content.Add("tags", new StringContent(Tags));
            }

            if (!string.IsNullOrWhiteSpace(Face_Tokens))
            {
                content.Add("face_tokens", new StringContent(Face_Tokens));
            }

            if (!string.IsNullOrWhiteSpace(User_Data))
            {
                content.Add("user_data", new StringContent(User_Data));
            }

            content.Add("force_merge", new StringContent(Force_Merge.ToString()));
        }
    }
}
