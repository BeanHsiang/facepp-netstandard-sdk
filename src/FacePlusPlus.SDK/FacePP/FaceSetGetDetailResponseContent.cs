using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class FaceSetGetDetailResponseContent : APIResponseContent
    {
        /// <summary>
        /// face set token
        /// </summary>
        public string FaceSet_Token { get; set; }

        /// <summary>
        /// custom out_id
        /// </summary>
        public string Outer_Id { get; set; }

        /// <summary>
        /// name of face set, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Display_Name { get; set; }

        /// <summary>
        /// custom information, 16 KB at most, exclude: ^@,&=*'"
        /// </summary>
        public string User_Data { get; set; }

        /// <summary>
        /// custom tags, comma-separated, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// total count of face tokens in face set
        /// </summary>
        public int Face_Count { get; set; }

        /// <summary>
        /// face tokens, comma-separated, 5 at most
        /// </summary>
        public string Face_Tokens { get; set; }

        /// <summary>
        /// sequence start value in next request
        /// </summary>
        public string Next { get; set; }
    }
}
